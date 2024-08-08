namespace Fitness_Center_Application
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textName = new TextBox();
            textAge = new TextBox();
            radioMale = new RadioButton();
            radioFemale = new RadioButton();
            labelName = new Label();
            labelAge = new Label();
            labelGender = new Label();
            labelBodyFat = new Label();
            textHeight = new TextBox();
            textWeight = new TextBox();
            labelHeight = new Label();
            labelFtIn = new Label();
            labelWeight = new Label();
            labelLbs = new Label();
            labelErrorMessage = new Label();
            btnCalculate = new Button();
            lblBmi = new Label();
            labelCategory = new Label();
            labelRisk = new Label();
            pictureBox = new PictureBox();
            btnReset = new Button();
            labelResults = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // textName
            // 
            textName.Location = new Point(82, 27);
            textName.Name = "textName";
            textName.Size = new Size(119, 23);
            textName.TabIndex = 0;
            // 
            // textAge
            // 
            textAge.Location = new Point(82, 56);
            textAge.Name = "textAge";
            textAge.Size = new Size(119, 23);
            textAge.TabIndex = 1;
            // 
            // radioMale
            // 
            radioMale.AutoSize = true;
            radioMale.BackColor = SystemColors.WindowText;
            radioMale.Font = new Font("Arial Rounded MT Bold", 9F);
            radioMale.ForeColor = SystemColors.ButtonFace;
            radioMale.Location = new Point(81, 89);
            radioMale.Name = "radioMale";
            radioMale.Size = new Size(52, 18);
            radioMale.TabIndex = 5;
            radioMale.TabStop = true;
            radioMale.Text = "Male";
            radioMale.UseVisualStyleBackColor = false;
            // 
            // radioFemale
            // 
            radioFemale.AutoSize = true;
            radioFemale.BackColor = SystemColors.WindowText;
            radioFemale.Font = new Font("Arial Rounded MT Bold", 9F);
            radioFemale.ForeColor = SystemColors.ButtonFace;
            radioFemale.Location = new Point(138, 89);
            radioFemale.Name = "radioFemale";
            radioFemale.Size = new Size(67, 18);
            radioFemale.TabIndex = 6;
            radioFemale.TabStop = true;
            radioFemale.Text = "Female";
            radioFemale.UseVisualStyleBackColor = false;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = SystemColors.WindowText;
            labelName.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelName.ForeColor = SystemColors.ButtonFace;
            labelName.Location = new Point(34, 30);
            labelName.Name = "labelName";
            labelName.Size = new Size(45, 14);
            labelName.TabIndex = 7;
            labelName.Text = "Name:";
            // 
            // labelAge
            // 
            labelAge.AutoSize = true;
            labelAge.BackColor = SystemColors.WindowText;
            labelAge.Font = new Font("Arial Rounded MT Bold", 9F);
            labelAge.ForeColor = SystemColors.ButtonFace;
            labelAge.Location = new Point(44, 59);
            labelAge.Name = "labelAge";
            labelAge.Size = new Size(35, 14);
            labelAge.TabIndex = 8;
            labelAge.Text = "Age:";
            // 
            // labelGender
            // 
            labelGender.AutoSize = true;
            labelGender.BackColor = SystemColors.WindowText;
            labelGender.Font = new Font("Arial Rounded MT Bold", 9F);
            labelGender.ForeColor = SystemColors.ButtonFace;
            labelGender.Location = new Point(27, 91);
            labelGender.Name = "labelGender";
            labelGender.Size = new Size(55, 14);
            labelGender.TabIndex = 9;
            labelGender.Text = "Gender:";
            // 
            // labelBodyFat
            // 
            labelBodyFat.AutoSize = true;
            labelBodyFat.BackColor = SystemColors.WindowText;
            labelBodyFat.Font = new Font("Arial Rounded MT Bold", 9F);
            labelBodyFat.ForeColor = SystemColors.ButtonFace;
            labelBodyFat.Location = new Point(283, 69);
            labelBodyFat.Name = "labelBodyFat";
            labelBodyFat.Size = new Size(63, 14);
            labelBodyFat.TabIndex = 11;
            labelBodyFat.Text = "Body Fat:";
            // 
            // textHeight
            // 
            textHeight.Location = new Point(82, 120);
            textHeight.Name = "textHeight";
            textHeight.Size = new Size(118, 23);
            textHeight.TabIndex = 12;
            // 
            // textWeight
            // 
            textWeight.Location = new Point(82, 149);
            textWeight.Name = "textWeight";
            textWeight.Size = new Size(120, 23);
            textWeight.TabIndex = 14;
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.BackColor = SystemColors.WindowText;
            labelHeight.Font = new Font("Arial Rounded MT Bold", 9F);
            labelHeight.ForeColor = SystemColors.ButtonFace;
            labelHeight.Location = new Point(27, 123);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(49, 14);
            labelHeight.TabIndex = 16;
            labelHeight.Text = "Height:";
            // 
            // labelFtIn
            // 
            labelFtIn.AutoSize = true;
            labelFtIn.BackColor = SystemColors.WindowText;
            labelFtIn.Font = new Font("Arial Rounded MT Bold", 9F);
            labelFtIn.ForeColor = SystemColors.ButtonFace;
            labelFtIn.Location = new Point(206, 123);
            labelFtIn.Name = "labelFtIn";
            labelFtIn.Size = new Size(45, 14);
            labelFtIn.TabIndex = 17;
            labelFtIn.Text = "FT . IN";
            // 
            // labelWeight
            // 
            labelWeight.AutoSize = true;
            labelWeight.BackColor = SystemColors.WindowText;
            labelWeight.Font = new Font("Arial Rounded MT Bold", 9F);
            labelWeight.ForeColor = SystemColors.ButtonFace;
            labelWeight.Location = new Point(25, 152);
            labelWeight.Name = "labelWeight";
            labelWeight.Size = new Size(51, 14);
            labelWeight.TabIndex = 18;
            labelWeight.Text = "Weight:";
            // 
            // labelLbs
            // 
            labelLbs.AutoSize = true;
            labelLbs.BackColor = SystemColors.WindowText;
            labelLbs.Font = new Font("Arial Rounded MT Bold", 9F);
            labelLbs.ForeColor = SystemColors.ButtonFace;
            labelLbs.Location = new Point(208, 152);
            labelLbs.Name = "labelLbs";
            labelLbs.Size = new Size(31, 14);
            labelLbs.TabIndex = 19;
            labelLbs.Text = "LBS";
            // 
            // labelErrorMessage
            // 
            labelErrorMessage.AutoSize = true;
            labelErrorMessage.Location = new Point(27, 258);
            labelErrorMessage.Name = "labelErrorMessage";
            labelErrorMessage.Size = new Size(0, 15);
            labelErrorMessage.TabIndex = 20;
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.ForestGreen;
            btnCalculate.BackgroundImageLayout = ImageLayout.Center;
            btnCalculate.FlatStyle = FlatStyle.Popup;
            btnCalculate.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCalculate.ForeColor = SystemColors.ButtonFace;
            btnCalculate.Location = new Point(83, 178);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(118, 23);
            btnCalculate.TabIndex = 21;
            btnCalculate.Text = "CALCULATE";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lblBmi
            // 
            lblBmi.AutoSize = true;
            lblBmi.BackColor = SystemColors.WindowText;
            lblBmi.Font = new Font("Arial Rounded MT Bold", 9F);
            lblBmi.ForeColor = SystemColors.ButtonFace;
            lblBmi.Location = new Point(283, 43);
            lblBmi.Name = "lblBmi";
            lblBmi.Size = new Size(34, 14);
            lblBmi.TabIndex = 22;
            lblBmi.Text = "BMI:";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.BackColor = SystemColors.WindowText;
            labelCategory.Font = new Font("Arial Rounded MT Bold", 9F);
            labelCategory.ForeColor = SystemColors.ButtonFace;
            labelCategory.Location = new Point(283, 93);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(68, 14);
            labelCategory.TabIndex = 23;
            labelCategory.Text = "Category: ";
            // 
            // labelRisk
            // 
            labelRisk.AutoSize = true;
            labelRisk.BackColor = SystemColors.WindowText;
            labelRisk.Font = new Font("Arial Rounded MT Bold", 9F);
            labelRisk.ForeColor = SystemColors.ButtonFace;
            labelRisk.Location = new Point(283, 119);
            labelRisk.Name = "labelRisk";
            labelRisk.Size = new Size(37, 14);
            labelRisk.TabIndex = 24;
            labelRisk.Text = "Risk:";
            // 
            // pictureBox
            // 
            pictureBox.BackColor = SystemColors.WindowText;
            pictureBox.Location = new Point(283, 140);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(130, 159);
            pictureBox.TabIndex = 25;
            pictureBox.TabStop = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = SystemColors.Desktop;
            btnReset.BackgroundImageLayout = ImageLayout.Center;
            btnReset.FlatStyle = FlatStyle.Popup;
            btnReset.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = SystemColors.ButtonFace;
            btnReset.Location = new Point(83, 207);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(117, 23);
            btnReset.TabIndex = 26;
            btnReset.Text = "RESET";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.BackColor = SystemColors.WindowText;
            labelResults.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelResults.ForeColor = SystemColors.ButtonFace;
            labelResults.Location = new Point(284, 19);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(0, 14);
            labelResults.TabIndex = 27;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(455, 311);
            Controls.Add(labelResults);
            Controls.Add(btnReset);
            Controls.Add(pictureBox);
            Controls.Add(labelRisk);
            Controls.Add(labelCategory);
            Controls.Add(lblBmi);
            Controls.Add(btnCalculate);
            Controls.Add(labelErrorMessage);
            Controls.Add(labelLbs);
            Controls.Add(labelWeight);
            Controls.Add(labelFtIn);
            Controls.Add(labelHeight);
            Controls.Add(textWeight);
            Controls.Add(textHeight);
            Controls.Add(labelBodyFat);
            Controls.Add(labelGender);
            Controls.Add(labelAge);
            Controls.Add(labelName);
            Controls.Add(radioFemale);
            Controls.Add(radioMale);
            Controls.Add(textAge);
            Controls.Add(textName);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textName;
        private TextBox textAge;
        private TextBox textBox4;
        private TextBox textBox5;
        private RadioButton radioMale;
        private RadioButton radioFemale;
        private Label labelName;
        private Label labelAge;
        private Label labelGender;
        private Label label3;
        private Label labelBodyFat;
        private TextBox textHeight;
        private TextBox textWeight;
        private Label labelHeight;
        private Label labelFtIn;
        private Label labelWeight;
        private Label labelLbs;
        private Label labelErrorMessage;
        private Button btnCalculate;
        private object labelBMI;
        private Label lblBmi;
        private Label labelCategory;
        private Label labelRisk;
        private PictureBox pictureBox;
        private Button btnReset;
        private Label labelResults;
    }
}
