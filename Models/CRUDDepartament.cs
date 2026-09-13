using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ApiNominas.Models
{
    public class CRUDDepartment
    {
        public List<Department> getDepartment()
        {
            List<Department> list = new List<Department>();
            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Departments_GetAll";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int DeptId = dr.GetInt32(0);
                    string DeptDesc = dr.GetString(1).Trim();

                    Department Department_ = new Department(DeptId, DeptDesc);

                    list.Add(Department_);
                }

                dr.Close();
                conn.Close();
            }

            return list;

        }

        public bool addDepartment(Department Department_)
        {
            bool result = false;

            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Departments_Insert";
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@DeptId", Department_.DeptId);
                cmd.Parameters.AddWithValue("@DeptDesc", Department_.DeptDesc);

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

        public bool updateDepartment(int DeptId_, Department Department_)
        {
            bool result = false;

            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Departments_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DeptId", DeptId_);
                cmd.Parameters.AddWithValue("@DeptDesc", Department_.DeptDesc);

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

        public bool deleteDepartment(int DeptId_)
        {
            bool result = false;

            string strConn = ConfigurationManager.ConnectionStrings["LOCAL"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "sp_Departments_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DeptId", DeptId_);

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