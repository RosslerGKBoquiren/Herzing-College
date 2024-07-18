namespace Family_Tree
{
    public partial class Form1 : Form
    {
        private Family family = new Family();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxID.Text);
            string name = textBoxName.Text;
            int age = int.Parse(textBoxAge.Text);
            Person parent = comboBoxParent.SelectedItem.ToString() == "None" ? null : family.GetPersonById(int.Parse(comboBoxParent.SelectedItem.ToString()));

            Person newPerson = new Person { ID = id, Name = name, Age = age, Parent = parent };
            family.AddMember(newPerson);

            comboBoxParent.Items.Add(newPerson.ID.ToString());
            DisplayFamily();
        }

        private void DisplayFamily()
        {
            listBoxFamily.Items.Clear();
            foreach (var person in family)
            {
                listBoxFamily.Items.Add(person.DisplayInfo());
            }
        }

        
    }
}
