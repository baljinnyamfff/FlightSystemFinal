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
    public partial class flightEntity : UserControl
    {
        public flightEntity()
        {
            InitializeComponent();
        }
        public string FLightName
        {
            get => flightNameLbl.Text;
            set => flightNameLbl.Text = value;
        }
        public string FLightDestination
        {
            get => destinationLbl.Text;
            set => destinationLbl.Text = value;
        }
        public string DepartureTime
        {
            get => departureTimeLbl.Text;
            set => departureTimeLbl.Text = value;
        }
        public ComboBox statusComboBox => flightStatusComboBox;
        public Button ChangeStatusBtn => changeStatusBtn;
    }
}
