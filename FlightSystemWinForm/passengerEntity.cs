using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightSystemWinForm
{
    public partial class passengerEntity : UserControl
    {
        public passengerEntity()
        {
            InitializeComponent();
        }
        public string PassengerName
        {
            get => pnameLbl.Text;
            set => pnameLbl.Text = value;
        }

        public string PassportNumber
        {
            get => passNumLbl.Text;
            set => passNumLbl.Text = value;
        }

        public string FlightNumber
        {
            get => flightNumLbl.Text;
            set => flightNumLbl.Text = value;
        }

        public string SeatNumber
        {
            get => seatNumLbl.Text;
            set => seatNumLbl.Text = value;
        }
        public Button ChooseSeatButton => chooseSeatBtn;
        public Button PrintBoardingPassBtn => printBtn;
    }
}
