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
    public partial class FrmCauHoi : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string sql, constr;
        public FrmCauHoi()
        {
            InitializeComponent();
        }

        private void FrmCauHoi_Load(object sender, EventArgs e)
        {
            constr = "Data Source = DESKTOP-5PV9M2M\\SQLEXPRESS; Initial Catalog = QLTN; Integrated Security = True;";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select * from tblCauHoi order by MaCH";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
    }
}
