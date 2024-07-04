namespace Simple_Calculator
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
            txtFirstNumber = new TextBox();
            txtSecondNumber = new TextBox();
            btnAdd = new Button();
            btnSubtract = new Button();
            btnMultiply = new Button();
            btnDivide = new Button();
            lblResult = new Label();
            label1 = new Label();
            label2 = new Label();
            btnClear = new Button();
            SuspendLayout();
            // 
            // txtFirstNumber
            // 
            txtFirstNumber.Location = new Point(87, 46);
            txtFirstNumber.Name = "txtFirstNumber";
            txtFirstNumber.Size = new Size(100, 23);
            txtFirstNumber.TabIndex = 0;
            txtFirstNumber.Text = "Enter value 1:";
            // 
            // txtSecondNumber
            // 
            txtSecondNumber.Location = new Point(193, 46);
            txtSecondNumber.Name = "txtSecondNumber";
            txtSecondNumber.Size = new Size(100, 23);
            txtSecondNumber.TabIndex = 1;
            txtSecondNumber.Text = "Enter Value 2:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(112, 120);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSubtract
            // 
            btnSubtract.Location = new Point(193, 120);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new Size(75, 23);
            btnSubtract.TabIndex = 3;
            btnSubtract.Text = "Subtract";
            btnSubtract.UseVisualStyleBackColor = true;
            btnSubtract.Click += btnSubtract_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.Location = new Point(112, 149);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(75, 23);
            btnMultiply.TabIndex = 4;
            btnMultiply.Text = "Multiply";
            btnMultiply.UseVisualStyleBackColor = true;
            btnMultiply.Click += btnMultiply_Click;
            // 
            // btnDivide
            // 
            btnDivide.Location = new Point(193, 149);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(75, 23);
            btnDivide.TabIndex = 5;
            btnDivide.Text = "Divide";
            btnDivide.UseVisualStyleBackColor = true;
            btnDivide.Click += btnDivide_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(112, 210);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(42, 15);
            lblResult.TabIndex = 6;
            lblResult.Text = "Result:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 7;
            label1.Text = "#1 Enter Values";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 92);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 8;
            label2.Text = "#2 Select Operation";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(311, 46);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(46, 23);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
            Controls.Add(btnClear);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblResult);
            Controls.Add(btnDivide);
            Controls.Add(btnMultiply);
            Controls.Add(btnSubtract);
            Controls.Add(btnAdd);
            Controls.Add(txtSecondNumber);
            Controls.Add(txtFirstNumber);
            Name = "Form1";
            Text = "Simple Calculator";
            
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private TextBox txtFirstNumber;
        private TextBox txtSecondNumber;
        private Button btnAdd;
        private Button btnSubtract;
        private Button btnMultiply;
        private Button btnDivide;
        private Label lblResult;
        private Label label1;
        private Label label2;
        private Button btnClear;
    }
}