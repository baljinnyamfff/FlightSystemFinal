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
    public partial class PassengerPage : UserControl
    {
        public PassengerPage()
        {
            InitializeComponent();
        }
        public Panel passengerFlowPanel => passengerFlowPnl;
        public TextBox passengerSearchBox => textBox1;
    }
}
