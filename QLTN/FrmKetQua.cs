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
    public partial class FrmKetQua : Form
    {
        string mmon, msv, constr, sql;
        int  cktl, sc;
        double cd, diembt;
        SqlConnection conn = new SqlConnection();

        private void btnFilterCH_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Hide();
            FrmLogin f = new FrmLogin();
            f.Show();

        }

        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();

        private void FrmKetQua_Load(object sender, EventArgs e)
        {

            constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05;" +
              "Initial Catalog=QLTN;Integrated Security=True;";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "SELECT        tblMonThi.TenMon, tblMonThi.SoCau, tblThiSinh.HoTen " +
                "FROM            tblMonThi INNER JOIN " +
                "THI ON tblMonThi.MaMon = THI.MaMon INNER JOIN " +
                "tblThiSinh ON THI.MaLop = tblThiSinh.MaLop " +
                "where tblMonThi.MaMon = '" + mmon + "' and tblThiSinh.MaSV = '" + msv + "'";
            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            dt.Clear();
            da.Fill(dt);
            sc = int.Parse(dt.Rows[0]["SoCau"].ToString());
            txtNameKQ.Text = dt.Rows[0]["HoTen"].ToString();
            txtSoCTL.Text = (sc - cktl).ToString() + "/" + sc;
            txtSoCDung.Text = cd + "/" + sc;
            diembt = Math.Round( cd / sc,2);
            txtDiemKQ.Text = Convert.ToString(diembt);
            sql = "insert into tblKetQua (MaSV,MaMon, SoCD)" +
                      " Values ('" + msv + "',N'" + mmon + "','" + cd + "')";
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public FrmKetQua(string sub, string mats, double dem, int k)
        {
            InitializeComponent();
            mmon = sub;
            msv = mats;
            cd = dem;
            cktl = k;
        }
    }
}
