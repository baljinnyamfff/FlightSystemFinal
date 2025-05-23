namespace FlightSystemWinForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            _logTextBox = new TextBox();
            panel2 = new Panel();
            label6 = new Label();
            showFlightsBtn = new Button();
            showPassengersBtn = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            passengerPage1 = new PassengerPage();
            flightPage1 = new FlightPage();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // _logTextBox
            // 
            _logTextBox.Dock = DockStyle.Bottom;
            _logTextBox.Location = new Point(0, 871);
            _logTextBox.Multiline = true;
            _logTextBox.Name = "_logTextBox";
            _logTextBox.ReadOnly = true;
            _logTextBox.Size = new Size(1444, 10);
            _logTextBox.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(showFlightsBtn);
            panel2.Controls.Add(showPassengersBtn);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(210, 857);
            panel2.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 181);
            label6.Name = "label6";
            label6.Size = new Size(83, 32);
            label6.TabIndex = 10;
            label6.Text = "Agent";
            // 
            // showFlightsBtn
            // 
            showFlightsBtn.BackColor = Color.LightSkyBlue;
            showFlightsBtn.FlatAppearance.BorderSize = 0;
            showFlightsBtn.FlatStyle = FlatStyle.Flat;
            showFlightsBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            showFlightsBtn.Location = new Point(3, 280);
            showFlightsBtn.Name = "showFlightsBtn";
            showFlightsBtn.Size = new Size(205, 36);
            showFlightsBtn.TabIndex = 10;
            showFlightsBtn.Text = "Flights";
            showFlightsBtn.TextAlign = ContentAlignment.MiddleLeft;
            showFlightsBtn.UseVisualStyleBackColor = false;
            showFlightsBtn.Click += showFlightsBtn_Click;
            // 
            // showPassengersBtn
            // 
            showPassengersBtn.BackColor = Color.LightSkyBlue;
            showPassengersBtn.FlatAppearance.BorderSize = 0;
            showPassengersBtn.FlatStyle = FlatStyle.Flat;
            showPassengersBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            showPassengersBtn.Location = new Point(3, 238);
            showPassengersBtn.Name = "showPassengersBtn";
            showPassengersBtn.Size = new Size(205, 36);
            showPassengersBtn.TabIndex = 11;
            showPassengersBtn.Text = "Passengers";
            showPassengersBtn.TextAlign = ContentAlignment.MiddleLeft;
            showPassengersBtn.UseVisualStyleBackColor = false;
            showPassengersBtn.Click += showPassengersBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(25, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 152);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(passengerPage1);
            panel1.Controls.Add(flightPage1);
            panel1.Location = new Point(228, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1204, 857);
            panel1.TabIndex = 10;
            // 
            // passengerPage1
            // 
            passengerPage1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            passengerPage1.Dock = DockStyle.Fill;
            passengerPage1.Location = new Point(0, 0);
            passengerPage1.Name = "passengerPage1";
            passengerPage1.Size = new Size(1204, 857);
            passengerPage1.TabIndex = 0;
            // 
            // flightPage1
            // 
            flightPage1.Dock = DockStyle.Fill;
            flightPage1.Location = new Point(0, 0);
            flightPage1.Name = "flightPage1";
            flightPage1.Size = new Size(1204, 857);
            flightPage1.TabIndex = 11;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1444, 881);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(_logTextBox);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox _logTextBox;
        private Panel panel2;
        private Button showFlightsBtn;
        private Button showPassengersBtn;
        private PictureBox pictureBox1;
        private Label label6;
        private Panel panel1;
        private PassengerPage passengerPage1;
        private FlightPage flightPage1;
    }
}
