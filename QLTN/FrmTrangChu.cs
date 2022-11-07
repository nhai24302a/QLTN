using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTN
{
    public partial class FrmTrangChu : Form
    {
        string tenuser;
        public FrmTrangChu(string username)
        {
            InitializeComponent();
            tenuser = username;
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            lblHi.Text = lblHi.Text + " " + tenuser;
        }

        private void câuHỏiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnl2.Controls.Clear();
            FrmCauHoi frm2 = new FrmCauHoi(tenuser);
            frm2.TopLevel = false;
            pnl2.Controls.Add(frm2);
            frm2.Dock = DockStyle.Fill;
            frm2.Show();
        }

        private void mônThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnl2.Controls.Clear();
            FrmMonThi frm2 = new FrmMonThi();
            frm2.TopLevel = false;
            pnl2.Controls.Add(frm2);
            frm2.Dock = DockStyle.Fill;
            frm2.Show();
        }

        private void caThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnl2.Controls.Clear();
            FrmCaThi frm2 = new FrmCaThi();
            frm2.TopLevel = false;
            pnl2.Controls.Add(frm2);
            frm2.Dock = DockStyle.Fill;
            frm2.Show();
        }

        private void quảnLýThíSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnl2.Controls.Clear();
            FrmThiSinh frm2 = new FrmThiSinh();
            frm2.TopLevel = false;
            pnl2.Controls.Add(frm2);
            frm2.Dock = DockStyle.Fill;
            frm2.Show();
        }

        private void quảnLýGiảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnl2.Controls.Clear();
            FrmGiangVien frm2 = new FrmGiangVien();
            frm2.TopLevel = false;
            pnl2.Controls.Add(frm2);
            frm2.Dock = DockStyle.Fill;
            frm2.Show();
        }

        private void lưuTrữBàiLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnl2.Controls.Clear();
            FrmBangDiem frm2 = new FrmBangDiem();
            frm2.TopLevel = false;
            pnl2.Controls.Add(frm2);
            frm2.Dock = DockStyle.Fill;
            frm2.Show();
        }
    }
}
