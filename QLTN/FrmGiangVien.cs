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
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable comdt = new DataTable();
        DataTable com2dt = new DataTable();
        string sql, constr;
        int i;
        Boolean addnewflag = false;
        public FrmGiangVien()
        {
            InitializeComponent();
        }

        private void FrmGiangVien_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-2C52VJI\\SQLEXPRESS;" +
                                        "Initial Catalog=QLTN;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select * from tblGiangVien order by MaGV";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;
            NapCT();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi hiện thời?Y/N", "Xác nhận" +
                "yêu cầu", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                sql = "Delete from tblGiangVien where MaGV='" + txtMaGV.Text + "'";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                grdData.Rows.RemoveAt(grdData.CurrentRow.Index);
                NapCT();
            }
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            sql = "Select MaGV,TenGV,DiaChi,SDT,NgaySinh,MaMon,Email from tblGiangVien order by MaGV";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdData.DataSource = dt;
            NapCT();

            grdData.CurrentCell = grdData[0, grdData.RowCount - 1];
            NapCT();
            MessageBox.Show("Hãy nhập nội dung bản ghi mới, kết thúc bấm Cập nhật!");
            txtMaGV.Focus();
            addnewflag = true;
            btnupdate.Enabled = true;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (addnewflag == false)
            {
                // Chỗ này là cập nhật sửa chữa
                for (i = 0; i < grdData.RowCount - 1; i++)
                {
                    txtMaGV.Text = grdData.Rows[i].Cells["MaGV"].Value.ToString();
                    txtTenGV.Text = grdData.Rows[i].Cells["TenGV"].Value.ToString();
                    txtDiaChi.Text = grdData.Rows[i].Cells["DiaChi"].Value.ToString();
                    txtSDT.Text = grdData.Rows[i].Cells["SDT"].Value.ToString();
                    txtNgaySinh.Text = grdData.Rows[i].Cells["NgaySinh"].Value.ToString();
                    txtMaMon.Text = grdData.Rows[i].Cells["MaMon"].Value.ToString();
                    txtEmail.Text = grdData.Rows[i].Cells["Email"].Value.ToString();
                   
                    sql = "set dateformat dmy update tblGiangVien set " +
                        " TenGV=N'" + txtTenGV.Text + "', DiaChi=N'" + txtDiaChi.Text + "'," +
                      " NgaySinh='" + txtNgaySinh.Text + "',MaMon='" + txtMaMon.Text +
                      "',Email='" + txtEmail.Text + "'"
                        + " where MaGV='" + txtMaGV.Text + "'";
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                }
            }
            else
            {
                //Chỗ này là cập nhật thêm mới
                addnewflag = false;
                sql = "insert into tblGiangVien(MaGV,TenGV,DiaChi,SDT,NgaySinh,MaMon,Email)" +
                    " Values ('" + txtMaGV.Text + "','" + txtTenGV.Text + "',N'" +
                    txtDiaChi.Text + "','" + txtNgaySinh.Text + "','" + txtSDT.Text + "','" + txtMaMon.Text + "','"
                    + txtEmail.Text + "')";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                grdData.Rows[i].Cells["MaGV"].Value = txtMaGV.Text;
                grdData.Rows[i].Cells["TenGV"].Value = txtTenGV.Text;
                grdData.Rows[i].Cells["DiaChi"].Value = txtDiaChi.Text;
                grdData.Rows[i].Cells["SDT"].Value = txtSDT.Text;
                grdData.Rows[i].Cells["NgaySinh"].Value = txtNgaySinh.Text;
                grdData.Rows[i].Cells["MaMon"].Value = txtMaMon.Text;
                grdData.Rows[i].Cells["Email"].Value = txtEmail.Text;
                
            }
            btnupdate.Enabled = false;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Hãy thực hiện mọi sửa đổi mong muốn trên ô lưới," +
                "kết thúc bằng nút cập nhật", "Thông báo", MessageBoxButtons.OK);
            btnupdate.Enabled = true;
        }

        private void NapCT()
        {
            i = grdData.CurrentRow.Index;
            txtMaGV.Text = grdData.Rows[i].Cells["MaGV"].Value.ToString();
            txtTenGV.Text = grdData.Rows[i].Cells["TenGV"].Value.ToString();
            txtDiaChi.Text = grdData.Rows[i].Cells["DiaChi"].Value.ToString();
            txtSDT.Text = grdData.Rows[i].Cells["SDT"].Value.ToString();
            txtNgaySinh.Text = grdData.Rows[i].Cells["NgaySinh"].Value.ToString();
            txtMaMon.Text = grdData.Rows[i].Cells["MaMon"].Value.ToString();
            txtEmail.Text = grdData.Rows[i].Cells["Email"].Value.ToString();
            
        }
    }
}
