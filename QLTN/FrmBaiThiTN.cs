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
        int hours, minutes, counts;
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        DataTable dtch = new DataTable();
        DataTable dtda = new DataTable();
        string constr, sql;
        

        private void FrmBaiThiTN_Load(object sender, EventArgs e)
        {
            constr = "Data Source=DESKTOP-6H5PSI2\\SQLEXPRESS05;" +
              "Initial Catalog=QLTN;Integrated Security=True;";
            conn.ConnectionString = constr;
            conn.Open();
            timer1.Start();

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
                MessageBox.Show("you Lose");

            }
        }

        public FrmBaiThiTN(int h, int m, int s)
        {
            InitializeComponent();
            hours = h;
            minutes = m;
            counts = s;
        }
    }
}
