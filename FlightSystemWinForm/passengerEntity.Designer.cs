namespace FlightSystemWinForm
{
    partial class passengerEntity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(passengerEntity));
            tableLayoutPanel1 = new TableLayoutPanel();
            pnameLbl = new Label();
            passNumLbl = new Label();
            flightNumLbl = new Label();
            seatNumLbl = new Label();
            chooseSeatBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Controls.Add(pnameLbl, 0, 0);
            tableLayoutPanel1.Controls.Add(passNumLbl, 1, 0);
            tableLayoutPanel1.Controls.Add(flightNumLbl, 2, 0);
            tableLayoutPanel1.Controls.Add(seatNumLbl, 3, 0);
            tableLayoutPanel1.Controls.Add(chooseSeatBtn, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(510, 50);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnameLbl
            // 
            pnameLbl.AutoSize = true;
            pnameLbl.Dock = DockStyle.Fill;
            pnameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnameLbl.Location = new Point(3, 0);
            pnameLbl.Name = "pnameLbl";
            pnameLbl.Size = new Size(132, 50);
            pnameLbl.TabIndex = 0;
            pnameLbl.Text = "name";
            pnameLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // passNumLbl
            // 
            passNumLbl.AutoSize = true;
            passNumLbl.Dock = DockStyle.Fill;
            passNumLbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passNumLbl.Location = new Point(141, 0);
            passNumLbl.Name = "passNumLbl";
            passNumLbl.Size = new Size(178, 50);
            passNumLbl.TabIndex = 1;
            passNumLbl.Text = "passport number";
            passNumLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flightNumLbl
            // 
            flightNumLbl.AutoSize = true;
            flightNumLbl.Dock = DockStyle.Fill;
            flightNumLbl.Font = new Font("Segoe UI", 12F);
            flightNumLbl.Location = new Point(325, 0);
            flightNumLbl.Name = "flightNumLbl";
            flightNumLbl.Size = new Size(63, 50);
            flightNumLbl.TabIndex = 2;
            flightNumLbl.Text = "flight";
            flightNumLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // seatNumLbl
            // 
            seatNumLbl.AutoSize = true;
            seatNumLbl.Dock = DockStyle.Fill;
            seatNumLbl.Font = new Font("Segoe UI", 12F);
            seatNumLbl.Location = new Point(394, 0);
            seatNumLbl.Name = "seatNumLbl";
            seatNumLbl.Size = new Size(63, 50);
            seatNumLbl.TabIndex = 3;
            seatNumLbl.Text = "SeatNumber";
            seatNumLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chooseSeatBtn
            // 
            chooseSeatBtn.BackgroundImage = (Image)resources.GetObject("chooseSeatBtn.BackgroundImage");
            chooseSeatBtn.BackgroundImageLayout = ImageLayout.Center;
            chooseSeatBtn.Dock = DockStyle.Fill;
            chooseSeatBtn.FlatAppearance.BorderSize = 0;
            chooseSeatBtn.FlatStyle = FlatStyle.Flat;
            chooseSeatBtn.Location = new Point(463, 3);
            chooseSeatBtn.Name = "chooseSeatBtn";
            chooseSeatBtn.Size = new Size(44, 44);
            chooseSeatBtn.TabIndex = 4;
            chooseSeatBtn.UseVisualStyleBackColor = true;
            // 
            // passengerEntity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "passengerEntity";
            Size = new Size(510, 50);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label pnameLbl;
        private Label passNumLbl;
        private Label flightNumLbl;
        private Label seatNumLbl;
        private Button chooseSeatBtn;
    }
}
