using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using DealsAllAround.Data;
using System.Data;
using System.Diagnostics;

namespace DealsAllAround.Models
{
    public class DealsViewModel
    {
        public List<DealProvider> GetAllData()
        {
            List<DealProvider> dealsVM = new List<DealProvider>();
                        string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                        using (SqlConnection conn = new SqlConnection(connstring))
                        {
                            using (SqlCommand cmd = new SqlCommand("GetAllData", conn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                conn.Open();
                                SqlDataReader reader = cmd.ExecuteReader();
                                while (reader.Read())
                                {
                                    DealProvider dealpro = new DealProvider();
                                    dealpro.id = Convert.ToInt32(reader["id"]);
                                    dealpro.description = reader["description"].ToString();
                                    dealpro.price = Convert.ToInt32(reader["price"]);
                                    //dealpro.image = (byte[])reader["image"];
                                    dealpro.image = reader["image"].ToString();
                                    dealpro.createddate = Convert.ToDateTime(reader["createddate"]);
                                    dealsVM.Add(dealpro);
                                }
                            }
                }
                return dealsVM;            
        }

        public void GetDetails(DealProvider dealpro)
        {
                string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                            using (SqlConnection conn = new SqlConnection(connstring))
                            {
                                using (SqlCommand cmd = new SqlCommand("Insert_Product", conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    conn.Open();
                                    cmd.Parameters.AddWithValue("@description", dealpro.description);
                                    cmd.Parameters.AddWithValue("@price", dealpro.price);
                                    cmd.Parameters.AddWithValue("@image", dealpro.image);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }
           
        }

        public void UpdateData(DealProvider dealpro)
        {
            //try
            //{
                 string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                            using (SqlConnection conn = new SqlConnection(connstring))
                            {
                                using (SqlCommand cmd = new SqlCommand("UpdateData", conn))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    conn.Open();
                                    cmd.Parameters.AddWithValue("@description", dealpro.description);
                                    cmd.Parameters.AddWithValue("@price", dealpro.price);
                                    cmd.Parameters.AddWithValue("@id", dealpro.id);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                }
            }
        //    }
        //    catch (Exception ex)
        //    {
        //Debug.WriteLine("Exception Message: " + ex.Message);
        //    }
        }
        public DealProvider GetDetailById(int id)
        {
            
                DealProvider dealpro = new DealProvider();
                            string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                            using (SqlConnection conn = new SqlConnection(connstring))
                            {
                                using (SqlCommand cmd = new SqlCommand("GetDetailById ", conn))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    conn.Open();
                                    cmd.Parameters.AddWithValue("@id", id);
                                    SqlDataReader reader = cmd.ExecuteReader();
                                    reader.Read();
                                    dealpro.id = Convert.ToInt32(reader["id"]);
                                    dealpro.description = reader["description"].ToString();
                                    dealpro.price = Convert.ToInt32(reader["price"]);
                                }
                            }
                            return dealpro;
            
            
        }
      

        public void DeleteData(DealProvider dealpro)
        {
            try
            {
                 string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                            using (SqlConnection conn = new SqlConnection(connstring))
                            {
                                using (SqlCommand cmd = new SqlCommand("DeleteData", conn))
                                {
                                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                    conn.Open();
                                    cmd.Parameters.AddWithValue("@id", dealpro.id);
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
        public void Registeration(UserProvider userpro)
        {
            try
            {
                        string connstring = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                        using (SqlConnection conn = new SqlConnection(connstring))
                        {
                            using (SqlCommand cmd = new SqlCommand("Insert_User", conn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                conn.Open();
                                cmd.Parameters.AddWithValue("@name", userpro.name);
                                cmd.Parameters.AddWithValue("@email", userpro.email);
                                cmd.Parameters.AddWithValue("@password", userpro.password);
                                cmd.Parameters.AddWithValue("@contact", userpro.contact);
                                cmd.Parameters.AddWithValue("@brand", userpro.brand);
                                cmd.Parameters.AddWithValue("@address", userpro.address);
                                cmd.Parameters.AddWithValue("@message", userpro.message);
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

 