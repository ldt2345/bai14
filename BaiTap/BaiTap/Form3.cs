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
    public partial class Form3 : Form
    {

        SqlConnection conn  = KetNoi.conn;
        SqlDataAdapter da;
        DataSet ds;
        DataColumn[] key = new DataColumn[1];
        public Form3()
        {
          
            InitializeComponent();
        }
       


        private void btnthoat_Click(object sender, EventArgs e)
        {
           
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }

        }
        void Load_ComboBox()
        {
            conn.Open();
            string select = "select * from COSO";
            SqlCommand cmd = new SqlCommand(select, conn);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cbocoso.Items.Add(rd["MACOSO"].ToString());
                }
                cbocoso.SelectedIndex = 0;
                rd.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            } 
        }
        void Load_ComboBoxDonVi()
        {
            conn.Open();
            string select = "select * from DONVI";
            SqlCommand cmd = new SqlCommand(select, conn);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cbocoso.Items.Add(rd["MADONVI"].ToString());
                }
                cbodonvi.SelectedIndex = 0;
                rd.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
        }
        void Load_grid()
        {
            dgvdanhsach.DataSource = ds.Tables[0];
            string select = "select * from GV";
            da = new SqlDataAdapter(select, conn);
            ds = new DataSet();
            da.Fill(ds, "GV");
            key[0] = ds.Tables["GV"].Columns[0];
            ds.Tables["GV"].PrimaryKey = key;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Load_ComboBox();
            Load_ComboBoxDonVi();
        }
    }
}
