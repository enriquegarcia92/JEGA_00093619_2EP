using System;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class View_My_Order : UserControl
    {
        public View_My_Order(String username)
        {
            this.name = username;
            InitializeComponent();
        }
        
        private String name;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = $"SELECT idUser FROM APPUSER WHERE username = '{name}'";

                var dt2 = ConnectionDB.ExecuteQuery(Query);
                var dr = dt2.Rows[0];
                var idUser = Convert.ToInt32(dr[0].ToString());
                var dt = ConnectionDB.ExecuteQuery($"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address "+
                "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au "+
                    "WHERE ao.idProduct = pr.idProduct "+
                "AND ao.idAddress = ad.idAddress "+
                "AND ad.idUser = au.idUser "+
                $"AND au.idUser = '{idUser}'");
                   
                dataGridView1.DataSource = dt;
                MessageBox.Show("Datos obtenidos exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema");
            }
        }
    }
}