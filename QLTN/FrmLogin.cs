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
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string constr, r, sql, username;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton ckd = sender as RadioButton;
            if (ckd.Checked)
                r = ckd.Text.ToString();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            constr = "Data Source = DESKTOP-6H5PSI2\\SQLEXPRESS05; Initial Catalog = QLTN; Integrated Security = True;";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "select *from tblTaiKhoan where TenDN=N'" + txtAcc.Text + "' and MatKhau='"
                + txtPass.Text + "' and Quyen=N'" + r + "'";

            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                username = dt.Rows[0][1].ToString();
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                if (r == "Quản lý")
                {
                    FrmTrangChu f = new FrmTrangChu(username);
                    f.Show();
                }
                if (r == "Thí sinh")
                {
                    FrmVaoThi f2 = new FrmVaoThi(username);
                    f2.Show();
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập sai, vui lòng thử lại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAcc.Clear();
                txtPass.Clear();
                txtAcc.Focus();
            }
        }
    }
}
