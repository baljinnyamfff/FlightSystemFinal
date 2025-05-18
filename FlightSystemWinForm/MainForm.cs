using System.Net.Http.Json;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using FlightSystemDatabase.dto;
namespace FlightSystemWinForm
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7166/") };
        private TcpClient? _socketClient;
        private NetworkStream? _socketStream;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private List<FlightDto> _flights;
        private List<PassengerDto> _passes;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            _cancellationTokenSource = new CancellationTokenSource();
            _logTextBox.Height = 60;
            flightStatusComboBox.Items.AddRange(new[] { "CheckingIn", "Boarding", "Departed", "Delayed", "Cancelled" });
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadPassengersAsync();
            await LoadFlightsAsync();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await ConnectToSocketServer();
            await LoadPassengersAsync();
            await LoadFlightsAsync();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _cancellationTokenSource.Cancel();
            _socketStream?.Dispose();
            _socketClient?.Dispose();
            _cancellationTokenSource.Dispose();
        }

        private async Task ConnectToSocketServer()
        {
            try
            {
                if (_socketClient?.Connected == true)
                {
                    return;
                }

                _socketClient?.Dispose();

                _socketClient = new TcpClient();
                await _socketClient.ConnectAsync("localhost", 6001);
                _socketStream = _socketClient.GetStream();

                // Start listening for messages
                _ = ListenForMessagesAsync(_cancellationTokenSource.Token);
                LogMessage("Connected to socket server");
            }
            catch (Exception ex)
            {
                LogMessage($"Error connecting to socket server: {ex.Message}");
                MessageBox.Show($"Error connecting to socket server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ListenForMessagesAsync(CancellationToken cancellationToken)
        {
            var buffer = new byte[1024];
            try
            {
                while (!cancellationToken.IsCancellationRequested && _socketStream != null)
                {
                    var bytesRead = await _socketStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                    if (bytesRead == 0) break;

                    var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    LogMessage($"Received: {message}");
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    LogMessage($"Error reading from socket: {ex.Message}");
                    // Try to reconnectt
                    await Task.Delay(5000, cancellationToken);
                    await ConnectToSocketServer();
                }
            }
        }

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogMessage(message)));
                return;
            }
            _logTextBox.AppendText($"{DateTime.Now:HH:mm:ss} - {message}");
        }


        private async Task LoadPassengersAsync()
        {
            _passes = await _httpClient.GetFromJsonAsync<List<PassengerDto>>("api/passengers");
            passengerFlowPnl.Controls.Clear();

            //MessageBox.Show($"{_passes.Count()} got");
            foreach (var p in _passes)
            {
                try
                {
                    var passengerControl = new passengerEntity
                    {
                        PassengerName = p.Name,
                        PassportNumber = p.PassportNumber,
                        FlightNumber = p.FlightId.ToString(),
                        SeatNumber = p.SeatId?.ToString() ?? "No seat",
                    };
                    passengerControl.ChooseSeatButton.Tag = p;
                    passengerControl.ChooseSeatButton.Click += async (s, e) =>
                    {
                        try
                        {
                            var response = await _httpClient.GetAsync($"api/flights/{p.FlightId}/seats");
                            if (response.IsSuccessStatusCode)
                            {
                                var content = await response.Content.ReadAsStringAsync();
                                if (string.IsNullOrEmpty(content))
                                {
                                    MessageBox.Show("No seats available for this flight.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                var seats = await response.Content.ReadFromJsonAsync<List<SeatDto>>();
                                if (seats != null && _socketClient != null)
                                {
                                    using var dialog = new SeatsForm(seats, p.Id, p.FlightId, _httpClient, _socketClient);
                                    if (dialog.ShowDialog() == DialogResult.OK)
                                    {
                                        // Refresh the passenger list to show the new seat assignment
                                        await LoadPassengersAsync();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("nulll");
                                }
                            }
                            else
                            {
                                MessageBox.Show("status 404");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error loading seats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                    passengerControl.Dock = DockStyle.Top;
                    passengerFlowPnl.Controls.Add(passengerControl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }
                
            }
        }   

        private async Task LoadFlightsAsync()
        {
            _flights = await _httpClient.GetFromJsonAsync<List<FlightDto>>("api/flights");
            flightsComboBox.DataSource = _flights;
            flightsComboBox.DisplayMember = "Display";

        }
        private async void changeStatusBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (flightsComboBox.SelectedItem is FlightDto selectedFlight && flightStatusComboBox.SelectedItem is string newStatus)
                {
                    var response = await _httpClient.PutAsJsonAsync($"api/flights/{selectedFlight.Id}/status", newStatus);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadFlightsAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to update status: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select both a flight and a status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
