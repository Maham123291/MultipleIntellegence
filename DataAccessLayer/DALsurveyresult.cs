
using System.Data.SqlClient;
using ModelLayer;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.ComponentModel;

namespace DataAccessLayer
{
    public class DALsurveyresult
    {
        public static void Insertresponse(string userid,string username, string Category, decimal Percentage)
        {
            ModelMI MII = new ModelMI();
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                string insertQuery = "INSERT INTO surveyresult (userid,username, Category, Percentage) " +
                                     "VALUES (@userid,@username, @Category, @Percentage)";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@userid", userid);
                        cmd.Parameters.AddWithValue("@username",username);
                        cmd.Parameters.AddWithValue("@Category", Category);
                        cmd.Parameters.AddWithValue("@Percentage", Percentage);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    // Handle or log the exception
                    Console.WriteLine("SQL Exception: " + ex.Message);
                    // Optionally, rethrow the exception for higher-level handling
                    throw;
                }
            }
        }

        public static List<Modelsurveyresult> Getsurveyresult()
        {
            SqlConnection con = DBHelper.GetConnection();
            SqlCommand cmd = new SqlCommand("select * from surveyresult ", con);
            con.Open();
            SqlDataReader sqlDataReaderreader = cmd.ExecuteReader();
            List<Modelsurveyresult> listProjects = new List<Modelsurveyresult>();
            while (sqlDataReaderreader.Read())
            {
                Modelsurveyresult modelMR= new Modelsurveyresult();
                modelMR.username = sqlDataReaderreader["username"].ToString();
                modelMR.Category = sqlDataReaderreader["Category"].ToString();
                modelMR.Percentage = Convert.ToDecimal(sqlDataReaderreader["Percentage"]);
               
                listProjects.Add(modelMR);


            }
            con.Close();
            return listProjects;

        }




    }
}
