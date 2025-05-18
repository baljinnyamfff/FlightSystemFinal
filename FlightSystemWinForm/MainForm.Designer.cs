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
            label5 = new Label();
            _logTextBox = new TextBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // changeStatusBtn
            // 
            changeStatusBtn.BackColor = Color.SkyBlue;
            changeStatusBtn.Location = new Point(69, 348);
            changeStatusBtn.Margin = new Padding(6);
            changeStatusBtn.Name = "changeStatusBtn";
            changeStatusBtn.Size = new Size(366, 60);
            changeStatusBtn.TabIndex = 0;
            changeStatusBtn.Text = "Change";
            changeStatusBtn.UseVisualStyleBackColor = false;
            changeStatusBtn.Click += changeStatusBtn_Click;
            // 
            // flightsLbl
            // 
            flightsLbl.AutoSize = true;
            flightsLbl.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flightsLbl.Location = new Point(69, 70);
            flightsLbl.Margin = new Padding(6, 0, 6, 0);
            flightsLbl.Name = "flightsLbl";
            flightsLbl.Size = new Size(110, 37);
            flightsLbl.TabIndex = 1;
            flightsLbl.Text = "Flights:";
            // 
            // flightStatusLbl
            // 
            flightStatusLbl.AutoSize = true;
            flightStatusLbl.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flightStatusLbl.Location = new Point(69, 202);
            flightStatusLbl.Margin = new Padding(6, 0, 6, 0);
            flightStatusLbl.Name = "flightStatusLbl";
            flightStatusLbl.Size = new Size(184, 37);
            flightStatusLbl.TabIndex = 2;
            flightStatusLbl.Text = "Flight Status:";
            // 
            // flightsComboBox
            // 
            flightsComboBox.FormattingEnabled = true;
            flightsComboBox.Location = new Point(69, 123);
            flightsComboBox.Margin = new Padding(6);
            flightsComboBox.Name = "flightsComboBox";
            flightsComboBox.Size = new Size(357, 40);
            flightsComboBox.TabIndex = 3;
            // 
            // flightStatusComboBox
            // 
            flightStatusComboBox.FormattingEnabled = true;
            flightStatusComboBox.Location = new Point(69, 255);
            flightStatusComboBox.Margin = new Padding(6);
            flightStatusComboBox.Name = "flightStatusComboBox";
            flightStatusComboBox.Size = new Size(357, 40);
            flightStatusComboBox.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(516, 70);
            textBox1.Margin = new Padding(6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(944, 39);
            textBox1.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(passengerFlowPnl);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(516, 154);
            panel1.Margin = new Padding(6);
            panel1.Name = "panel1";
            panel1.Size = new Size(947, 770);
            panel1.TabIndex = 7;
            // 
            // passengerFlowPnl
            // 
            passengerFlowPnl.AutoScroll = true;
            passengerFlowPnl.Dock = DockStyle.Bottom;
            passengerFlowPnl.Location = new Point(0, 81);
            passengerFlowPnl.Margin = new Padding(6);
            passengerFlowPnl.Name = "passengerFlowPnl";
            passengerFlowPnl.Size = new Size(947, 689);
            passengerFlowPnl.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.LightSkyBlue;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 93F));
            tableLayoutPanel1.Controls.Add(label4, 3, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(label5, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(947, 85);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(731, 0);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(116, 85);
            label4.TabIndex = 8;
            label4.Text = "Seat Number";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 0);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(244, 85);
            label1.TabIndex = 0;
            label1.Text = "Name";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(262, 0);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(329, 85);
            label2.TabIndex = 1;
            label2.Text = "Password Number";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(603, 0);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(116, 85);
            label3.TabIndex = 2;
            label3.Text = "Flight Number";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label5.Location = new Point(856, 0);
            label5.Name = "label5";
            label5.Size = new Size(88, 85);
            label5.TabIndex = 9;
            label5.Text = "Seat Assign";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // _logTextBox
            // 
            _logTextBox.Dock = DockStyle.Bottom;
            _logTextBox.Location = new Point(0, 915);
            _logTextBox.Margin = new Padding(6);
            _logTextBox.Multiline = true;
            _logTextBox.Name = "_logTextBox";
            _logTextBox.ReadOnly = true;
            _logTextBox.Size = new Size(1486, 45);
            _logTextBox.TabIndex = 8;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1486, 960);
            Controls.Add(_logTextBox);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            Controls.Add(flightStatusComboBox);
            Controls.Add(flightsComboBox);
            Controls.Add(flightStatusLbl);
            Controls.Add(flightsLbl);
            Controls.Add(changeStatusBtn);
            Margin = new Padding(6);
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
        private Label label5;
    }
}
