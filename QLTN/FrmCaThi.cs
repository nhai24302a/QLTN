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
    public partial class FrmCaThi : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable comdt = new DataTable();
        DataTable com2dt = new DataTable();
        string sql, constr;
        int i;
        Boolean addnewflag = false;
        public FrmCaThi()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmCaThi_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-2C52VJI\\SQLEXPRESS;" +
                                                   "Initial Catalog=QLTN;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select * from tblCaThi order by MaCa";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            sql = "Select MaCa,MaMon,TenCa,TGBD,TGKT,NgayThi from tblCaThi order by MaCa";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdData.DataSource = dt;
            NapCT();

            grdData.CurrentCell = grdData[0, grdData.RowCount - 1];
            NapCT();
            MessageBox.Show("Hãy nhập nội dung bản ghi mới, kết thúc bấm Cập nhật!");
            txtMaCa.Focus();
            addnewflag = true;
            btnupdate.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy thực hiện mọi sửa đổi mong muốn trên ô lưới," +
               "kết thúc bằng nút cập nhật", "Thông báo", MessageBoxButtons.OK);
            btnupdate.Enabled = true;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi hiện thời?Y/N", "Xác nhận" +
                "yêu cầu", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                sql = "Delete from tblCaThi where MaCa='" + txtMaCa.Text + "'";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                grdData.Rows.RemoveAt(grdData.CurrentRow.Index);
                NapCT();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (addnewflag == false)
            {
                // Chỗ này là cập nhật sửa chữa
                for (i = 0; i < grdData.RowCount - 1; i++)
                {
                    txtMaCa.Text = grdData.Rows[i].Cells["MaCa"].Value.ToString();
                    txtMaMon.Text = grdData.Rows[i].Cells["MaMon"].Value.ToString();
                    txtTenCa.Text = grdData.Rows[i].Cells["TenCa"].Value.ToString();
                    txtTGBD.Text = grdData.Rows[i].Cells["TGBD"].Value.ToString();
                    txtTGKT.Text = grdData.Rows[i].Cells["TGKT"].Value.ToString();
                    txtNgayThi.Text = grdData.Rows[i].Cells["NgayThi"].Value.ToString();
                   

                    sql = "update tblGiangVien set " +
                        "MaMon='" + txtMaMon.Text + "'," +
                      " TenCa=N'" + txtTenCa.Text + "',TGBD='" + txtTGBD.Text +"',TGKT='" + txtTGKT.Text + "',NgayThi='" + txtNgayThi.Text + "'"
                        + " where MaCa='" + txtMaCa.Text + "'";
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                }
            }
            else
            {
                //Chỗ này là cập nhật thêm mới
                addnewflag = false;
                sql = "insert into tblCaThi(MaCa,MaMon,TenCa,TGBD,TGKT,NgayThi)" +
                    " Values ('" + txtMaCa.Text + "','" + txtMaMon.Text + "',N'" +
                    txtTenCa.Text + "','" + txtTGBD.Text + "','" + txtTGKT.Text + "','" + txtMaMon.Text + "','"
                    + txtNgayThi.Text + "')";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                grdData.Rows[i].Cells["MaCa"].Value = txtMaCa.Text;
                grdData.Rows[i].Cells["MaMon"].Value = txtMaMon.Text;
                grdData.Rows[i].Cells["TenCa"].Value = txtTenCa.Text;
                grdData.Rows[i].Cells["TGBD"].Value = txtTGBD.Text;
                grdData.Rows[i].Cells["TGKT"].Value = txtTGKT.Text;
                grdData.Rows[i].Cells["NgayThi"].Value = txtNgayThi.Text;
               

            }
            btnupdate.Enabled = false;
        }

        private void NapCT()
        {
            i = grdData.CurrentRow.Index;
            txtMaCa.Text = grdData.Rows[i].Cells["MaCa"].Value.ToString();
            txtMaMon.Text = grdData.Rows[i].Cells["MaMon"].Value.ToString();
            txtTenCa.Text = grdData.Rows[i].Cells["TenCa"].Value.ToString();
            txtTGBD.Text = grdData.Rows[i].Cells["TGBD"].Value.ToString();
            txtTGKT.Text = grdData.Rows[i].Cells["TGKT"].Value.ToString();
            txtNgayThi.Text = grdData.Rows[i].Cells["NgayThi"].Value.ToString();
            

        }
    }

}
