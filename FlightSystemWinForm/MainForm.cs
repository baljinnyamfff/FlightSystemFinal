using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using FlightSystemDatabase.dto;
using System.Drawing.Printing;

namespace FlightSystemWinForm
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7166/") };
        private readonly SocketClientWorker _socketWorker;
        private List<FlightDto> _flights;
        private List<PassengerDto> _passes;
        private SeatsForm? _currentSeatsForm;
        private TextBox passengerSearchBox;
        private TextBox flightSearchBox;

        public MainForm(SocketClientWorker socketClient)
        {
            InitializeComponent();
            passengerSearchBox = passengerPage1.passengerSearchBox;
            flightSearchBox = flightPage1.flightsSearchBox;
            passengerSearchBox.TextChanged += passengerSearchBox_TextChanged;
            flightSearchBox.TextChanged += flightSearchBox_TextChanged;
            _socketWorker = socketClient;
            _socketWorker.OnSeatReceived += HandleSeatAssignSocket;
            _socketWorker.OnFlightReceived += HandleFLightStatusSocket;
            _logTextBox.Height = 20;
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
        private void HandleFLightStatusSocket(string flightNumber, string newStatus)
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
            LoadPassengersAsync();
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
            var passengerFlowPnl = passengerPage1.passengerFlowPanel;
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
                    passengerControl.ChooseSeatButton.Click += assignSeatBtn_Click;

                    passengerControl.PrintBoardingPassBtn.Visible = p.SeatId == null ? false : true;
                    passengerControl.PrintBoardingPassBtn.Tag = p.Id;
                    passengerControl.PrintBoardingPassBtn.Click += printBoardingPassBtn_Click;

                    passengerControl.Dock = DockStyle.Top;
                    passengerFlowPnl.Controls.Add(passengerControl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }

            }
        }

        private async void assignSeatBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is PassengerDto p)
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
                                bool firstTimeBP = p.SeatId == null;
                                await LoadPassengersAsync();
                                var pass = _passes.FirstOrDefault(ps => ps.Id == p.Id);
                                if(pass != null && pass.SeatId != null)
                                {
                                    BoardingPassDto bpDto = new BoardingPassDto()
                                    {
                                        PassengerId = pass.Id,
                                        SeatId = pass.SeatId,
                                        FlightId = pass.FlightId,
                                        IssuedAt = DateTime.UtcNow,
                                    };

                                    if (firstTimeBP)
                                    {
                                        var res = await _httpClient.PostAsJsonAsync($"api/boardingpasses", bpDto);

                                    }
                                    else
                                    {
                                        var res = await _httpClient.PutAsJsonAsync($"api/boardingpasses/{pass.Id}", bpDto);
                                    }
                                }
                            }
                            _currentSeatsForm = null;
                        }
                        else
                        {
                            MessageBox.Show("No seats were returned.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Flight not found (404).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading seats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private async Task LoadFlightsAsync()
        {
            _flights = await _httpClient.GetFromJsonAsync<List<FlightDto>>("api/flights");
            var flightsFlowPnl = flightPage1.flightFlowPanel;
            flightsFlowPnl.Controls.Clear();
            foreach (var f in _flights)
            {
                var flightControl = new flightEntity
                {
                    FLightName = f.FlightNumber,
                    FLightDestination = f.Destination,
                    DepartureTime = f.DepartureTime.ToString(),
                };
                flightControl.statusComboBox.SelectedItem = f.Status.ToString();
                flightControl.Tag = f;
                flightControl.Dock = DockStyle.Top;
                flightControl.ChangeStatusBtn.Tag = f.Status.ToString();
                flightControl.ChangeStatusBtn.Click += changeStatusBtn_Click;
                flightsFlowPnl.Controls.Add(flightControl);
            }

        }
        private void showPassengersBtn_Click(object sender, EventArgs e)
        {
            passengerPage1.BringToFront();
        }

        private void showFlightsBtn_Click(object sender, EventArgs e)
        {
            flightPage1.BringToFront();
        }
        private async void changeStatusBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button btn)
                {
                    Control parent = btn.Parent;
                    while (parent != null && parent is not flightEntity)
                    {
                        parent = parent.Parent;
                    }

                    if (parent is flightEntity flightControl && flightControl.Tag is FlightDto f)
                    {
                        string? newStatus = flightControl.statusComboBox.SelectedItem?.ToString();

                        if (!string.IsNullOrEmpty(newStatus))
                        {
                            var response = await _httpClient.PutAsJsonAsync($"api/flights/{f.Id}/status", newStatus);
                            if (response.IsSuccessStatusCode)
                            {
                                //MessageBox.Show("Status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //await LoadFlightsAsync(); // Refresh UI
                            }
                            else
                            {
                                var error = await response.Content.ReadAsStringAsync();
                                MessageBox.Show($"Failed to update status: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Flight data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void printBoardingPassBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button btn && btn.Tag is int passId)
                {
                    var bpDto = await _httpClient.GetFromJsonAsync<BoardingPassDto>($"api/boardingpasses/{passId}");
                    if (bpDto != null)
                    {
                        var flight = _flights.FirstOrDefault(f => f.Id == bpDto.FlightId);
                        var passenger = _passes.FirstOrDefault(p => p.Id == bpDto.PassengerId);

                        if (flight == null || passenger == null)
                        {
                            MessageBox.Show("Flight or Passenger info not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var seat = passenger.SeatId?.ToString() ?? "N/A";

                        // Create content to print
                        var boardingPassText = new StringBuilder();
                        boardingPassText.AppendLine("BOARDING PASS");
                        boardingPassText.AppendLine("----------------------------");
                        boardingPassText.AppendLine($"Passenger Name: {passenger.Name}");
                        boardingPassText.AppendLine($"Passport #: {passenger.PassportNumber}");
                        boardingPassText.AppendLine($"Flight #: {flight.FlightNumber}");
                        boardingPassText.AppendLine($"Destination: {flight.Destination}");
                        boardingPassText.AppendLine($"Departure Time: {flight.DepartureTime}");
                        boardingPassText.AppendLine($"Seat #: {seat}");
                        boardingPassText.AppendLine($"Issued At: {bpDto.IssuedAt}");

                        // Show a print preview or directly print
                        PrintDocument printDoc = new PrintDocument();
                        printDoc.PrintPage += (s, ev) =>
                        {
                            ev.Graphics.DrawString(boardingPassText.ToString(), new Font("Consolas", 12), Brushes.Black, 20, 20);
                        };

                        PrintDialog dlg = new PrintDialog();
                        dlg.Document = printDoc;
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            printDoc.Print();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Boarding pass not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing boarding pass: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void passengerSearchBox_TextChanged(object sender, EventArgs e)
        {
            string query = passengerSearchBox.Text.Trim().ToLower();
            var passengerFlowPnl = passengerPage1.passengerFlowPanel;
            passengerFlowPnl.Controls.Clear();

            var filtered = _passes.Where(p =>
                p.Name.ToLower().Contains(query) ||
                p.PassportNumber.ToLower().Contains(query) ||
                p.FlightId.ToString().Contains(query) ||
                (p.SeatId?.ToString() ?? "").Contains(query)
            ).ToList();

            foreach (var p in filtered)
            {
                var passengerControl = new passengerEntity
                {
                    PassengerName = p.Name,
                    PassportNumber = p.PassportNumber,
                    FlightNumber = p.FlightId.ToString(),
                    SeatNumber = p.SeatId?.ToString() ?? "No seat",
                };

                passengerControl.ChooseSeatButton.Tag = p;
                passengerControl.ChooseSeatButton.Click += assignSeatBtn_Click;

                passengerControl.PrintBoardingPassBtn.Visible = p.SeatId != null;
                passengerControl.PrintBoardingPassBtn.Tag = p.Id;
                passengerControl.PrintBoardingPassBtn.Click += printBoardingPassBtn_Click;

                passengerControl.Dock = DockStyle.Top;
                passengerFlowPnl.Controls.Add(passengerControl);
            }
        }
        private void flightSearchBox_TextChanged(object sender, EventArgs e)
        {
            string query = flightSearchBox.Text.Trim().ToLower();
            var flightsFlowPnl = flightPage1.flightFlowPanel;
            flightsFlowPnl.Controls.Clear();

            var filtered = _flights.Where(f =>
                f.FlightNumber.ToLower().Contains(query) ||
                f.Destination.ToLower().Contains(query) ||
                f.Status.ToString().ToLower().Contains(query)
            ).ToList();

            foreach (var f in filtered)
            {
                var flightControl = new flightEntity
                {
                    FLightName = f.FlightNumber,
                    FLightDestination = f.Destination,
                    DepartureTime = f.DepartureTime.ToString(),
                };
                flightControl.statusComboBox.SelectedItem = f.Status.ToString();
                flightControl.Tag = f;
                flightControl.Dock = DockStyle.Top;
                flightControl.ChangeStatusBtn.Tag = f.Status.ToString();
                flightControl.ChangeStatusBtn.Click += changeStatusBtn_Click;
                flightsFlowPnl.Controls.Add(flightControl);
            }
        }

    }
}