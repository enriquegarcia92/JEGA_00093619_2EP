using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Parcial2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                try
                {
                    var dt = ConnectionDB.ExecuteQuery(
                        $"SELECT userType FROM APPUSER WHERE username='{textBox1.Text}' AND password='{textBox2.Text}'");
                    var dr = dt.Rows[0];
                    var tipo = Convert.ToBoolean(dr[0].ToString());
                    if (tipo)
                    {
                        MessageBox.Show("Sesión iniciada como Administrador");
                        this.Hide();
                        new Admin(textBox1.Text).Show();
                    }else
                    {
                        MessageBox.Show("Sesión iniciada como Cliente");

                        this.Hide();
                        new Usuario(textBox1.Text).Show();
                        
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos");
                }
            }
           
            
        }
    }
}