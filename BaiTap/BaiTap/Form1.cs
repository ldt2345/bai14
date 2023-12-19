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
namespace BaiTap
{
    public partial class Form1 : Form
    {
        KetNoi kn;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnkn_Click(object sender, EventArgs e)
        {
            if (txttenmay.Text.Length == 0)
            {
                MessageBox.Show("Tên máy không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttenmay.Focus();
            }
            if (txttencsdl.Text.Length == 0)
            {
                MessageBox.Show("Tên csdl không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttencsdl.Focus();
            }
            else
            {
                SqlConnection conn;
                try
                {
                    string connectionstring = "";
                    //connectionstring = "server=" + txttenmay.Text;
                    //connectionstring += ";database=" + txttencsdl.Text;
                    connectionstring += ";uid=" + txtuser.Text;
                    connectionstring += ";pwd=" + txtpass.Text;
                    kn = new KetNoi(connectionstring);
                    conn = KetNoi.conn;
                    //conn.ConnectionString = connectionstring;
                    conn.Open();
                    MessageBox.Show("Kết nối thành công");
                    conn.Close();
                    Form3 frm = new Form3();
                    frm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối thất bại");
                }
            }
        }
    }
}
