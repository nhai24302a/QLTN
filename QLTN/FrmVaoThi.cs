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
        string constr, sql, tenuser,tgbd,tgkt, tenmon;
        int h, m, s, ho,min, x, hour, minute;



       

        

        private void btnThi_Click(object sender, EventArgs e)
        {
            h = int.Parse(txtTimeT.Text.Substring(0, 2));
            m = int.Parse(txtTimeT.Text.Substring(3, 2));
            s = int.Parse(txtTimeT.Text.Substring(6, 2));

            tgbd = dtm.Rows[0]["TGBD"].ToString();
            tgkt = dtm.Rows[0]["TGKT"].ToString();


            ho = DateTime.Now.Hour - int.Parse(tgbd.Substring(0, 2));
            x = DateTime.Now.Minute - int.Parse(tgbd.Substring(3, 2));

            if (x < 0)
            {
                ho = ho - 1;
                min = (int)(60 + x);
            }
            if (ho >= 0)
            {
                hour = DateTime.Now.Hour - int.Parse(tgkt.Substring(0, 2));
                x = DateTime.Now.Minute - int.Parse(tgkt.Substring(3, 2));
                if (x < 0)
                {
                    hour = hour - 1;
                    minute = (int)(60 + x);
                }
                if (hour >= 0)
                    MessageBox.Show("Đã hết thời gian làm bài thi");
                else
                {
                    FrmBaiThiTN f = new FrmBaiThiTN(h, m, s, tenuser, tenmon);
                    this.Hide();
                    f.Show();
                }
            }
            else
            {
                MessageBox.Show("Chưa đến thời gian làm bài thi");
            }    
        }

        private void FrmVaoThi_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05;" +
              "Initial Catalog=QLTN;Integrated Security=True;";
            conn.ConnectionString = constr;
            conn.Open();
            /*sql= "SELECT   distinct     tblMonThi.TenMon "+
                    "FROM tblCaThi INNER JOIN "+
                         "tblMonThi ON tblCaThi.MaMon = tblMonThi.MaMon INNER JOIN "+
                         "THI ON tblMonThi.MaMon = THI.MaMon AND tblCaThi.MaCa = THI.MaCa INNER JOIN "+
                         "tblThiSinh ON THI.MaLop = tblThiSinh.MaLop " +
                    "Where Day(tblCaThi.NgayThi) ='" + DateTime.Now.Day+ "' and month(tblCaThi.NgayThi) ='"+ DateTime.Now.Month+ "' and year(tblCaThi.NgayThi) ='"+ DateTime.Now.Year+"' and tblThiSinh.MaSV ="
                + "(SELECT tblThiSinh.MaSV FROM tblThiSinh INNER JOIN "
            + "tblTaiKhoan ON tblThiSinh.MaTK = tblTaiKhoan.MaTK where tblTaiKhoan.TenDN ='" + tenuser + "')";
            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            dtm.Clear();
            da.Fill(dtm);
            comMonThi.DataSource = dtm;*/

            sql = "select  tblCaThi.TenCa, tblCaThi.NgayThi, tblCaThi.TGBD, tblCaThi.TGKT, tblThiSinh.HoTen, tblThiSinh.NgaySinh, tblLop.TenLop, tblMonThi.TenMon, tblMonThi.SoCau, tblMonThi.ThoiGian, tblThiSinh.MaSV " +
                "FROM Thi INNER JOIN "
                         + "tblLop ON Thi.MaLop = tblLop.MaLop INNER JOIN "
                         + "tblMonThi ON Thi.MaMon = tblMonThi.MaMon INNER JOIN "
                         + "tblCaThi ON Thi.MaCa = tblCaThi.MaCa INNER JOIN "
                         + "tblThiSinh ON tblLop.MaLop = tblThiSinh.MaLop"
            + " where Day(tblCaThi.NgayThi) ='" + DateTime.Now.Day + "' and month(tblCaThi.NgayThi) ='" + DateTime.Now.Month + "' and year(tblCaThi.NgayThi) ='" + DateTime.Now.Year + "' and tblThiSinh.MaSV ="
            + "(SELECT tblThiSinh.MaSV FROM tblThiSinh INNER JOIN "
            + "tblTaiKhoan ON tblThiSinh.MaTK = tblTaiKhoan.MaTK where tblTaiKhoan.TenDN ='" + tenuser + "')";
            //them đk ngày tháng nữa
            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            dt.Clear();
            da.Fill(dt);
            comMonThi.DataSource = dt;
            comMonThi.DisplayMember = "TenMon";

            txtNameS.DataBindings.Add("text", dt, "HoTen");
            txtBirthS.DataBindings.Add("Text", dt, "NgaySinh");
            txtBirthS.Text = txtBirthS.Text.Substring(0, 10);
            txtClass.DataBindings.Add("text", dt, "TenLop");
            
        }

        public FrmVaoThi(string username)
        {
            InitializeComponent();
            tenuser = username;

        }

        private void comMonThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "select  tblCaThi.TenCa, tblCaThi.NgayThi, tblCaThi.TGBD, tblCaThi.TGKT, tblThiSinh.HoTen, tblThiSinh.NgaySinh, tblLop.TenLop, tblMonThi.TenMon, tblMonThi.SoCau, tblMonThi.ThoiGian, tblThiSinh.MaSV " +
                "FROM Thi INNER JOIN "
                         + "tblLop ON Thi.MaLop = tblLop.MaLop INNER JOIN "
                         + "tblMonThi ON Thi.MaMon = tblMonThi.MaMon INNER JOIN "
                         + "tblCaThi ON Thi.MaCa = tblCaThi.MaCa INNER JOIN "
                         + "tblThiSinh ON tblLop.MaLop = tblThiSinh.MaLop"
            + " where Day(tblCaThi.NgayThi) ='" + DateTime.Now.Day + "' and month(tblCaThi.NgayThi) ='" + DateTime.Now.Month + "' and year(tblCaThi.NgayThi) ='" + DateTime.Now.Year + "' and tblMonThi.TenMon='" + comMonThi.Text + "' and tblThiSinh.MaSV ="
            + "(SELECT tblThiSinh.MaSV FROM tblThiSinh INNER JOIN "
            + "tblTaiKhoan ON tblThiSinh.MaTK = tblTaiKhoan.MaTK where tblTaiKhoan.TenDN ='" + tenuser + "')";
            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            dtm.Clear();
            da.Fill(dtm);


            if(dtm.Rows.Count !=0)
            {
                tenmon = dtm.Rows[0]["TenMon"].ToString();
                txtTenCa.Text = dtm.Rows[0]["TenCa"].ToString();
                //txtTenCa.DataBindings.Add("text", dtm, "TenCa");
                txtTimeT.Text = dtm.Rows[0]["ThoiGian"].ToString();

                //txtTimeT.DataBindings.Add("text", dtm, "ThoiGian");
                /*h = int.Parse(txtTimeT.Text.Substring(0, 2));
                m = int.Parse(txtTimeT.Text.Substring(3, 2));
                s = int.Parse(txtTimeT.Text.Substring(6, 2));*/

                txtSoCau.Text = dtm.Rows[0]["SoCau"].ToString();
                //txtSoCau.DataBindings.Add("text", dtm, "SoCau");
            }
            //txtMonThi.DataBindings.Add("text", dt, "TenMon");

            //txtTenCa.Text = dtm.Rows[0]["TenCa"].ToString();
            //txtTenCa.DataBindings.Add("text", dtm, "TenCa");
            //txtTimeT.Text = dtm.Rows[0]["ThoiGian"].ToString();

            //txtTimeT.DataBindings.Add("text", dtm, "ThoiGian");
            /**/
            
            //txtSoCau.Text = dtm.Rows[0]["SoCau"].ToString();
            //txtSoCau.DataBindings.Add("text", dtm, "SoCau");


            //tgbd = dtm.Rows[0]["TGBD"].ToString();
            //tgkt = dtm.Rows[0]["TGKT"].ToString();
        }
    }
}
