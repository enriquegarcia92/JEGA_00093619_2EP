using System;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class GestAddress : UserControl
    {
        public GestAddress(String username)
        {
            this.name = username;
            InitializeComponent();
            textBox1.Text = name;
        }

        private String name;

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
                    string Query = $"SELECT idUser FROM APPUSER WHERE username = '{textBox1.Text}'";

                    var dt = ConnectionDB.ExecuteQuery(Query);
                    var dr = dt.Rows[0];
                    var idUser = Convert.ToInt32(dr[0].ToString());
                    ConnectionDB.ExecuteNonQuery($"INSERT INTO ADDRESS(idUser, address)" +
                                                 $"VALUES('{idUser}', '{textBox2.Text}')");

                    MessageBox.Show("Se ha registrado el la dirección");
                    

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                    string Query = $"SELECT idUser FROM APPUSER WHERE username = '{textBox1.Text}'";

                    var dt = ConnectionDB.ExecuteQuery(Query);
                    var dr = dt.Rows[0];
                    var idUser = Convert.ToInt32(dr[0].ToString());
                    ConnectionDB.ExecuteNonQuery($"UPDATE ADDRESS SET address = '{textBox2.Text}' WHERE idAddress = '{idUser}'");

                    MessageBox.Show("Se ha actualizado la dirección");
                    

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = $"SELECT idUser FROM APPUSER WHERE username = '{textBox1.Text}'";

                var dt = ConnectionDB.ExecuteQuery(Query);
                var dr = dt.Rows[0];
                var idUser = Convert.ToInt32(dr[0].ToString());
                ConnectionDB.ExecuteNonQuery($"DELETE FROM ADDRESS WHERE idUser = '{idUser}'");


                MessageBox.Show("Se han eliminado todas las direcciónes asosiadas");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void GestAddress_Load(object sender, EventArgs e)
        {
            try
            {
                string Query = $"SELECT idUser FROM APPUSER WHERE username = '{name}'";

                var dt2 = ConnectionDB.ExecuteQuery(Query);
                var dr = dt2.Rows[0];
                var idUser = Convert.ToInt32(dr[0].ToString());
                var dt = ConnectionDB.ExecuteQuery(
                    $"SELECT ad.idAddress, ad.address FROM ADDRESS ad WHERE idUser ='{idUser}'");
                
                   
                dataGridView1.DataSource = dt;
                MessageBox.Show("Datos actualizados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }
    }
    }
