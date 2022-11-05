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
    public partial class FrmGiangVien : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string sql, constr;
        public FrmGiangVien()
        {
            InitializeComponent();
        }

        private void FrmGiangVien_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05;" +
                                        "Initial Catalog=QLTN;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select * from tblGiangVien order by MaGV";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
