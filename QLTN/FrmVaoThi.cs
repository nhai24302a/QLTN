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
    public partial class FrmVaoThi : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable dtm = new DataTable();
        string constr, sql, tenuser;
        int h, m, s;

        private void btnThi_Click(object sender, EventArgs e)
        {
            FrmBaiThiTN f = new FrmBaiThiTN(h,m,s);
            f.Show();
        }

        private void FrmVaoThi_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05;" +
              "Initial Catalog=QLTN;Integrated Security=True;";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "select  tblCaThi.TenCa, tblCaThi.NgayThi, tblCaThi.TGBD, tblCaThi.TGKT, tblThiSinh.HoTen, tblThiSinh.NgaySinh, tblLop.TenLop, tblMonThi.TenMon, tblMonThi.SoCau, tblMonThi.ThoiGian, tblThiSinh.MaSV " +
                "FROM Thi INNER JOIN "
                         + "tblLop ON Thi.MaLop = tblLop.MaLop INNER JOIN "
                         + "tblMonThi ON Thi.MaMon = tblMonThi.MaMon INNER JOIN "
                         + "tblCaThi ON Thi.MaCa = tblCaThi.MaCa INNER JOIN "
                         + "tblThiSinh ON tblLop.MaLop = tblThiSinh.MaLop"
            + " where tblThiSinh.MaSV ="
            + "(SELECT tblThiSinh.MaSV FROM tblThiSinh INNER JOIN "
            + "tblTaiKhoan ON tblThiSinh.MaTK = tblTaiKhoan.MaTK where tblTaiKhoan.TenDN ='" + tenuser + "')";
            //them đk ngày tháng nữa
            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            dt.Clear();
            da.Fill(dt);

            txtMonThi.DataBindings.Add("text", dt, "TenMon");
            txtNameS.DataBindings.Add("text", dt, "HoTen");
            txtBirthS.DataBindings.Add("Text", dt, "NgaySinh");
            //txtBirthS.Text = txtBirthS.Text.Substring(0, 10);
            txtTenCa.DataBindings.Add("text", dt, "TenCa");
            txtTimeT.DataBindings.Add("text", dt, "ThoiGian");
            h = int.Parse(txtTimeT.Text.Substring(0, 2));
            m = int.Parse(txtTimeT.Text.Substring(3, 2));
            s = int.Parse(txtTimeT.Text.Substring(6, 2));
            txtSoCau.DataBindings.Add("text", dt, "SoCau");
            txtClass.DataBindings.Add("text", dt, "TenLop");
        }

        public FrmVaoThi(string username)
        {
            InitializeComponent();
            tenuser = username;

        }
    }
}
