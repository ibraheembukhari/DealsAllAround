using System.Data.SqlClient;
using System.Configuration;

namespace DealsAllAround.Models
{
    public class ApplicationUser
    {
        public string email { get; set; }
        public string password { get; set; }
        public bool rememberme { get; set; }
        public string sessions { get; set; }
        public bool IsValid(string email, string password) 
        {
            string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                using (SqlCommand cmd = new SqlCommand("Login", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                    var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
              }
            }
        }
    }
}
