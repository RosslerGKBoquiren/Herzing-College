namespace Family_Tree
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
            textBoxID = new TextBox();
            textBoxAge = new TextBox();
            textBoxName = new TextBox();
            comboBoxParent = new ComboBox();
            buttonAddPerson = new Button();
            listBoxFamily = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            labelError = new Label();
            labelMessage = new Label();
            SuspendLayout();
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(461, 20);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(100, 23);
            textBoxID.TabIndex = 0;
            // 
            // textBoxAge
            // 
            textBoxAge.Location = new Point(461, 106);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new Size(100, 23);
            textBoxAge.TabIndex = 1;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(461, 62);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            // 
            // comboBoxParent
            // 
            comboBoxParent.FormattingEnabled = true;
            comboBoxParent.Location = new Point(461, 155);
            comboBoxParent.Name = "comboBoxParent";
            comboBoxParent.Size = new Size(100, 23);
            comboBoxParent.TabIndex = 3;
            comboBoxParent.Text = "----- Select -----";
            // 
            // buttonAddPerson
            // 
            buttonAddPerson.Location = new Point(461, 195);
            buttonAddPerson.Name = "buttonAddPerson";
            buttonAddPerson.Size = new Size(100, 59);
            buttonAddPerson.TabIndex = 4;
            buttonAddPerson.Text = "ADD";
            buttonAddPerson.UseVisualStyleBackColor = true;
            buttonAddPerson.Click += buttonAddPerson_Click;
            // 
            // listBoxFamily
            // 
            listBoxFamily.FormattingEnabled = true;
            listBoxFamily.ItemHeight = 15;
            listBoxFamily.Location = new Point(21, 20);
            listBoxFamily.Name = "listBoxFamily";
            listBoxFamily.Size = new Size(352, 229);
            listBoxFamily.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(412, 23);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 6;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(412, 65);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 7;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(412, 109);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 8;
            label3.Text = "Age:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(412, 158);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 9;
            label4.Text = "Parent:";
            // 
            // labelError
            // 
            labelError.AutoSize = true;
            labelError.Location = new Point(21, 274);
            labelError.Name = "labelError";
            labelError.Size = new Size(0, 15);
            labelError.TabIndex = 10;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(21, 274);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(0, 15);
            labelMessage.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 323);
            Controls.Add(labelMessage);
            Controls.Add(labelError);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxFamily);
            Controls.Add(buttonAddPerson);
            Controls.Add(comboBoxParent);
            Controls.Add(textBoxName);
            Controls.Add(textBoxAge);
            Controls.Add(textBoxID);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxID;
        private TextBox textBoxAge;
        private TextBox textBoxName;
        private ComboBox comboBoxParent;
        private Button buttonAddPerson;
        private ListBox listBoxFamily;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelError;
        private Label labelMessage;
    }
}
