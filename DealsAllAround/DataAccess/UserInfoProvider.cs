using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DealsAllAround.DataAccess
{
    public class UserInfoProvider : IUserInfoProvider
    {
        private readonly string connectionString = ConfigurationProvider.GetDBConnectionString();

        public bool IsValid(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Login", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                    var reader = cmd.ExecuteReader();
                    bool isFound = reader.HasRows;
                    reader.Close();
                    reader.Dispose();
                    return isFound;
                }
            }
        }
        public void Registeration(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.InsertUser, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("@name", user.name);
                        cmd.Parameters.AddWithValue("@email", user.email);
                        cmd.Parameters.AddWithValue("@password", user.password);
                        cmd.Parameters.AddWithValue("@contact", user.contact);
                        cmd.Parameters.AddWithValue("@brand", user.brand);
                        cmd.Parameters.AddWithValue("@address", user.address);
                        cmd.Parameters.AddWithValue("@message", user.message);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
            }

        }
    }
}