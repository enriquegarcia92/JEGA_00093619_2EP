using System;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class ViewAllOrders : UserControl
    {
        public ViewAllOrders()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address "+
                "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au "+
                    "WHERE ao.idProduct = pr.idProduct "+
                "AND ao.idAddress = ad.idAddress "+
                "AND ad.idUser = au.idUser;");
                   
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