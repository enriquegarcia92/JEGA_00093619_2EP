using System;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class Usuario : Form
    {
        private UserControl current = null;
        public Usuario(String username)
        {
            this.nombre = username;
            InitializeComponent();
            current = null;
            label1.Text = "Bienvenido a hugo "+username;
        }

        public String nombre;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new GestOrder(nombre);
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,7);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new ManagePassword(nombre);
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,7);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new GestAddress(nombre);
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Remove(current);
            current = new View_My_Order(nombre);
            current.Dock=DockStyle.Fill;
            current.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.Controls.Add(current,1,0);
            tableLayoutPanel1.SetRowSpan(current,7);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}