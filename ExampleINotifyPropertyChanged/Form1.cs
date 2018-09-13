using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExampleINotifyPropertyChanged
{
    // This form demonstrates using a BindingSource to bind  
    // a list to a DataGridView control. The list does not  
    // raise change notifications. However the DemoCustomer type   
    // in the list does.
    public partial class Form1 : Form
    {
        // This button causes the value of a list element to be changed.  
        private Button buttonChangeItem = new Button();

        // Field for new customer's values.
        private TextBox textBoxCustomerName = new TextBox();

        // Field for new customer's values.
        private TextBox textBoxCustomerPhone = new TextBox();

        // This DataGridView control displays the contents of the list.  
        private DataGridView dataGridViewCustomer = new DataGridView();

        // This BindingSource binds the list to the DataGridView control.  
        private BindingSource bindingSourceCustomer = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            // Set up the textBoxCustomerName
            textBoxCustomerName.Text = @"New Name";
            textBoxCustomerName.Dock = DockStyle.Bottom;
            Controls.Add(textBoxCustomerName);

            // Set up the textBoxCustomerPhone
            textBoxCustomerPhone.Text = @"(111) 111-2222";
            textBoxCustomerPhone.Dock = DockStyle.Bottom;
            Controls.Add(textBoxCustomerPhone);

            // Set up the buttonChangeItem.
            buttonChangeItem.Text = @"Change item";
            buttonChangeItem.Dock = DockStyle.Bottom;
            buttonChangeItem.Click += new EventHandler(changeItemBtn_Click);
            Controls.Add(buttonChangeItem);

            // Set up the dataGridViewCustomer
            dataGridViewCustomer.Dock = DockStyle.Fill;
            Controls.Add(dataGridViewCustomer);

            Size = new Size(400, 200);
            buttonChangeItem.Select();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create and populate the list of DemoCustomer objects  
            // which will supply data to the DataGridView.
            var customerList = new BindingList<DemoCustomer>
            {
                DemoCustomer.CreateNewCustomer(),
                DemoCustomer.CreateNewCustomer(),
                DemoCustomer.CreateNewCustomer()
            };

            // Bind the list to the BindingSource.
            bindingSourceCustomer.DataSource = customerList;

            // Attach the BindingSource to the DataGridView.
            dataGridViewCustomer.DataSource = bindingSourceCustomer;
        }

        // Change the value of the CompanyName property for the first   
        // item in the list when the "Change Item" button is clicked.
        private void changeItemBtn_Click(object sender, EventArgs e)
        {
            // Get a reference to the list from the BindingSource.
            var customerList = bindingSourceCustomer.DataSource as BindingList<DemoCustomer>;

            // Change the value of the CompanyName property for the first item in the list.
            customerList[dataGridViewCustomer.CurrentCell.RowIndex].CustomerName = textBoxCustomerName.Text;
            customerList[dataGridViewCustomer.CurrentCell.RowIndex].PhoneNumber = textBoxCustomerPhone.Text;
        }
    }
}
