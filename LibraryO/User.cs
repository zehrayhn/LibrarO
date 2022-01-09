using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryO
{
    class User
    {
        public static int UserId = 0;
        public static bool status = false;
        public static SqlDataReader KullaniciGirisi(TextBox UserName, TextBox Password)
        {
            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-32MH31K;Initial Catalog=DbLibrary;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select *from Employee where EmpName='" + UserName.Text + "' and EmpPassword='" + Password.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                status = true;
                UserId = int.Parse(dr["Id"].ToString());

            }
            else
            {
                status = false;

            }
            con.Close();
            return dr;
        }
    }
}
