using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class GestOrder : UserControl
    {
        public GestOrder(String username)
        {
            this.name = username;
            InitializeComponent();
        }

        private String name;

        private void GestOrder_Load(object sender, EventArgs e)
        {
            string Query2 = $"SELECT idUser FROM APPUSER WHERE username ='{name}'";
            var dt2 = ConnectionDB.ExecuteQuery(Query2);
            var dr3 = dt2.Rows[0];
            var idUser = Convert.ToInt32(dr3[0].ToString());
            
            var direccion = ConnectionDB.ExecuteQuery($"SELECT address FROM ADDRESS WHERE idUser='{idUser}' ");
            var comboad = new List<string>();

            foreach (DataRow dr in direccion.Rows)
            {
                comboad.Add(dr[0].ToString());
            }

            comboBox3.DataSource = comboad;
            var negocio = ConnectionDB.ExecuteQuery("SELECT name FROM BUSINESS");
            var comboneg = new List<string>();

            foreach (DataRow dr in negocio.Rows)
            {
                comboneg.Add(dr[0].ToString());
            }

            comboBox1.DataSource = comboneg;
           
            
            
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Query = $"SELECT idBusiness FROM BUSINESS WHERE name = '{comboBox1.SelectedItem.ToString()}'";
            var dt = ConnectionDB.ExecuteQuery(Query);
            var dr2 = dt.Rows[0];
            var idBusiness = Convert.ToInt32(dr2[0].ToString());
            var product = ConnectionDB.ExecuteQuery($"SELECT name FROM PRODUCT WHERE idBusiness='{idBusiness}'  ");
            var comboprod = new List<string>();

            foreach (DataRow dr in product.Rows)
            {
                comboprod.Add(dr[0].ToString());
            }

            comboBox2.DataSource = comboprod;
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
                try
                {
                    string selectorprod = $"SELECT idProduct FROM PRODUCT WHERE name='{comboBox2.SelectedItem.ToString()}'";
                    var dataprod = ConnectionDB.ExecuteQuery(selectorprod);
                    var rowprod = dataprod.Rows[0];
                    var idProduct = Convert.ToInt32(rowprod[0].ToString());
                    
                    string selectordirec = $"SELECT idAddress FROM ADDRESS WHERE address = '{comboBox3.SelectedItem.ToString()}'";
                    var datadirec = ConnectionDB.ExecuteQuery(selectordirec);
                    var rowdirec = datadirec.Rows[0];
                    var idAdress = Convert.ToInt32(rowdirec[0].ToString());
                    string nonQuery = $"INSERT INTO APPORDER(createDate, idProduct, idAddress) VALUES(" +
                                      $"'{dateTimePicker1.Value}'," +
                                      $"'{idProduct}','{idAdress}')";
                    
                    ConnectionDB.ExecuteNonQuery(nonQuery);

                    MessageBox.Show("Se añadio realizo la orden");
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB.ExecuteNonQuery($"DELETE FROM APPORDER WHERE idOrder = '{textBox1.Text}'");


                MessageBox.Show("Se ha cancelado la orden");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}