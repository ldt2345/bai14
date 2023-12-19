using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BaiTap
{
    public class KetNoi
    {
        public static SqlConnection conn;

        public KetNoi()
        {
            conn = new SqlConnection("Data Source=A209PC49;Initial Catalog=BAI14;Integrated Security=True");
        }
        public KetNoi(string strcn)
        {
            conn = new SqlConnection(strcn);
        }
    }
}