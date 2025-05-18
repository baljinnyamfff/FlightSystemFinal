using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightSystemDatabase.dto;

namespace FlightSystemWinForm
{
    public partial class SeatsForm : Form
    {
        private readonly List<SeatDto> _seats;
        private readonly int _passengerId;
        private readonly int _flightId;
        private readonly HttpClient _httpClient;
        private readonly TcpClient _socketClient;
        private NetworkStream? _socketStream;
        private Task? _listenTask;
        private readonly CancellationTokenSource _cancellationTokenSource;
        public int? SelectedSeatId { get; private set; }

        public SeatsForm(List<SeatDto> seats, int passengerId, int flightId, HttpClient httpClient, TcpClient socketClient)
        {
            InitializeComponent();
            _seats = seats;
            _passengerId = passengerId;
            _flightId = flightId;
            _httpClient = httpClient;
            _socketClient = socketClient;
            _cancellationTokenSource = new CancellationTokenSource();
            InitializeSeatGrid();
            StartListeningForUpdates();
        }

        private void StartListeningForUpdates()
        {
            if (_socketClient?.Connected == true)
            {
                _socketStream = _socketClient.GetStream();
                _listenTask = Task.Run(async () =>
                {
                    var buffer = new byte[1024];
                    try
                    {
                        while (!_cancellationTokenSource.Token.IsCancellationRequested && _socketStream != null)
                        {
                            var bytesRead = await _socketStream.ReadAsync(buffer, 0, buffer.Length, _cancellationTokenSource.Token);
                            if (bytesRead == 0) break;

                            var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            if (message.StartsWith("SEAT_ASSIGNED:"))
                            {
                                var parts = message.Split(':');
                                if (parts.Length >= 3 && int.TryParse(parts[1], out int seatId))
                                {
                                    UpdateSeatStatus(seatId, true);
                                }
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // Normal cancellation, do nothing
                    }
                    catch (Exception ex)
                    {
                        if (!_cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            MessageBox.Show($"Error reading socket updates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }, _cancellationTokenSource.Token);
            }
        }

        private void UpdateSeatStatus(int seatId, bool isAssigned)
        {
            // Find the button for this seat
            foreach (Control control in Controls)
            {
                if (control is TableLayoutPanel seatGrid)
                {
                    foreach (Control seatControl in seatGrid.Controls)
                    {
                        if (seatControl is Button seatButton &&
                            seatButton.Tag is int buttonSeatId &&
                            buttonSeatId == seatId)
                        {
                            // Update the button appearance
                            seatButton.BackColor = isAssigned ? Color.LightGray : Color.LightGreen;
                            seatButton.Enabled = !isAssigned;
                            seatButton.Text = isAssigned ?
                                $"{_seats.First(s => s.Id == seatId).SeatNumber} (Assigned)" :
                                _seats.First(s => s.Id == seatId).SeatNumber;
                            break;
                        }
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _listenTask?.Wait(1000); // Wait for the listening task to complete
            _socketStream?.Dispose();
            _cancellationTokenSource.Cancel();
        }

        private void InitializeSeatGrid()
        {
            Controls.Clear(); // дахин initialize хийхэд хуучныг арилгах

            var seatGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Padding = new Padding(10),
                AutoSize = false
            };

            int seatCount = _seats.Count;
            int columns = 6;
            int rows = (int)Math.Ceiling(seatCount / (double)columns);
            seatGrid.RowCount = rows;
            seatGrid.ColumnCount = columns;

            int gridWidth = this.ClientSize.Width - 20; // padding
            int gridHeight = this.ClientSize.Height - 70; // padding + legend panel

            int buttonWidth = gridWidth / columns - 4;
            int buttonHeight = gridHeight / rows - 4;

            for (int i = 0; i < seatCount; i++)
            {
                var seat = _seats[i];
                var seatButton = new Button
                {
                    Text = seat.SeatNumber,
                    Size = new Size(buttonWidth, buttonHeight),
                    Margin = new Padding(2),
                    Tag = seat.Id
                };

                if (seat.IsAssigned)
                {
                    seatButton.BackColor = Color.LightGray;
                    seatButton.Enabled = false;
                    seatButton.Text += " (Assigned)";
                }
                else
                {
                    seatButton.BackColor = Color.LightGreen;
                    seatButton.Click += SeatButton_Click;
                }

                seatGrid.Controls.Add(seatButton, i % columns, i / columns);
            }

            Controls.Add(seatGrid);

            var legendPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };

            var availableLabel = new Label
            {
                Text = "Available",
                BackColor = Color.LightGreen,
                AutoSize = true,
                Location = new Point(10, 15)
            };

            var assignedLabel = new Label
            {
                Text = "Assigned",
                BackColor = Color.LightGray,
                AutoSize = true,
                Location = new Point(150, 15)
            };

            legendPanel.Controls.Add(availableLabel);
            legendPanel.Controls.Add(assignedLabel);
            Controls.Add(legendPanel);
        }
        private async void SeatButton_Click(object sender, EventArgs e)
        {
            if (sender is Button seatButton && seatButton.Tag is int seatId)
            {
                try
                {
                    var response = await _httpClient.PostAsync($"api/checkin/assign-seat?passengerId={_passengerId}&seatId={seatId}", null);

                    if (response.IsSuccessStatusCode)
                    {
                        SelectedSeatId = seatId;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to assign seat: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error assigning seat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
