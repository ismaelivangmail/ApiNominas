using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ApiNominas.Models
{
    public class CRUDSalary
    {
        public List<Salary> getSalary()
        {
            List<Salary> list = new List<Salary>();
            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Salaries_GetAll";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int EmpId = dr.GetInt32(0);
                    string FullName = dr.GetString(1).Trim();
                    decimal Qty = dr.GetDecimal(2);
                    int PayId = dr.GetInt32(3);
                    string PayDesc = dr.GetString(4).Trim();

                    Salary Salary_ = new Salary(EmpId, FullName, Qty, PayId, PayDesc);

                    list.Add(Salary_);
                }

                dr.Close();
                conn.Close();
            }

            return list;

        }

        public bool addSalary(Salary Salary_)
        {
            bool result = false;

            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Salaries_Insert";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", Salary_.EmpId);
                cmd.Parameters.AddWithValue("@Qty", Salary_.Qty);
                cmd.Parameters.AddWithValue("@PayId", Salary_.PayId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    result = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return result;
            }

        }

        public bool updateSalary(int EmpId_, Salary Salary_)
        {
            bool result = false;

            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Salaries_Save";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", EmpId_);
                cmd.Parameters.AddWithValue("@Qty", Salary_.Qty);
                cmd.Parameters.AddWithValue("@PayId", Salary_.PayId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    result = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return result;
            }

        }

        public bool deleteSalary(int EmpId_)
        {
            bool result = false;

            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Salaries_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", EmpId_);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    result = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return result;
            }



        }
    }
}
