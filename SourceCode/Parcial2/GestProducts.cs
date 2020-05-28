using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class GestProducts : UserControl
    {
        public GestProducts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                try
                {
                    string Query = $"SELECT idBusiness FROM BUSINESS WHERE name = '{comboBox1.SelectedItem.ToString()}'";

                    var dt = ConnectionDB.ExecuteQuery(Query);
                    var dr = dt.Rows[0];
                    var idBusiness = Convert.ToInt32(dr[0].ToString());
                    
                    string nonQuery = $"INSERT INTO PRODUCT(idBusiness, name) VALUES(" +
                                      $"{idBusiness}," +
                                      $"'{textBox1.Text}')";
                    
                    ConnectionDB.ExecuteNonQuery(nonQuery);

                    MessageBox.Show("Se añadio el producto");
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"DELETE FROM PRODUCT WHERE name = '{textBox2.Text}'");


                MessageBox.Show("Se ha eliminado el producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GestProducts_Load(object sender, EventArgs e)
        {
            var negocios = ConnectionDB.ExecuteQuery("SELECT name FROM BUSINESS");
            var combobusiness = new List<string>();

            foreach (DataRow dr in negocios.Rows)
            {
                combobusiness.Add(dr[0].ToString());
            }

            comboBox1.DataSource = combobusiness;
        }
    }
}