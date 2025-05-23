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
        private readonly SocketClientWorker _socketWorker;
        private List<FlightDto> _flights;
        private List<PassengerDto> _passes;
        private SeatsForm? _currentSeatsForm;

        public MainForm(SocketClientWorker socketClient)
        {
            InitializeComponent();
            _socketWorker = socketClient;
            _socketWorker.OnSeatReceived += HandleSeatAssignSocket;
            _socketWorker.OnFlightReceived += HandleFLightStatusSocket;
            _logTextBox.Height = 20;
            flightStatusComboBox.Items.AddRange(new[] { "CheckingIn", "Boarding", "Departed", "Delayed", "Cancelled" });
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await _socketWorker.ConnectAsync("localhost", 6001);
            await LoadPassengersAsync();
            await LoadFlightsAsync();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _socketWorker.Dispose();
        }
        private void HandleFLightStatusSocket(string flightNumber,  string newStatus)
        {
            LogMessage("got flight status");
        }
        private void HandleSeatAssignSocket(int seatId)
        {
            LogMessage("Got seat socket message");
            if (_currentSeatsForm != null && !_currentSeatsForm.IsDisposed)
            {
                LogMessage("update seat called");
                _currentSeatsForm.UpdateSeatStatus(seatId, true);
            }
        }

        private void LogMessage(string message)
        {
            //if (InvokeRequired)
            //{
            //    Invoke(new Action(() => LogMessage(message)));
            //    return;
            //}
            //_logTextBox.AppendText($"{DateTime.Now:ss} - {message}");
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
                                if (seats != null && _socketWorker != null)
                                {
                                    using var dialog = new SeatsForm(seats, p.Id, p.FlightId, _httpClient);
                                    _currentSeatsForm = dialog;

                                    if (dialog.ShowDialog() == DialogResult.OK)
                                    {
                                        await LoadPassengersAsync();
                                    }
                                    _currentSeatsForm = null;
                                    dialog.Dispose();
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
