using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTN
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //conn.Close();
            /*constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05;" +
               "Initial Catalog=Test;Integrated Security=True;";
            if (conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = constr;
                conn.Open();
            }*/
        }
    }
}
