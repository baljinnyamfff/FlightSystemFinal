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
        public int? SelectedSeatId { get; private set; }

        public SeatsForm(List<SeatDto> seats, int passengerId, int flightId, HttpClient httpClient)
        {
            InitializeComponent();
            _seats = seats;
            _passengerId = passengerId;
            _flightId = flightId;
            _httpClient = httpClient;
            InitializeSeatGrid();
        }

        public void UpdateSeatStatus(int seatId, bool isAssigned)
        {
            
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
