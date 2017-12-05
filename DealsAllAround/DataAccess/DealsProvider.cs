using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using DealsAllAround.Models;

namespace DealsAllAround.DataAccess
{
    public class DealsProvider : IDealsProvider
    {
        private readonly string connectionString = ConfigurationProvider.GetDBConnectionString();

        public List<Deal> GetAllData()
        {
            List<Deal> dealsVM = new List<Deal>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllData", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Deal dealpro = new Deal();
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

        public void GetDetails(Deal dealpro)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_Product", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@description", dealpro.description);
                    cmd.Parameters.AddWithValue("@price", dealpro.price);
                    cmd.Parameters.AddWithValue("@image", dealpro.image);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void UpdateData(Deal dealpro)
        {
            //try
            //{
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateData", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@description", dealpro.description);
                    cmd.Parameters.AddWithValue("@price", dealpro.price);
                    cmd.Parameters.AddWithValue("@id", dealpro.id);
                    cmd.ExecuteNonQuery();
                }
            }
            //    }
            //    catch (Exception ex)
            //    {
            //Debug.WriteLine("Exception Message: " + ex.Message);
            //    }
        }
        public Deal GetDetailById(int id)
        {

            Deal dealpro = new Deal();
            using (SqlConnection conn = new SqlConnection(connectionString))
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


        public void DeleteData(Deal dealpro)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteData", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("@id", dealpro.id);
                        cmd.ExecuteNonQuery();
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