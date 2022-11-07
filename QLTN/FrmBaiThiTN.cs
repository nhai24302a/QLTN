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
    public partial class FrmBaiThiTN : Form
    {
        int hours, minutes, counts, cd, n, tag=1,i, mada=0, ds, k=0;
        double dem = 0;
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable dtch = new DataTable();
        DataTable dtda = new DataTable();

        private void txtDA3_TextChanged(object sender, EventArgs e)
        {

        }

        string constr, sql, username, subname, ht, r, sub, mats;

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            for (i = 0; i < this.dtch.Rows.Count; i++)
            {
                sql = "SELECT        tblCauHoi.MaCH, tblDapAn.NoiDung, tblDapAn.DungSai, tblDapAn.MaDA" +
                    " FROM tblCauHoi INNER JOIN" +
                         " tblDapAn ON tblCauHoi.MaCH = tblDapAn.MaCH" +
                         " where tblCauHoi.MaCH='" + dtch.Rows[i]["MaCH"].ToString() + "'" +
                        " order by tblCauHoi.MaCH";
                da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
                dtda.Clear();
                da.Fill(dtda);

                ds = int.Parse(dtch.Rows[i]["Ychon"].ToString());
                if(ds-1>=0)
                {
                    if (dtda.Rows[ds - 1]["DungSai"].ToString() == "Đúng")

                    {
                        dem = dem + 1;
                    }
                }
                else
                {
                    k = k + 1;
                }
            }
            //MessageBox.Show("so cau dung : " + dem +" so cau ko lam:" +k);
            this.Hide();
            FrmKetQua f = new FrmKetQua(sub, mats, dem, k);
            f.Show();

        }

        private void rdDA1_Click(object sender, EventArgs e)
        {
            dtch.Rows[tag - 1]["Ychon"] = mada;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton DA = sender as RadioButton;
            if (DA.Checked)
                r = DA.Name.ToString();
            mada = int.Parse(r.Substring(r.Length - 1, 1));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmBaiThiTN_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05;" +
              "Initial Catalog=QLTN;Integrated Security=True;";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "select  tblCaThi.TenCa, tblCaThi.NgayThi, tblCaThi.TGBD, tblCaThi.TGKT, tblThiSinh.HoTen, tblThiSinh.NgaySinh, tblLop.TenLop,tblMonThi.MaMon, tblMonThi.TenMon, tblMonThi.SoCau, tblMonThi.ThoiGian,tblMonThi.SoCD, tblThiSinh.MaSV " +
                "FROM Thi INNER JOIN "
                         + "tblLop ON Thi.MaLop = tblLop.MaLop INNER JOIN "
                         + "tblMonThi ON Thi.MaMon = tblMonThi.MaMon INNER JOIN "
                         + "tblCaThi ON Thi.MaCa = tblCaThi.MaCa INNER JOIN "
                         + "tblThiSinh ON tblLop.MaLop = tblThiSinh.MaLop"
                + " where tblMonThi.TenMon='"+subname+ "' and tblThiSinh.MaSV ="
                         + "(SELECT tblThiSinh.MaSV FROM tblThiSinh INNER JOIN "
            + "tblTaiKhoan ON tblThiSinh.MaTK = tblTaiKhoan.MaTK where tblTaiKhoan.TenDN ='" + username + "')";
            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            dt.Clear();
            da.Fill(dt);
            n = int.Parse(dt.Rows[0]["SoCau"].ToString());
            cd = int.Parse(dt.Rows[0]["SoCD"].ToString());
            sub = dt.Rows[0]["MaMon"].ToString();
            mats = dt.Rows[0]["MaSV"].ToString();


            sql = "SELECT    TOP " + cd + " tblCauHoi.MaCH, tblCauHoi.NoiDung, tblCauHoi.DoKho, tblCauHoi.HinhThuc, tblCauHoi.Ychon "
           + "FROM tblCauHoi INNER JOIN " +
                       "tblMonThi ON tblCauHoi.MaMon = tblMonThi.MaMon " +
           "where tblMonThi.TenMon =N'"+subname+"' and tblCauHoi.DoKho = N'Dễ' " +
           "ORDER BY NEWID()";
            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            dtch.Clear();
            da.Fill(dtch);

            sql = "SELECT    TOP " + (n-cd) + " tblCauHoi.MaCH, tblCauHoi.NoiDung, tblCauHoi.DoKho, tblCauHoi.HinhThuc, tblCauHoi.Ychon "
           + "FROM tblCauHoi INNER JOIN " +
                       "tblMonThi ON tblCauHoi.MaMon = tblMonThi.MaMon " +
           "where tblMonThi.TenMon =N'" + subname + "' and tblCauHoi.DoKho = N'Khó' " +
           "ORDER BY NEWID()";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dtch);

            for (i = 1; i <= n; i++)
            {
                Button btnDA = new Button();
                btnDA.Name = "btnDA" + i;
                btnDA.Size = new System.Drawing.Size(30, 30);
                btnDA.Text = i.ToString();
                btnDA.Click += new EventHandler(btnDA_Click);
                fpnDA.Controls.Add(btnDA);

            }

            Show_question(0);

            timer1.Start();

        }
        private void btnDA_Click(object sender, EventArgs e)
        {
            Button btnDA = (Button)sender; //lấy button đang được click
            //MessageBox.Show("pnlCH.Tag.ToString()")
            tag = int.Parse(((Button)sender).Text);

            Show_question(tag - 1);
        }

        private void Show_question(int numQ)
        {
            rtxtCH.Text = " Câu " + (numQ + 1).ToString() + ": " + dtch.Rows[numQ]["NoiDung"].ToString();
            sql = "SELECT        tblCauHoi.MaCH, tblDapAn.NoiDung, tblDapAn.DungSai, tblDapAn.MaDA" +
                    " FROM tblCauHoi INNER JOIN" +
                         " tblDapAn ON tblCauHoi.MaCH = tblDapAn.MaCH" +
                         " where tblCauHoi.MaCH='" + dtch.Rows[numQ]["MaCH"].ToString() + "'" +
                        " order by tblCauHoi.MaCH";
            da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
            dtda.Clear();
            da.Fill(dtda);

            txtDA1.Text = dtda.Rows[0][1].ToString();
            txtDA2.Text = dtda.Rows[1][1].ToString();
            ht = dtch.Rows[numQ]["HinhThuc"].ToString();
            if (ht == "Nhiều lựa chọn")
            {
                rdDA3.Visible = true;
                rdDA4.Visible = true;
                txtDA3.Visible = true;
                txtDA4.Visible = true;
                txtDA3.Text = dtda.Rows[2][1].ToString();
                txtDA4.Text = dtda.Rows[3][1].ToString();
            }
            else
            {
                rdDA3.Visible = false;
                rdDA4.Visible = false;
                txtDA3.Visible = false;
                txtDA4.Visible = false;
            }


            switch (Convert.ToInt32(dtch.Rows[numQ]["Ychon"]))
            {
                case 0:
                    rdDA1.Checked = false;
                    rdDA2.Checked = false;
                    rdDA3.Checked = false;
                    rdDA4.Checked = false;
                    break;
                case 1:
                    rdDA1.Checked = true;
                    break;
                case 2:
                    rdDA2.Checked = true;
                    break;
                case 3:
                    rdDA3.Checked = true;
                    break;
                case 4:
                    rdDA4.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counts--;

            if (counts < 0)
            {
                counts = 59;
                minutes--;

                counts = 59;
                if (minutes < 0)
                {
                    hours--;
                    minutes = 59;


                }
            }
            if (counts.ToString().Length == 1)
            {
                lblSeconds.Text = "0" + counts.ToString();
            }
            else
            {
                lblSeconds.Text = counts.ToString();
            }

            if (minutes.ToString().Length == 1)
            {
                lblMinutes.Text = "0" + minutes.ToString();
            }
            else
            {
                lblMinutes.Text = minutes.ToString();
            }

            if (hours.ToString().Length == 1)
            {
                lblHours.Text = "0" + hours.ToString();
            }
            else
            {
                lblHours.Text = hours.ToString();
            }

            if (hours == 0 && minutes == 0 && counts == 0)
            {
                timer1.Stop();
                for (i = 0; i < this.dtch.Rows.Count; i++)
                {
                    sql = "SELECT        tblCauHoi.MaCH, tblDapAn.NoiDung, tblDapAn.DungSai, tblDapAn.MaDA" +
                        " FROM tblCauHoi INNER JOIN" +
                             " tblDapAn ON tblCauHoi.MaCH = tblDapAn.MaCH" +
                             " where tblCauHoi.MaCH='" + dtch.Rows[i]["MaCH"].ToString() + "'" +
                            " order by tblCauHoi.MaCH";
                    da = new SqlDataAdapter(sql, conn); // câu lệnh giúp dataAdapter truy vấn dữ liệu
                    dtda.Clear();
                    da.Fill(dtda);

                    ds = int.Parse(dtch.Rows[i]["Ychon"].ToString());
                    if (dtda.Rows[ds - 1]["DungSai"].ToString() == "Đúng")

                    {
                        dem = dem + 1;
                    }
                }
                MessageBox.Show("so cau dung : " + dem);

            }
        }
        
        public FrmBaiThiTN(int h, int m, int s, string tenuser, string tenmon)
        {
            InitializeComponent();
            hours = h;
            minutes = m;
            counts = s;
            username = tenuser;
            subname = tenmon;
        }
        
    }
}
