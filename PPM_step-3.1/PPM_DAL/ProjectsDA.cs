using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_DAL
{
    public class ProjectsDA
    {

        public void SaveProject(int projectId, string projectName, string description, DateTime startDate, DateTime endDate)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            try
            {
                conn.Open();
                string command = string.Format("insert into Projects(projectId, projectName, pdescription, startDate, endDate, createDate, modifiedDate) values (" + projectId + ", '" +projectName + "', '" + description + "','" + startDate + "','" + endDate + "', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);");
                cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

      
        public void DeleteProject(int pid)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            //Role Store in DB
            try
            {
                conn.Open();
                string command = string.Format("delete from Projects where projectId = " + pid + ";");
                cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public void GetProject(string query)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            //Project Store in DB
            try
            {
                conn.Open();
                string command = string.Format(query);
                cmd = new SqlCommand(command, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(" {0}  {1}  {2}  {3}  {4}  {5}  {6}", reader["projectId"], reader["projectName"],  reader["pdescription"], reader["startDate"], reader["endDate"], reader["createDate"], reader["modifiedDate"]);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void GetProjectWithEmployees(string query)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            //Project Store in DB
            try
            {
                conn.Open();
                string command = string.Format(query);
                cmd = new SqlCommand(command, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(" {0}  {1}  {2}  {3}  {4}", reader["projectId"], reader["projectName"], reader["employeeId"], reader["firstName"], reader["lastName"]);
                        
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void GetEmployeeWithRole(string query)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            //Project Store in DB
            try
            {
                conn.Open();
                string command = string.Format(query);
                cmd = new SqlCommand(command, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(" {0}  {1}  {2}  {3}  {4}", reader["employeeId"], reader["firstName"], reader["lastName"], reader["roleId"], reader["roleName"]);

                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void GetProjectsWithEmployeesAndRoles(string query)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            //Project Store in DB
            try
            {
                conn.Open();
                string command = string.Format(query);
                cmd = new SqlCommand(command, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(" {0}  {1}  {2}  {3}  {4}  {5}  {6}", reader["projectId"], reader["projectName"], reader["employeeId"], reader["firstName"], reader["lastName"], reader["roleId"], reader["roleName"]);

                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
