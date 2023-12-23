using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessLayer
{
    public class DalMI
    {
        public static List<ModelMI> GetMI()
        {
            using SqlConnection con = DBHelper.GetConnection();
            con.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM MI", con);
            using SqlDataReader sqlDataReaderreader = cmd.ExecuteReader();
            List<ModelMI> listProjects = new List<ModelMI>();
            while (sqlDataReaderreader.Read())
            {
                ModelMI modelMI = new ModelMI();
                modelMI.username = sqlDataReaderreader["username"].ToString();
                modelMI.userid = sqlDataReaderreader["userid"].ToString();
                modelMI.userpass = sqlDataReaderreader["userpass"].ToString();
                modelMI.useremail = sqlDataReaderreader["useremail"].ToString();
                modelMI.roles = sqlDataReaderreader["roles"].ToString();
                listProjects.Add(modelMI);
            }

            return listProjects;
        }

        public static void SaveUser(ModelMI user)
        {
            using SqlConnection con = DBHelper.GetConnection();
            con.Open();
            using SqlCommand cmd = new SqlCommand("SP_SaveUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@roles", user.roles);
            cmd.Parameters.AddWithValue("@userid", user.userid);
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@userpass", user.userpass);
            cmd.Parameters.AddWithValue("@useremail", user.useremail);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<ModelMI> GetUsers()
        {
            using SqlConnection con = DBHelper.GetConnection();
            con.Open();
            using SqlCommand cmd = new SqlCommand("SP_GetUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<ModelMI> listusers = new List<ModelMI>();
            while (reader.Read())
            {
                ModelMI model = new ModelMI();
                model.roles = reader["roles"].ToString();
                model.userid = reader["userid"].ToString();
                model.username = reader["username"].ToString();
                model.userpass = reader["userpass"].ToString();
                model.useremail = reader["useremail"].ToString();
                listusers.Add(model);
            }
            con.Close();
            return listusers;

        }



        /* public static void UpdateUser(ModelMI user)
         {
             using SqlConnection con = DBHelper.GetConnection();
             con.Open();
             using SqlCommand cmd = new SqlCommand("SP_UpdateUser", con);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@userid", user.userid);
             cmd.Parameters.AddWithValue("@username", user.username);
             cmd.Parameters.AddWithValue("@useremail", user.useremail);
             cmd.ExecuteNonQuery();
             con.Close();
         }*/



        public static void DeleteUser(string id)
        {
            using SqlConnection con = DBHelper.GetConnection();
            con.Open();
            using SqlCommand cmd = new SqlCommand("SP_DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}