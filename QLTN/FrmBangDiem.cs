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
    public partial class FrmBangDiem : Form
    {
        string sql, constr;
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();

        private void FrmBangDiem_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05;" +
                                                   "Initial Catalog=QLTN;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "SELECT        tblCaThi.TenCa, tblCaThi.NgayThi, tblKetQua.SoCD, tblLop.TenLop, tblThiSinh.HoTen, tblKhoa.TenKhoa, tblMonThi.SoCau, Diem = round(cast(tblKetQua.SoCD as float)/cast(tblMonThi.SoCau as float)*10, 2) " +
                "FROM            tblCaThi INNER JOIN " +
                "THI ON tblCaThi.MaCa = THI.MaCa INNER JOIN " +
                "tblMonThi ON THI.MaMon = tblMonThi.MaMon INNER JOIN " +
                "tblLop ON THI.MaLop = tblLop.MaLop INNER JOIN " +
                "tblThiSinh ON THI.MaLop = tblThiSinh.MaLop INNER JOIN " +
                "tblKetQua ON tblThiSinh.MaSV = tblKetQua.MaSV AND tblMonThi.MaMon = tblKetQua.MaMon INNER JOIN " +
                "tblKhoa ON tblThiSinh.MaKhoa = tblKhoa.MaKhoa";
            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            dt.Clear();
            da.Fill(dt);
            grdDataBD.DataSource = dt;
        }

        public FrmBangDiem()
        {
            InitializeComponent();
        }
    }
}
