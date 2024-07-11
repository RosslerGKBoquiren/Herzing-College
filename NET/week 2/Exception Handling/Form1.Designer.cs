namespace Exception_Handling
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
            inputTextBox = new TextBox();
            runButton = new Button();
            MessageBox = new Label();
            label1 = new Label();
            btnClear = new Button();
            SuspendLayout();
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(104, 54);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(122, 23);
            inputTextBox.TabIndex = 0;
            // 
            // runButton
            // 
            runButton.Location = new Point(232, 54);
            runButton.Name = "runButton";
            runButton.Size = new Size(40, 21);
            runButton.TabIndex = 1;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += runButton_Click;
            // 
            // MessageBox
            // 
            MessageBox.AutoSize = true;
            MessageBox.Location = new Point(104, 106);
            MessageBox.Name = "MessageBox";
            MessageBox.Size = new Size(45, 15);
            MessageBox.TabIndex = 2;
            MessageBox.Text = "Result: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 36);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 3;
            label1.Text = "Enter an index (0 - 4): ";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(278, 54);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(43, 21);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 161);
            Controls.Add(btnClear);
            Controls.Add(label1);
            Controls.Add(MessageBox);
            Controls.Add(runButton);
            Controls.Add(inputTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputTextBox;
        private Button runButton;
        private Label MessageBox;
        private Label label1;
        private Button btnClear;
    }
}
