using System;
using System.Windows.Forms;

namespace Family_Tree
{
    public partial class Form1 : Form
    {
        private Family family = new Family();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxParent.Items.Add("None");
            comboBoxParent.SelectedIndex = 0;

            // Add initial data
            AddInitialData();
            DisplayFamily();
        }

        private void AddInitialData()
        {
            // Create initial family members
            Person john = new Person { ID = 123, Name = "John", Age = 35, Parent = null };
            Person jane = new Person { ID = 124, Name = "Jane", Age = 28, Parent = null };
            Person mike = new Person { ID = 125, Name = "Mike", Age = 62, Parent = null };
            Person lucy = new Person { ID = 126, Name = "Lucy", Age = 10, Parent = john };

            // Add them to the family
            family.AddMember(john);
            family.AddMember(jane);
            family.AddMember(mike);
            family.AddMember(lucy);

            // Add their IDs to the comboBoxParent for selecting parents
            comboBoxParent.Items.Add(john.ID.ToString());
            comboBoxParent.Items.Add(jane.ID.ToString());
            comboBoxParent.Items.Add(mike.ID.ToString());
            comboBoxParent.Items.Add(lucy.ID.ToString());
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBoxID.Text);

                // Check if the ID already exists
                if (family.GetPersonById(id) != null)
                {
                    throw new Exception("A person with this ID already exists.");
                }

                string name = textBoxName.Text;
                int age = int.Parse(textBoxAge.Text);

                // Find the selected parent if not "None"
                Person parent = comboBoxParent.SelectedItem.ToString() == "None" ? null : family.GetPersonById(int.Parse(comboBoxParent.SelectedItem.ToString()));

                Person newPerson = new Person { ID = id, Name = name, Age = age, Parent = parent };
                family.AddMember(newPerson);

                // Add the new person's ID to the ComboBox for selecting parents
                comboBoxParent.Items.Add(newPerson.ID.ToString());

                // Reset the ComboBox to "None"
                comboBoxParent.SelectedIndex = 0;

                // Update the ListBox to display the updated list of family members
                DisplayFamily();

                // Display success message
                labelMessage.Text = "Person added successfully.";
                labelError.Text = string.Empty; // Clear any previous error messages
            }
            catch (FormatException)
            {
                labelError.Text = "Please enter valid data for ID and Age.";
                labelMessage.Text = string.Empty; // Clear any previous success messages
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
                labelMessage.Text = string.Empty; // Clear any previous success messages
            }
        }

        private void DisplayFamily()
        {
            listBoxFamily.Items.Clear();

            listBoxFamily.Items.Add("ID".PadRight(10) + "Name".PadRight(20) + "Age".PadRight(10) + "Parent".PadRight(20));
            listBoxFamily.Items.Add(new string('-', 60));

            
            foreach (var person in family)
            {
                listBoxFamily.Items.Add(person.DisplayInfo());
            }
        }
    }
}


