using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ModelLayer;

namespace DataAccessLayer
{
    public class DALUserAuth
    {//(ModelMI obj)
        public static async Task<ModelMI> Authenticate(string username, string userpass)
        {
            ModelMI MI = new ModelMI();
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("Userlogin", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@userpass", userpass);
                        using (SqlDataReader sdr = await cmd.ExecuteReaderAsync())
                        {
                            while (await sdr.ReadAsync())
                            {
                                MI.username= sdr["username"].ToString();
                                MI.roles = sdr["roles"].ToString();
                                MI.userid = sdr["userid"].ToString();



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or re-throw if necessary
            }
            Console.WriteLine(MI.username);
            return MI;
        }
    }








}

