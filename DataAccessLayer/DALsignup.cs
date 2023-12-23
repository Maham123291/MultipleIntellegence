using System.Data.SqlClient;
using ModelLayer;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALsignup
    {
        public static void InsertUser(string userid, string username, string userpass, string useremail, string roles)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                string insertQuery = "INSERT INTO MI (username, userid, userpass, useremail, roles) " +
                                     "VALUES (@username, @userid, @userpass, @useremail, @roles)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                { 
                    
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@userpass", userpass);
                    cmd.Parameters.AddWithValue("@useremail", useremail);
                    cmd.Parameters.AddWithValue("@roles", roles);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}