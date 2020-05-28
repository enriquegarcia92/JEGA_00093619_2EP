using System;
using System.Windows.Forms;

namespace Parcial2
{
    public partial class View_user : UserControl
    {
        public View_user()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery("SELECT * FROM APPUSER");
                   
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