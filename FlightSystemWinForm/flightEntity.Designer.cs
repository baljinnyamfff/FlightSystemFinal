namespace FlightSystemWinForm
{
    partial class flightEntity
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(flightEntity));
            tableLayoutPanel1 = new TableLayoutPanel();
            departureTimeLbl = new Label();
            destinationLbl = new Label();
            flightNameLbl = new Label();
            changeStatusBtn = new Button();
            flightStatusComboBox = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.86911F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.13089F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Controls.Add(departureTimeLbl, 2, 0);
            tableLayoutPanel1.Controls.Add(destinationLbl, 1, 0);
            tableLayoutPanel1.Controls.Add(flightNameLbl, 0, 0);
            tableLayoutPanel1.Controls.Add(changeStatusBtn, 4, 0);
            tableLayoutPanel1.Controls.Add(flightStatusComboBox, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(764, 50);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // departureTimeLbl
            // 
            departureTimeLbl.AutoSize = true;
            departureTimeLbl.Dock = DockStyle.Fill;
            departureTimeLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            departureTimeLbl.Location = new Point(355, 0);
            departureTimeLbl.Name = "departureTimeLbl";
            departureTimeLbl.Size = new Size(169, 50);
            departureTimeLbl.TabIndex = 3;
            departureTimeLbl.Text = "label4";
            departureTimeLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // destinationLbl
            // 
            destinationLbl.AutoSize = true;
            destinationLbl.Dock = DockStyle.Fill;
            destinationLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            destinationLbl.Location = new Point(179, 0);
            destinationLbl.Name = "destinationLbl";
            destinationLbl.Size = new Size(170, 50);
            destinationLbl.TabIndex = 2;
            destinationLbl.Text = "dest";
            destinationLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flightNameLbl
            // 
            flightNameLbl.AutoSize = true;
            flightNameLbl.Dock = DockStyle.Fill;
            flightNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flightNameLbl.Location = new Point(3, 0);
            flightNameLbl.Name = "flightNameLbl";
            flightNameLbl.Size = new Size(170, 50);
            flightNameLbl.TabIndex = 1;
            flightNameLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // changeStatusBtn
            // 
            changeStatusBtn.BackgroundImage = (Image)resources.GetObject("changeStatusBtn.BackgroundImage");
            changeStatusBtn.BackgroundImageLayout = ImageLayout.Center;
            changeStatusBtn.Dock = DockStyle.Fill;
            changeStatusBtn.FlatAppearance.BorderSize = 0;
            changeStatusBtn.FlatStyle = FlatStyle.Flat;
            changeStatusBtn.Location = new Point(706, 3);
            changeStatusBtn.Name = "changeStatusBtn";
            changeStatusBtn.Size = new Size(55, 44);
            changeStatusBtn.TabIndex = 4;
            changeStatusBtn.UseVisualStyleBackColor = true;
            // 
            // flightStatusComboBox
            // 
            flightStatusComboBox.Dock = DockStyle.Fill;
            flightStatusComboBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flightStatusComboBox.FormattingEnabled = true;
            flightStatusComboBox.Items.AddRange(new object[] { "CheckingIn", "Boarding", "Departed", "Delayed", "Cancelled" });
            flightStatusComboBox.Location = new Point(530, 3);
            flightStatusComboBox.Name = "flightStatusComboBox";
            flightStatusComboBox.Size = new Size(170, 29);
            flightStatusComboBox.TabIndex = 5;
            // 
            // flightEntity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "flightEntity";
            Size = new Size(764, 50);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label departureTimeLbl;
        private Label destinationLbl;
        private Label flightNameLbl;
        private Button changeStatusBtn;
        private ComboBox flightStatusComboBox;
    }
}
