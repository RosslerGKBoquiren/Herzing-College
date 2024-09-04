namespace RacingSimulator
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
            progressBarCar = new ProgressBar();
            progressBarBicycle = new ProgressBar();
            progressBarTruck = new ProgressBar();
            progressBarMotorbike = new ProgressBar();
            labelCar = new Label();
            labelBicycle = new Label();
            labelTruck = new Label();
            labelMotorbike = new Label();
            StartRaceButton = new Button();
            ResetRaceButton = new Button();
            labelRaceResult = new Label();
            raceTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // progressBarCar
            // 
            progressBarCar.Location = new Point(166, 209);
            progressBarCar.Name = "progressBarCar";
            progressBarCar.Size = new Size(446, 35);
            progressBarCar.TabIndex = 0;
            // 
            // progressBarBicycle
            // 
            progressBarBicycle.Location = new Point(166, 305);
            progressBarBicycle.Name = "progressBarBicycle";
            progressBarBicycle.Size = new Size(446, 35);
            progressBarBicycle.TabIndex = 1;
            // 
            // progressBarTruck
            // 
            progressBarTruck.Location = new Point(166, 410);
            progressBarTruck.Name = "progressBarTruck";
            progressBarTruck.Size = new Size(446, 36);
            progressBarTruck.TabIndex = 2;
            // 
            // progressBarMotorbike
            // 
            progressBarMotorbike.Location = new Point(166, 525);
            progressBarMotorbike.Name = "progressBarMotorbike";
            progressBarMotorbike.Size = new Size(446, 37);
            progressBarMotorbike.TabIndex = 3;
            // 
            // labelCar
            // 
            labelCar.AutoSize = true;
            labelCar.Location = new Point(166, 266);
            labelCar.Name = "labelCar";
            labelCar.Size = new Size(38, 15);
            labelCar.TabIndex = 4;
            labelCar.Text = "label1";
            // 
            // labelBicycle
            // 
            labelBicycle.AutoSize = true;
            labelBicycle.Location = new Point(166, 371);
            labelBicycle.Name = "labelBicycle";
            labelBicycle.Size = new Size(38, 15);
            labelBicycle.TabIndex = 5;
            labelBicycle.Text = "label2";
            // 
            // labelTruck
            // 
            labelTruck.AutoSize = true;
            labelTruck.Location = new Point(166, 481);
            labelTruck.Name = "labelTruck";
            labelTruck.Size = new Size(38, 15);
            labelTruck.TabIndex = 6;
            labelTruck.Text = "label3";
            // 
            // labelMotorbike
            // 
            labelMotorbike.AutoSize = true;
            labelMotorbike.Location = new Point(166, 587);
            labelMotorbike.Name = "labelMotorbike";
            labelMotorbike.Size = new Size(38, 15);
            labelMotorbike.TabIndex = 7;
            labelMotorbike.Text = "label4";
            // 
            // StartRaceButton
            // 
            StartRaceButton.Location = new Point(328, 643);
            StartRaceButton.Name = "StartRaceButton";
            StartRaceButton.Size = new Size(75, 23);
            StartRaceButton.TabIndex = 8;
            StartRaceButton.Text = "START";
            StartRaceButton.UseVisualStyleBackColor = true;
            StartRaceButton.Click += StartRaceButton_Click;
            // 
            // ResetRaceButton
            // 
            ResetRaceButton.Location = new Point(409, 643);
            ResetRaceButton.Name = "ResetRaceButton";
            ResetRaceButton.Size = new Size(75, 23);
            ResetRaceButton.TabIndex = 9;
            ResetRaceButton.Text = "RESET";
            ResetRaceButton.UseVisualStyleBackColor = true;
            ResetRaceButton.Click += ResetRaceButton_Click;
            // 
            // labelRaceResult
            // 
            labelRaceResult.AutoSize = true;
            labelRaceResult.Location = new Point(383, 705);
            labelRaceResult.Name = "labelRaceResult";
            labelRaceResult.Size = new Size(38, 15);
            labelRaceResult.TabIndex = 10;
            labelRaceResult.Text = "label1";
            // 
            // raceTimer
            // 
            raceTimer.Tick += raceTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._1000_F_523308678_jPNb5PjddaOB7xKcU44PIqTOYipmEZmw;
            ClientSize = new Size(799, 796);
            Controls.Add(labelRaceResult);
            Controls.Add(ResetRaceButton);
            Controls.Add(StartRaceButton);
            Controls.Add(labelMotorbike);
            Controls.Add(labelTruck);
            Controls.Add(labelBicycle);
            Controls.Add(labelCar);
            Controls.Add(progressBarMotorbike);
            Controls.Add(progressBarTruck);
            Controls.Add(progressBarBicycle);
            Controls.Add(progressBarCar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBarCar;
        private ProgressBar progressBarBicycle;
        private ProgressBar progressBarTruck;
        private ProgressBar progressBarMotorbike;
        private Label labelCar;
        private Label labelBicycle;
        private Label labelTruck;
        private Label labelMotorbike;
        private Button StartRaceButton;
        private Button ResetRaceButton;
        private Label labelRaceResult;
        private System.Windows.Forms.Timer raceTimer;
    }
}
