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
    public partial class FrmMonThi : Form
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
        public FrmMonThi()
        {
            InitializeComponent();
        }

        private void FrmMonThi_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05 " +
                                                   "Initial Catalog=QLTN;Integrated Security=True";
            conn.ConnectionString = constr;
            conn.Open();
            sql = "Select * from tblMonThi order by MaMon";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            grdData.DataSource = dt;

        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            sql = "Select MaMon,TenMon,SoCau,SoCD,SoCK from tblMonThi order by MaMon";
            da = new SqlDataAdapter(sql, conn);
            dt.Clear();
            da.Fill(dt);
            grdData.DataSource = dt;
            NapCT();

            grdData.CurrentCell = grdData[0, grdData.RowCount - 1];
            NapCT();
            MessageBox.Show("Hãy nhập nội dung bản ghi mới, kết thúc bấm Cập nhật!");
            txtMaMon.Focus();
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
                sql = "Delete from tblMonThi where MaMon='" + txtMaMon.Text + "'";
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
                    txtMaMon.Text = grdData.Rows[i].Cells["MaMon"].Value.ToString();
                    txtTenMon.Text = grdData.Rows[i].Cells["TenMon"].Value.ToString();
                    txtSoCau.Text = grdData.Rows[i].Cells["SoCau"].Value.ToString();
                    txtSoCD.Text = grdData.Rows[i].Cells["SoCD"].Value.ToString();
                    txtSoCK.Text = grdData.Rows[i].Cells["SoCK"].Value.ToString();
                 
                    sql = "update tblMonThi set " +
                        "TenMon=N'" + txtTenMon.Text + "'" +
                       ",SoCau='" + txtSoCau.Text + "',SoCD='" + txtSoCD.Text + "',SoCK='" + txtSoCK.Text + "'"
                        + " where MaMon='" + txtMaMon.Text + "'";
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                }
            }
            else
            {
                //Chỗ này là cập nhật thêm mới
                addnewflag = false;
                sql = "insert into tblMonThi(MaMon,TenMon,SoCau,SoCD,SoCK)" +
                    " Values ('" + txtMaMon.Text + "',N'" + txtTenMon.Text + "','" + txtSoCau.Text + "','" + txtSoCD.Text + "','" + txtSoCK.Text + "')";
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                grdData.Rows[i].Cells["MaMon"].Value = txtMaMon.Text;
                grdData.Rows[i].Cells["TenMon"].Value = txtTenMon.Text;
                grdData.Rows[i].Cells["SoCau"].Value = txtSoCau.Text;
                grdData.Rows[i].Cells["SoCD"].Value = txtSoCD.Text;
                grdData.Rows[i].Cells["SoCK"].Value = txtSoCK.Text;
             


            }
            btnupdate.Enabled = false;
        }

        private void NapCT()
        {
            i = grdData.CurrentRow.Index;
            txtMaMon.Text = grdData.Rows[i].Cells["MaCa"].Value.ToString();
            txtMaMon.Text = grdData.Rows[i].Cells["MaMon"].Value.ToString();
            txtTenMon.Text = grdData.Rows[i].Cells["TenMon"].Value.ToString();
            txtSoCau.Text = grdData.Rows[i].Cells["SoCau"].Value.ToString();
            txtSoCD.Text = grdData.Rows[i].Cells["SoCD"].Value.ToString();
            txtSoCK.Text = grdData.Rows[i].Cells["SoCK"].Value.ToString();


        }
    }
}
