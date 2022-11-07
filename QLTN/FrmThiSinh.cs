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
    public partial class FrmThiSinh : Form
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
        public FrmThiSinh()
        {
            InitializeComponent();
        }

        private void FrmThiSinh_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05;" +
                                       "Initial Catalog=QLTN;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select * from tblThiSinh order by MaSV";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;
            NapCT();
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NapCT();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi hiện thời?Y/N", "Xác nhận" +
                "yêu cầu", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                sql = "Delete from tblThiSinh where MaGV='" + txtMaSV.Text + "'";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                grdData.Rows.RemoveAt(grdData.CurrentRow.Index);
                NapCT();
            }
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            sql = "Select MaSV,HoTen,DiaChi,NgaySinh,MaKhoa,MaLop from tblGiangVien order by MaGV";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdData.DataSource = dt;
            NapCT();

            grdData.CurrentCell = grdData[0, grdData.RowCount - 1];
            NapCT();
            MessageBox.Show("Hãy nhập nội dung bản ghi mới, kết thúc bấm Cập nhật!");
            txtMaSV.Focus();
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
                    txtMaSV.Text = grdData.Rows[i].Cells["MaSV"].Value.ToString();
                    txtHoTen.Text = grdData.Rows[i].Cells["HoTen"].Value.ToString();
                    txtDiaChi.Text = grdData.Rows[i].Cells["DiaChi"].Value.ToString();
                    txtNgaySinh.Text = grdData.Rows[i].Cells["NgaySinh"].Value.ToString();
                    txtMaKhoa.Text = grdData.Rows[i].Cells["MaKhoa"].Value.ToString();
                    txtMaLop.Text = grdData.Rows[i].Cells["MaLop"].Value.ToString();

                    sql = "set datefomart dmy update tblThiSinh set " +
                        " HoTen=N'" + txtHoTen.Text + "', DiaChi=N'" + txtDiaChi.Text + "'," +
                      " NgaySinh=N'" + txtNgaySinh.Text + "',MaKhoa='" + txtMaKhoa.Text +
                      "',MaLop='" + txtMaLop.Text + "'"
                        + " where MaSV='" + txtMaSV.Text + "'";
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                }
            }
            else
            {
                //Chỗ này là cập nhật thêm mới
                addnewflag = false;
                sql = "insert into tblGiangVien(MaGV,TenGV,DiaChi,SDT,NgaySinh,MaMon,Email,MaTK)" +
                    " Values ('" + txtMaSV.Text + "','" + txtHoTen.Text + "',N'" +
                    txtDiaChi.Text + "','" + txtNgaySinh.Text + "','" + txtMaKhoa.Text + "','" + txtMaLop.Text + "')";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                grdData.Rows[i].Cells["MaSV"].Value = txtMaSV.Text;
                grdData.Rows[i].Cells["HoTen"].Value = txtHoTen.Text;
                grdData.Rows[i].Cells["DiaChi"].Value = txtDiaChi.Text;
                grdData.Rows[i].Cells["NgaySinh"].Value = txtNgaySinh.Text;
                grdData.Rows[i].Cells["MaKhoa"].Value = txtMaKhoa.Text;
                grdData.Rows[i].Cells["MaLop"].Value = txtMaLop.Text;

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
            txtMaSV.Text = grdData.Rows[i].Cells["MaSV"].Value.ToString();
            txtHoTen.Text = grdData.Rows[i].Cells["HoTen"].Value.ToString();
            txtDiaChi.Text = grdData.Rows[i].Cells["DiaChi"].Value.ToString();
            txtNgaySinh.Text = grdData.Rows[i].Cells["NgaySinh"].Value.ToString();
            txtMaKhoa.Text = grdData.Rows[i].Cells["MaKhoa"].Value.ToString();
            txtMaLop.Text = grdData.Rows[i].Cells["MaLop"].Value.ToString();
            

        }
    }
}
