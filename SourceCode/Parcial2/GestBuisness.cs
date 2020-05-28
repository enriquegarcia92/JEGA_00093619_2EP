using System;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class GestBuisness : UserControl
    {
        public GestBuisness()
        {
            InitializeComponent();
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

                    ConnectionDB.ExecuteNonQuery($"INSERT INTO BUSINESS(name, description)" +
                                                 $"VALUES('{textBox1.Text}', '{textBox2.Text}')");

                    MessageBox.Show("Se ha registrado el negocio");
                    

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"DELETE FROM BUSINESS WHERE name = '{textBox3.Text}'");


                MessageBox.Show("Se ha eliminado el negocio");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}