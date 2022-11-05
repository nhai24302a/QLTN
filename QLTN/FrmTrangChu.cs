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
    }
}
