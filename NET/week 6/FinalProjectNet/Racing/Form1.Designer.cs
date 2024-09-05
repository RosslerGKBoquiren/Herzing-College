namespace Racing
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listBoxCar = new ListBox();
            listBoxBicycle = new ListBox();
            listBoxMotorbike = new ListBox();
            listBoxTruck = new ListBox();
            label1 = new Label();
            label2 = new Label();
            buttonAddToRace = new Button();
            buttonStartRace = new Button();
            buttonResetRace = new Button();
            progressBarCar = new ProgressBar();
            progressBarBicycle = new ProgressBar();
            progressBarMotorbike = new ProgressBar();
            progressBarTruck = new ProgressBar();
            labelCar = new Label();
            labelBicycle = new Label();
            labelMotorbike = new Label();
            labelTruck = new Label();
            listBoxSelectedVehicles = new ListBox();
            labelMessage = new Label();
            timerRace = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            SuspendLayout();
            // 
            // listBoxCar
            // 
            listBoxCar.BackColor = SystemColors.HighlightText;
            listBoxCar.BorderStyle = BorderStyle.FixedSingle;
            listBoxCar.Font = new Font("Showcard Gothic", 8.25F);
            listBoxCar.FormattingEnabled = true;
            listBoxCar.ItemHeight = 14;
            listBoxCar.Location = new Point(229, 185);
            listBoxCar.Name = "listBoxCar";
            listBoxCar.Size = new Size(120, 30);
            listBoxCar.TabIndex = 0;
            // 
            // listBoxBicycle
            // 
            listBoxBicycle.BorderStyle = BorderStyle.FixedSingle;
            listBoxBicycle.Font = new Font("Showcard Gothic", 8.25F);
            listBoxBicycle.FormattingEnabled = true;
            listBoxBicycle.ItemHeight = 14;
            listBoxBicycle.Location = new Point(229, 225);
            listBoxBicycle.Name = "listBoxBicycle";
            listBoxBicycle.Size = new Size(120, 30);
            listBoxBicycle.TabIndex = 1;
            // 
            // listBoxMotorbike
            // 
            listBoxMotorbike.BorderStyle = BorderStyle.FixedSingle;
            listBoxMotorbike.Font = new Font("Showcard Gothic", 8.25F);
            listBoxMotorbike.FormattingEnabled = true;
            listBoxMotorbike.ItemHeight = 14;
            listBoxMotorbike.Location = new Point(229, 265);
            listBoxMotorbike.Name = "listBoxMotorbike";
            listBoxMotorbike.Size = new Size(120, 30);
            listBoxMotorbike.TabIndex = 2;
            // 
            // listBoxTruck
            // 
            listBoxTruck.BorderStyle = BorderStyle.FixedSingle;
            listBoxTruck.Font = new Font("Showcard Gothic", 8.25F);
            listBoxTruck.FormattingEnabled = true;
            listBoxTruck.ItemHeight = 14;
            listBoxTruck.Location = new Point(229, 305);
            listBoxTruck.Name = "listBoxTruck";
            listBoxTruck.Size = new Size(120, 30);
            listBoxTruck.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Showcard Gothic", 15.75F);
            label1.ForeColor = Color.LightSkyBlue;
            label1.Location = new Point(227, 153);
            label1.Name = "label1";
            label1.Size = new Size(120, 29);
            label1.TabIndex = 8;
            label1.Text = "Selection";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Showcard Gothic", 15.75F);
            label2.ForeColor = Color.LightSkyBlue;
            label2.Location = new Point(353, 153);
            label2.Name = "label2";
            label2.Size = new Size(223, 29);
            label2.TabIndex = 9;
            label2.Text = "Selected Vechicles";
            // 
            // buttonAddToRace
            // 
            buttonAddToRace.BackColor = Color.Transparent;
            buttonAddToRace.BackgroundImageLayout = ImageLayout.None;
            buttonAddToRace.FlatStyle = FlatStyle.Flat;
            buttonAddToRace.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAddToRace.ForeColor = Color.Gold;
            buttonAddToRace.Location = new Point(239, 341);
            buttonAddToRace.Name = "buttonAddToRace";
            buttonAddToRace.Size = new Size(98, 27);
            buttonAddToRace.TabIndex = 10;
            buttonAddToRace.Text = "Add to Race";
            buttonAddToRace.UseVisualStyleBackColor = false;
            buttonAddToRace.Click += buttonAddToRace_Click;
            // 
            // buttonStartRace
            // 
            buttonStartRace.BackColor = Color.Transparent;
            buttonStartRace.BackgroundImageLayout = ImageLayout.None;
            buttonStartRace.FlatStyle = FlatStyle.Flat;
            buttonStartRace.Font = new Font("Showcard Gothic", 12F);
            buttonStartRace.ForeColor = Color.LimeGreen;
            buttonStartRace.Location = new Point(286, 652);
            buttonStartRace.Name = "buttonStartRace";
            buttonStartRace.Size = new Size(110, 31);
            buttonStartRace.TabIndex = 11;
            buttonStartRace.Text = "Start Race";
            buttonStartRace.UseVisualStyleBackColor = false;
            buttonStartRace.Click += buttonStartRace_Click;
            // 
            // buttonResetRace
            // 
            buttonResetRace.BackColor = Color.Transparent;
            buttonResetRace.BackgroundImageLayout = ImageLayout.None;
            buttonResetRace.FlatStyle = FlatStyle.Flat;
            buttonResetRace.Font = new Font("Showcard Gothic", 12F);
            buttonResetRace.ForeColor = Color.Gray;
            buttonResetRace.Location = new Point(402, 652);
            buttonResetRace.Name = "buttonResetRace";
            buttonResetRace.Size = new Size(111, 31);
            buttonResetRace.TabIndex = 12;
            buttonResetRace.Text = "Reset";
            buttonResetRace.UseVisualStyleBackColor = false;
            buttonResetRace.Click += buttonResetRace_Click;
            // 
            // progressBarCar
            // 
            progressBarCar.AccessibleRole = AccessibleRole.ProgressBar;
            progressBarCar.BackColor = Color.White;
            progressBarCar.Location = new Point(227, 428);
            progressBarCar.Name = "progressBarCar";
            progressBarCar.Size = new Size(326, 23);
            progressBarCar.TabIndex = 13;
            // 
            // progressBarBicycle
            // 
            progressBarBicycle.BackColor = Color.White;
            progressBarBicycle.Location = new Point(229, 487);
            progressBarBicycle.Name = "progressBarBicycle";
            progressBarBicycle.Size = new Size(326, 23);
            progressBarBicycle.TabIndex = 14;
            // 
            // progressBarMotorbike
            // 
            progressBarMotorbike.BackColor = Color.White;
            progressBarMotorbike.Location = new Point(229, 547);
            progressBarMotorbike.Name = "progressBarMotorbike";
            progressBarMotorbike.Size = new Size(326, 23);
            progressBarMotorbike.TabIndex = 15;
            // 
            // progressBarTruck
            // 
            progressBarTruck.BackColor = Color.White;
            progressBarTruck.Location = new Point(229, 611);
            progressBarTruck.Name = "progressBarTruck";
            progressBarTruck.Size = new Size(326, 23);
            progressBarTruck.TabIndex = 16;
            // 
            // labelCar
            // 
            labelCar.AutoSize = true;
            labelCar.BackColor = Color.Transparent;
            labelCar.Font = new Font("Showcard Gothic", 14.25F);
            labelCar.ForeColor = Color.White;
            labelCar.Location = new Point(227, 399);
            labelCar.Name = "labelCar";
            labelCar.Size = new Size(46, 23);
            labelCar.TabIndex = 17;
            labelCar.Text = "Car";
            // 
            // labelBicycle
            // 
            labelBicycle.AutoSize = true;
            labelBicycle.BackColor = Color.Transparent;
            labelBicycle.Font = new Font("Showcard Gothic", 14.25F);
            labelBicycle.ForeColor = Color.White;
            labelBicycle.Location = new Point(227, 458);
            labelBicycle.Name = "labelBicycle";
            labelBicycle.Size = new Size(86, 23);
            labelBicycle.TabIndex = 18;
            labelBicycle.Text = "Bicycle";
            // 
            // labelMotorbike
            // 
            labelMotorbike.AutoSize = true;
            labelMotorbike.BackColor = Color.Transparent;
            labelMotorbike.Font = new Font("Showcard Gothic", 14.25F);
            labelMotorbike.ForeColor = Color.White;
            labelMotorbike.Location = new Point(227, 518);
            labelMotorbike.Name = "labelMotorbike";
            labelMotorbike.Size = new Size(124, 23);
            labelMotorbike.TabIndex = 19;
            labelMotorbike.Text = "Motorbike";
            // 
            // labelTruck
            // 
            labelTruck.AutoSize = true;
            labelTruck.BackColor = Color.Transparent;
            labelTruck.Font = new Font("Showcard Gothic", 14.25F);
            labelTruck.ForeColor = Color.White;
            labelTruck.Location = new Point(227, 582);
            labelTruck.Name = "labelTruck";
            labelTruck.Size = new Size(74, 23);
            labelTruck.TabIndex = 20;
            labelTruck.Text = "Truck";
            // 
            // listBoxSelectedVehicles
            // 
            listBoxSelectedVehicles.BorderStyle = BorderStyle.FixedSingle;
            listBoxSelectedVehicles.Font = new Font("Showcard Gothic", 8.25F);
            listBoxSelectedVehicles.FormattingEnabled = true;
            listBoxSelectedVehicles.ItemHeight = 14;
            listBoxSelectedVehicles.Location = new Point(364, 185);
            listBoxSelectedVehicles.Name = "listBoxSelectedVehicles";
            listBoxSelectedVehicles.Size = new Size(200, 142);
            listBoxSelectedVehicles.TabIndex = 21;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.BackColor = Color.White;
            labelMessage.BorderStyle = BorderStyle.FixedSingle;
            labelMessage.FlatStyle = FlatStyle.Flat;
            labelMessage.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMessage.ForeColor = Color.White;
            labelMessage.Location = new Point(364, 341);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(2, 20);
            labelMessage.TabIndex = 22;
            // 
            // timerRace
            // 
            timerRace.Tick += timerRace_Tick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Showcard Gothic", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(75, 54);
            label3.Name = "label3";
            label3.Size = new Size(649, 79);
            label3.TabIndex = 23;
            label3.Text = " RACING SIMULATOR";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(796, 749);
            Controls.Add(label3);
            Controls.Add(labelMessage);
            Controls.Add(listBoxSelectedVehicles);
            Controls.Add(labelTruck);
            Controls.Add(labelMotorbike);
            Controls.Add(labelBicycle);
            Controls.Add(labelCar);
            Controls.Add(progressBarTruck);
            Controls.Add(progressBarMotorbike);
            Controls.Add(progressBarBicycle);
            Controls.Add(progressBarCar);
            Controls.Add(buttonResetRace);
            Controls.Add(buttonStartRace);
            Controls.Add(buttonAddToRace);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxTruck);
            Controls.Add(listBoxMotorbike);
            Controls.Add(listBoxBicycle);
            Controls.Add(listBoxCar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxCar;
        private ListBox listBoxBicycle;
        private ListBox listBoxMotorbike;
        private ListBox listBoxTruck;
        private Label label1;
        private Label label2;
        private Button buttonAddToRace;
        private Button buttonStartRace;
        private Button buttonResetRace;
        private ProgressBar progressBarCar;
        private ProgressBar progressBarBicycle;
        private ProgressBar progressBarMotorbike;
        private ProgressBar progressBarTruck;
        private Label labelCar;
        private Label labelBicycle;
        private Label labelMotorbike;
        private Label labelTruck;
        private ListBox listBoxSelectedVehicles;
        private Label labelMessage;
        private System.Windows.Forms.Timer timerRace;
        private Label label3;
    }
}
