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
        int i, j, mada,k;
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable dtmon = new DataTable();
        DataTable dtht = new DataTable();
        DataTable dtdk = new DataTable();
        DataTable dtda = new DataTable();
        DataTable dttk = new DataTable();
        Boolean addnewflag = false;
        string sql, constr, mamon, u, magv,r, sda, ds ;

        public FrmCauHoi(string tenuser)
        {
            InitializeComponent();
            u = tenuser;
        }

        private void FrmCauHoi_Load(object sender, EventArgs e)
        {

            constr = "Data Source = DESKTOP-6H5PSI2\\SQLEXPRESS05; Initial Catalog = QLTN; Integrated Security = True;";
            conn.ConnectionString = constr;
            conn.Open();

            sql = "select  MaMon, TenMon from tblMonThi";
            da = new SqlDataAdapter(sql, conn);
            dtmon.Clear();
            da.Fill(dtmon);

            
            comTenMon.DataSource = dtmon;
            comTenMon.DisplayMember = "TenMon";
            grdDataCH.DataSource = dt;

            sql = "SELECT tblGiangVien.MaGV " +
                "FROM            tblGiangVien INNER JOIN " +
                "tblTaiKhoan ON tblGiangVien.MaTK = tblTaiKhoan.MaTK " +
                "where tblTaiKhoan.TenDN='" + u + "'";
            da = new SqlDataAdapter(sql, conn);
            dttk.Clear();
            da.Fill(dttk);
            magv = dttk.Rows[0]["MaGV"].ToString();

            //NapCTCH();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comTenMon_SelectedValueChanged(object sender, EventArgs e)
        {
            /*sql = "SELECT        tblCauHoi.MaCH, tblCauHoi.NoiDung,tblCauHoi.MaGV, tblCauHoi.MaMon, tblCauHoi.DoKho, tblCauHoi.HinhThuc  "
                + "FROM            tblCauHoi INNER JOIN "
                + "tblMonThi ON tblCauHoi.MaMon = tblMonThi.MaMon "+
                "where tblMonThi.TenMon=N'" + comTenMon.Text +"'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);

            grdDataCH.Refresh();*/
            //NapCTCH();
            //sql

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            grdDataCH.CurrentCell = grdDataCH[0, 0];
            NapCTCH();
        }

        private void btnPreCH_Click(object sender, EventArgs e)
        {
            if (i >= 1)
            {
                i = grdDataCH.CurrentRow.Index;
                grdDataCH.CurrentCell = grdDataCH[0, i - 1];
            }
            else
            {
                i = grdDataCH.RowCount;
                grdDataCH.CurrentCell = grdDataCH[0, i - 2];
            }
            NapCTCH();
        }

        private void btnNextCH_Click(object sender, EventArgs e)
        {
            i = grdDataCH.CurrentRow.Index;
            if (i <= grdDataCH.RowCount - 2)
            {
                grdDataCH.CurrentCell = grdDataCH[0, i + 1];
            }
            else
            {
                grdDataCH.CurrentCell = grdDataCH[0, 0];
            }
            NapCTCH();
        }

        private void btnLastCH_Click(object sender, EventArgs e)
        {
            i = grdDataCH.RowCount;
            grdDataCH.CurrentCell = grdDataCH[0, i - 2];
            NapCTCH();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sql = "SELECT        tblCauHoi.MaCH, tblCauHoi.NoiDung,tblCauHoi.MaGV, tblCauHoi.MaMon, tblCauHoi.DoKho, tblCauHoi.HinhThuc  "
               + "FROM            tblCauHoi INNER JOIN "
               + "tblMonThi ON tblCauHoi.MaMon = tblMonThi.MaMon " +
               "where tblMonThi.TenMon=N'" + comTenMon.Text + "'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdDataCH.Refresh();

            mamon = dt.Rows[0]["MaMon"].ToString();
            mamon = dt.Rows[0]["MaMon"].ToString();

            sql = "select distinct HinhThuc from tblCauHoi";
            da = new SqlDataAdapter(sql, conn);
            dtht.Clear();
            da.Fill(dtht);

            comHt.DataSource = dtht;
            comHt.DisplayMember = "HinhThuc";

            sql = "select distinct DoKho from tblCauHoi";
            da = new SqlDataAdapter(sql, conn);
            dtdk.Clear();
            da.Fill(dtdk);
            comDk.DataSource = dtdk;
            comDk.DisplayMember = "DoKho";

            NapCTCH();
        }

        private void btnEditCH_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy thực hiện mọi sửa đổi mong muốn trên ô lưới, kết thức bấm nút Cập nhật", "Thông báo", MessageBoxButtons.OK);
            btnUpdateCH.Enabled = true;
        }

        private void rbDA4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton DA = sender as RadioButton;
            if (DA.Checked)
                r = DA.Name.ToString();
            mada = int.Parse(r.Substring(r.Length - 1, 1));        }

        private void comHt_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAddCH_Click(object sender, EventArgs e)
        {

            sql = "SELECT        tblCauHoi.MaCH, tblCauHoi.NoiDung,tblCauHoi.MaGV, tblCauHoi.MaMon, tblCauHoi.DoKho, tblCauHoi.HinhThuc  "
              + "FROM            tblCauHoi INNER JOIN "
              + "tblMonThi ON tblCauHoi.MaMon = tblMonThi.MaMon " +
              "where tblMonThi.TenMon=N'" + comTenMon.Text + "'";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdDataCH.Refresh();

            

            grdDataCH.CurrentCell = grdDataCH[0, grdDataCH.RowCount - 1];
            NapCTCH();
            txtMaGV.Text = magv;
            txtMaMon.Text = mamon;
            MessageBox.Show("Hãy nhập nội dung bản ghi mới, kết thúc bấm Cập nhật!");
            txtMaCH.Focus();//Chuyển con trỏ soạn thảo đến mã nhóm
            addnewflag = true;
            btnUpdateCH.Enabled = true;
        }

        private void btnDelCH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi hiện thời?Y/N", "Xác nhận yêu cầu", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                sql = "delete from tblCauHoi where MaCH ='" + txtMaCH.Text + "'";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                grdDataCH.Rows.RemoveAt(grdDataCH.CurrentRow.Index);
                
                sql = "delete  " +
               "FROM            tblCauHoi, tblDapAn " +
               "where  tblCauHoi.MaCH = tblDapAn.MaCH " +
               "and tblDapAn.MaCH='" + txtMaCH.Text + "'";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                NapCTCH();
            }
        }

        private void btnUpdateCH_Click(object sender, EventArgs e)
        {
            if (addnewflag == false)
            {
                //Chỗ này là cập nhật sửa chữa
                for (i = 0; i < grdDataCH.RowCount - 1; i++)
                {

                    txtMaCH.Text = grdDataCH.Rows[i].Cells["MaCH"].Value.ToString();
                    txtMaCH.Enabled = false;

                    txtMaMon.Text = grdDataCH.Rows[i].Cells["MaMon"].Value.ToString();
                    txtMaMon.Enabled = false;

                    txtMaGV.Text = grdDataCH.Rows[i].Cells["MaGV"].Value.ToString();
                    txtMaGV.Enabled = false;

                    txtNoiDung.Text = grdDataCH.Rows[i].Cells["NoiDung"].Value.ToString();
                    comDk.Text = grdDataCH.Rows[i].Cells["DoKho"].Value.ToString();
                    comHt.Text = grdDataCH.Rows[i].Cells["HinhThuc"].Value.ToString();
                    sql = "update tblCauHoi set " + " MaMon=N'" + txtMaMon.Text + "', MaGV='" + txtMaGV.Text + "', " +
                          "NoiDung=N'" + txtNoiDung.Text + "', DoKho=N'" + comDk.Text + "', HinhThuc=N'" + comHt.Text + "'  Where MaCH='" + txtMaCH.Text + "'";

                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = "SELECT         tblDapAn.MaDA, tblDapAn.NoiDung, tblDapAn.DungSai " +
                "FROM            tblCauHoi INNER JOIN " +
                "tblDapAn ON tblCauHoi.MaCH = tblDapAn.MaCH " +
                "where tblDapAn.MaCH='" + txtMaCH.Text + "'";
                    da = new SqlDataAdapter(sql, conn);
                    dtda.Clear();
                    da.Fill(dtda);


                    if (dtda.Rows.Count > 0)
                    {
                        txtDAA.Text = dtda.Rows[0][1].ToString();
                        txtDAB.Text = dtda.Rows[1][1].ToString();
                        //ht = dtch.Rows[i]["HinhThuc"].ToString();
                        if (dtda.Rows[0]["DungSai"].ToString() == "Đúng")
                        {
                            rbDA1.Checked = true;
                        }
                        else if (dtda.Rows[1]["DungSai"].ToString() == "Đúng")
                        {
                            rbDA2.Checked = true;
                        }

                        if (grdDataCH.Rows[i].Cells["HinhThuc"].Value.ToString() == "Nhiều lựa chọn")
                        {
                            rbDA3.Visible = true;
                            rbDA4.Visible = true;
                            txtDAC.Visible = true;
                            txtDAD.Visible = true;
                            txtDAC.Text = dtda.Rows[2][1].ToString();
                            txtDAD.Text = dtda.Rows[3][1].ToString();
                            if (dtda.Rows[2]["DungSai"].ToString() == "Đúng")
                            {
                                rbDA3.Checked = true;
                            }
                            else if (dtda.Rows[3]["DungSai"].ToString() == "Đúng")
                            {
                                rbDA4.Checked = true;
                            }
                        }
                        else
                        {
                            rbDA3.Visible = false;
                            rbDA4.Visible = false;
                            txtDAC.Visible = false;
                            txtDAD.Visible = false;
                        }
                    }
                    else
                    {
                        rbDA3.Visible = true;
                        rbDA4.Visible = true;
                        txtDAC.Visible = true;
                        txtDAD.Visible = true;
                        rbDA1.Checked = false;
                        rbDA2.Checked = false;
                        rbDA3.Checked = false;
                        rbDA4.Checked = false;
                        txtDAA.Clear();
                        txtDAB.Clear();
                        txtDAC.Clear();
                        txtDAD.Clear();

                    }

                    if (comHt.Text == "Nhiều lựa chọn")

                    {
                        rbDA3.Visible = true;
                        rbDA4.Visible = true;
                        txtDAC.Visible = true;
                        txtDAD.Visible = true;
                        sql = "update tblDapAn set " + " NoiDung=N'" + txtDAA.Text + "' " +
                          "   Where MaCH='" + txtMaCH.Text + "' and MaDA = N'DA" + 1 + "' "+
                          "update tblDapAn set " + " NoiDung=N'" + txtDAB.Text + "' " +
                          "   Where MaCH='" + txtMaCH.Text  + "' and MaDA = N'DA" + 2 + "' " +
                          "update tblDapAn set " + " NoiDung=N'" + txtDAC.Text + "' " +
                          "   Where MaCH='" + txtMaCH.Text  + "' and MaDA = N'DA" + 3 + "' " +
                          "update tblDapAn set " + " NoiDung=N'" + txtDAD.Text + "' " +
                          "   Where MaCH='" + txtMaCH.Text  + "' and MaDA = N'DA" + 4 + "'";
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        for (j = 1; j <= 4; j++)
                        {


                            if (j == mada)
                            {
                                sql = "update tblDapAn set " +
                          " DungSai=N'Đúng'  Where MaCH='" + txtMaCH.Text + "' and MaDA='DA" + j + "'";
                                cmd.Connection = conn;
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                sql = "update tblDapAn set " +
                          " DungSai=N'Sai'  Where MaCH='" + txtMaCH.Text + "' and MaDA='DA" + j + "'";
                                cmd.Connection = conn;
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                            }

                        }
                    }
                    else
                    {
                        sql = "update tblDapAn set " + " NoiDung=N'" + txtDAA.Text + "' " +
                          "   Where MaCH='" + txtMaCH.Text + "' and MaDA = N'DA" + 1 + "' " +
                          "update tblDapAn set " + " NoiDung=N'" + txtDAB.Text + "' " +
                          "   Where MaCH='" + txtMaCH.Text + "' and MaDA = N'DA" + 2 + "'";
                        for (j = 1; j <= 2; j++)
                        {

                            if (j == mada)
                            {
                                sql = "update tblDapAn set " +
                          " DungSai=N'Đúng'  Where MaCH='" + txtMaCH.Text + "' and MaDA='DA" + j + "'";
                                cmd.Connection = conn;
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                sql = "update tblDapAn set " +
                          " DungSai=N'Sai'  Where MaCH='" + txtMaCH.Text + "' and MaDA='DA" + j + "'";
                                cmd.Connection = conn;
                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();

                            }
                        }
                    }



                }

                MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                grdDataCH.Refresh();
                NapCTCH();
            }
            else
            {
                //Chỗ này là cập nhật thêm mới
                addnewflag = false;

                txtMaMon.Enabled = false;
                txtMaGV.Enabled = false;
                sql = "insert into tblCauHoi (MaCH, NoiDung, MaGV, MaMon, DoKho, HinhThuc)" +
                      " Values ('" + txtMaCH.Text + "',N'" + txtNoiDung.Text + "',N'" + txtMaGV.Text + "',N'" +
                      txtMaMon.Text + "',N'" + comDk.Text + "' ,N'" + comHt.Text + "')";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                //Nạp bản ghi vừa thêm từ ô chi tiết vào ô lưới
                grdDataCH.Rows[i].Cells["MaCH"].Value = txtMaCH.Text;
                grdDataCH.Rows[i].Cells["NoiDung"].Value = txtNoiDung.Text;
                grdDataCH.Rows[i].Cells["MaGV"].Value = magv;
                grdDataCH.Rows[i].Cells["MaMon"].Value = mamon;
                grdDataCH.Rows[i].Cells["DoKho"].Value = comDk.Text;
                grdDataCH.Rows[i].Cells["HinhThuc"].Value = comHt.Text;

                

                if (comHt.Text == "Nhiều lựa chọn")
                {
                    rbDA3.Visible = true;
                    rbDA4.Visible = true;
                    txtDAC.Visible = true;
                    txtDAD.Visible = true;
                    sql = "insert into tblDapAn (MaDA, MaCH,NoiDung)" +
                     " Values ('DA" + 1 + "',N'" + txtMaCH.Text + "',N'" + txtDAA.Text + "' " +
                     "insert into tblDapAn (MaDA, MaCH,NoiDung)" +
                     " Values ('DA" + 2 + "',N'" + txtMaCH.Text + "',N'" + txtDAB.Text + "' " +
                     "insert into tblDapAn (MaDA, MaCH,NoiDung)" +
                     " Values ('DA" + 3 + "',N'" + txtMaCH.Text + "',N'" + txtDAC.Text + "' " +
                     "insert into tblDapAn (MaDA, MaCH,NoiDung)" +
                     " Values ('DA" + 4 + "',N'" + txtMaCH.Text + "',N'" + txtDAD.Text + "'";
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    for (j = 1; j <= 4; j++)
                    {
                        if (j == mada)
                        {
                            sql = "update tblDapAn set " +
                          " DungSai=N'Đúng'  Where MaCH='" + txtMaCH.Text + "' and MaDA='DA" + j + "'";
                            cmd.Connection = conn;
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            sql = "update tblDapAn set " +
                      " DungSai=N'Sai'  Where MaCH='" + txtMaCH.Text + "' and MaDA='DA" + j + "'";
                            cmd.Connection = conn;
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }

                    }
                }

                else
                {
                    sql = "insert into tblDapAn (MaDA, MaCH,NoiDung)" +
                 " Values ('DA" + 1 + "',N'" + txtMaCH.Text + "',N'" + txtDAA.Text + "' " +
                 "insert into tblDapAn (MaDA, MaCH,NoiDung)" +
                 " Values ('DA" + 2 + "',N'" + txtMaCH.Text + "',N'" + txtDAB.Text + "'";
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    for (j = 1; j <= 2; j++)
                    {
                        if (j == mada)
                        {
                            sql = "update tblDapAn set " +
                          " DungSai=N'Đúng'  Where MaCH='" + txtMaCH.Text + "' and MaDA='DA" + j + "'";
                            cmd.Connection = conn;
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            sql = "update tblDapAn set " +
                      " DungSai=N'Sai'  Where MaCH='" + txtMaCH.Text + "' and MaDA='DA" + j + "'";
                            cmd.Connection = conn;
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }

                    }
                }
            }
                btnUpdateCH.Enabled = false;
            grdDataCH.Refresh();
            NapCTCH();
            
        }

        private void NapCTCH()
        {
            i = grdDataCH.CurrentRow.Index;// Biến i nhận gtri là chỉ số hay stt của bản ghi hiện thời
            txtMaCH.Text = grdDataCH.Rows[i].Cells["MaCH"].Value.ToString();
            txtMaMon.Text = grdDataCH.Rows[i].Cells["MaMon"].Value.ToString();
            txtMaGV.Text = grdDataCH.Rows[i].Cells["MaGV"].Value.ToString();
            txtNoiDung.Text = grdDataCH.Rows[i].Cells["NoiDung"].Value.ToString();
            comDk.Text = grdDataCH.Rows[i].Cells["DoKho"].Value.ToString();
            comHt.Text = grdDataCH.Rows[i].Cells["HinhThuc"].Value.ToString();

            sql = "SELECT         tblDapAn.MaDA, tblDapAn.NoiDung, tblDapAn.DungSai " +
                "FROM            tblCauHoi INNER JOIN " +
                "tblDapAn ON tblCauHoi.MaCH = tblDapAn.MaCH " +
                "where tblDapAn.MaCH='" + txtMaCH.Text + "'";
            da = new SqlDataAdapter(sql, conn);
            dtda.Clear();
            da.Fill(dtda);


            if(dtda.Rows.Count>0)
            {
                txtDAA.Text = dtda.Rows[0][1].ToString();
                txtDAB.Text = dtda.Rows[1][1].ToString();
                //ht = dtch.Rows[i]["HinhThuc"].ToString();
                if (dtda.Rows[0]["DungSai"].ToString() == "Đúng")
                {
                    rbDA1.Checked = true;
                }
                else if (dtda.Rows[1]["DungSai"].ToString() == "Đúng")
                {
                    rbDA2.Checked = true;
                }

                if (grdDataCH.Rows[i].Cells["HinhThuc"].Value.ToString() == "Nhiều lựa chọn")
                {
                    rbDA3.Visible = true;
                    rbDA4.Visible = true;
                    txtDAC.Visible = true;
                    txtDAD.Visible = true;
                    txtDAC.Text = dtda.Rows[2][1].ToString();
                    txtDAD.Text = dtda.Rows[3][1].ToString();
                    if (dtda.Rows[2]["DungSai"].ToString() == "Đúng")
                    {
                        rbDA3.Checked = true;
                    }
                    else if (dtda.Rows[3]["DungSai"].ToString() == "Đúng")
                    {
                        rbDA4.Checked = true;
                    }
                }
                else
                {
                    rbDA3.Visible = false;
                    rbDA4.Visible = false;
                    txtDAC.Visible = false;
                    txtDAD.Visible = false;
                }
            }   
            else
            {
                rbDA3.Visible = true;
                rbDA4.Visible = true;
                txtDAC.Visible = true;
                txtDAD.Visible = true;
                rbDA1.Checked = false;
                rbDA2.Checked = false;
                rbDA3.Checked = false;
                rbDA4.Checked = false;
                txtDAA.Clear();
                txtDAB.Clear();
                txtDAC.Clear();
                txtDAD.Clear();

            }    
            
            


        }
    }
}
