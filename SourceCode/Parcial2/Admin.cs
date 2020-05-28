using System;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class Admin : Form
    {
        private UserControl current = null;
        public Admin(String username)
        {

            this.username = username;
            InitializeComponent();
            current = addUser1;
            label1.Text = "Bienvenido Administrador " + username;
        }

        private String username;
        

        private void Admin_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new AddUser();
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,8);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new View_user();
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,8);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new GestBuisness();
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,8);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new GestProducts();
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,8);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new ViewAllOrders();
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new ManagePassword(username);
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,8);
        }
    }
}