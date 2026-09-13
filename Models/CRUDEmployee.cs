using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ApiNominas.Models
{
    public class CRUDEmployee
    {
        public List<Employee> getEmployee()
        {
            List<Employee> list = new List<Employee>();
            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Employees_GetAll";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int EmpId = dr.GetInt32(0);
                    string FullName = dr.GetString(1).Trim();
                    DateTime JoinDate = dr.GetDateTime(2);
                    DateTime BirthDate = dr.GetDateTime(3);
                    int DeptId = dr.GetInt32(4);
                    string DeptDesc = dr.GetString(5).Trim();

                    Employee Employee_ = new Employee(EmpId, FullName, JoinDate, BirthDate, DeptId, DeptDesc);

                    list.Add(Employee_);
                }

                dr.Close();
                conn.Close();
            }

            return list;

        }

        public bool addEmployee(Employee Employee_)
        {
            bool result = false;

            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Employees_Insert";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", Employee_.EmpId);
                cmd.Parameters.AddWithValue("@FullName", Employee_.FullName);
                cmd.Parameters.AddWithValue("@JoinDate", Employee_.JoinDate);
                cmd.Parameters.AddWithValue("@BirthDate", Employee_.BirthDate);
                cmd.Parameters.AddWithValue("@DeptId", Employee_.DeptId);

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

        public bool updateEmployee(int EmpId_, Employee Employee_)
        {
            bool result = false;

            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Employees_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", EmpId_);
                cmd.Parameters.AddWithValue("@FullName", Employee_.FullName);
                cmd.Parameters.AddWithValue("@JoinDate", Employee_.JoinDate);
                cmd.Parameters.AddWithValue("@BirthDate", Employee_.BirthDate);
                cmd.Parameters.AddWithValue("@DeptId", Employee_.DeptId);

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

        public bool deleteEmployee(int EmpId_)
        {
            bool result = false;

            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Employees_Delete";
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
