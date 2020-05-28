using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class AddUser : UserControl
    {
        public AddUser()
        {
            InitializeComponent();
            comboBox1.DataSource = new List<String> {"Admin","Cliente"};
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
                    
                    
                   
                        bool tipo = true;
                        if (comboBox1.SelectedItem.ToString().Equals("Admin"))
                        {
                            tipo = true;

                        }
                        else if (comboBox1.SelectedItem.ToString().Equals("Cliente"))
                        {
                            tipo = false;
                        }

                        ConnectionDB.ExecuteNonQuery($"INSERT INTO APPUSER(fullname, username, password, userType)" +
                                                     $"VALUES('{textBox1.Text}', '{textBox2.Text}', '{textBox2.Text}','{tipo}')");

                        MessageBox.Show("Se ha registrado el usuario");
                    

                }
                catch (AlreadyExistUserException exp)
                {
                    MessageBox.Show(exp.Message);
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
                ConnectionDB.ExecuteNonQuery($"DELETE FROM APPUSER WHERE username = '{textBox4.Text}'");


                MessageBox.Show("Se ha eliminado el usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}