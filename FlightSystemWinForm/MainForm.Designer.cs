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
            changeStatusBtn = new Button();
            flightsLbl = new Label();
            flightStatusLbl = new Label();
            flightsComboBox = new ComboBox();
            flightStatusComboBox = new ComboBox();
            textBox1 = new TextBox();
            panel1 = new Panel();
            passengerFlowPnl = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            _logTextBox = new TextBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // changeStatusBtn
            // 
            changeStatusBtn.Location = new Point(12, 77);
            changeStatusBtn.Name = "changeStatusBtn";
            changeStatusBtn.Size = new Size(83, 28);
            changeStatusBtn.TabIndex = 0;
            changeStatusBtn.Text = "Change";
            changeStatusBtn.UseVisualStyleBackColor = true;
            changeStatusBtn.Click += changeStatusBtn_Click;
            // 
            // flightsLbl
            // 
            flightsLbl.AutoSize = true;
            flightsLbl.Location = new Point(12, 9);
            flightsLbl.Name = "flightsLbl";
            flightsLbl.Size = new Size(45, 15);
            flightsLbl.TabIndex = 1;
            flightsLbl.Text = "Flights:";
            // 
            // flightStatusLbl
            // 
            flightStatusLbl.AutoSize = true;
            flightStatusLbl.Location = new Point(12, 51);
            flightStatusLbl.Name = "flightStatusLbl";
            flightStatusLbl.Size = new Size(75, 15);
            flightStatusLbl.TabIndex = 2;
            flightStatusLbl.Text = "Flight Status:";
            // 
            // flightsComboBox
            // 
            flightsComboBox.FormattingEnabled = true;
            flightsComboBox.Location = new Point(90, 6);
            flightsComboBox.Name = "flightsComboBox";
            flightsComboBox.Size = new Size(121, 23);
            flightsComboBox.TabIndex = 3;
            // 
            // flightStatusComboBox
            // 
            flightStatusComboBox.FormattingEnabled = true;
            flightStatusComboBox.Location = new Point(90, 48);
            flightStatusComboBox.Name = "flightStatusComboBox";
            flightStatusComboBox.Size = new Size(121, 23);
            flightStatusComboBox.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(278, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(510, 23);
            textBox1.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(passengerFlowPnl);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(278, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 361);
            panel1.TabIndex = 7;
            // 
            // passengerFlowPnl
            // 
            passengerFlowPnl.AutoScroll = true;
            passengerFlowPnl.Dock = DockStyle.Bottom;
            passengerFlowPnl.Location = new Point(0, 38);
            passengerFlowPnl.Name = "passengerFlowPnl";
            passengerFlowPnl.Size = new Size(510, 323);
            passengerFlowPnl.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Controls.Add(label4, 3, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(510, 40);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(394, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 40);
            label4.TabIndex = 8;
            label4.Text = "Seat Number";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(132, 40);
            label1.TabIndex = 0;
            label1.Text = "Name";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(141, 0);
            label2.Name = "label2";
            label2.Size = new Size(178, 40);
            label2.TabIndex = 1;
            label2.Text = "Password Number";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(325, 0);
            label3.Name = "label3";
            label3.Size = new Size(63, 40);
            label3.TabIndex = 2;
            label3.Text = "Flight Number";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _logTextBox
            // 
            _logTextBox.Dock = DockStyle.Bottom;
            _logTextBox.Location = new Point(0, 427);
            _logTextBox.Multiline = true;
            _logTextBox.Name = "_logTextBox";
            _logTextBox.ReadOnly = true;
            _logTextBox.Size = new Size(800, 23);
            _logTextBox.TabIndex = 8;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_logTextBox);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            Controls.Add(flightStatusComboBox);
            Controls.Add(flightsComboBox);
            Controls.Add(flightStatusLbl);
            Controls.Add(flightsLbl);
            Controls.Add(changeStatusBtn);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button changeStatusBtn;
        private Label flightsLbl;
        private Label flightStatusLbl;
        private ComboBox flightsComboBox;
        private ComboBox flightStatusComboBox;
        private TextBox textBox1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel passengerFlowPnl;
        private Label label4;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox _logTextBox;
    }
}
