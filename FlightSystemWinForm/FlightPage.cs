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
    public partial class FlightPage : UserControl
    {
        public FlightPage()
        {
            InitializeComponent();
        }
        public Panel flightFlowPanel => flightFlowPnl;
        public TextBox flightsSearchBox => flightSearchBox;
    }
}
