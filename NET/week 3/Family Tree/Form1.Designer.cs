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
            SuspendLayout();
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(636, 102);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(100, 23);
            textBoxID.TabIndex = 0;
            textBoxID.Text = "ID";
            // 
            // textBoxAge
            // 
            textBoxAge.Location = new Point(636, 188);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new Size(100, 23);
            textBoxAge.TabIndex = 1;
            textBoxAge.Text = "Age";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(636, 144);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 2;
            textBoxName.Text = "Name";
            // 
            // comboBoxParent
            // 
            comboBoxParent.FormattingEnabled = true;
            comboBoxParent.Location = new Point(636, 235);
            comboBoxParent.Name = "comboBoxParent";
            comboBoxParent.Size = new Size(100, 23);
            comboBoxParent.TabIndex = 3;
            // 
            // buttonAddPerson
            // 
            buttonAddPerson.Location = new Point(636, 280);
            buttonAddPerson.Name = "buttonAddPerson";
            buttonAddPerson.Size = new Size(100, 23);
            buttonAddPerson.TabIndex = 4;
            buttonAddPerson.Text = "ADD";
            buttonAddPerson.UseVisualStyleBackColor = true;
            buttonAddPerson.Click += buttonAddPerson_Click;
            // 
            // listBoxFamily
            // 
            listBoxFamily.FormattingEnabled = true;
            listBoxFamily.ItemHeight = 15;
            listBoxFamily.Location = new Point(140, 102);
            listBoxFamily.Name = "listBoxFamily";
            listBoxFamily.Size = new Size(210, 124);
            listBoxFamily.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxFamily);
            Controls.Add(buttonAddPerson);
            Controls.Add(comboBoxParent);
            Controls.Add(textBoxName);
            Controls.Add(textBoxAge);
            Controls.Add(textBoxID);
            Name = "Form1";
            Text = "Form1";
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
    }
}
