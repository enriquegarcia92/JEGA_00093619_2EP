using System;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class ManagePassword : UserControl
    {
        public ManagePassword(String username)
        {
            this.nombre = username;
            InitializeComponent();
            textBox1.Text = nombre;
        }

        private String nombre;
        private void button1_Click(object sender, EventArgs e)
        {
            if (
                textBox1.Text.Equals("")||
                textBox2.Text.Equals("")||
                textBox3.Text.Equals("")
                
                )
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                try
                {

                    ConnectionDB.ExecuteNonQuery($"UPDATE APPUSER SET password = '{textBox3.Text}' WHERE username='{textBox1.Text}' AND password ='{textBox2.Text}'");
                    

                    MessageBox.Show("Se ha cambiado la contraseña");
                    

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}