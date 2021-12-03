using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_DAL
{
    public class EmployeesDA
    {
        public void SaveEmployee(int employeeId, string firstName, string lastName, string emailId, string phoneNo, string address, int roleID)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            try
            {

                conn.Open();
                string command = string.Format("insert into Employees(employeeId, firstName, lastName, emailId, phoneNo, eAddress, createDate, modifiedDate, roleID) values (" + employeeId + ",'" + firstName + "','" + lastName + "','" + emailId + "','" + phoneNo + "','" + address + "', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, "+roleID+");");
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


        public void DeleteEmployee(int empid)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            //Role Store in DB
            try
            {
                conn.Open();
                string command = string.Format("delete from Employees where employeeId = " + empid + ";");
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

        public void GetEmployee(string query)
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
                        Console.WriteLine(" {0}  {1}  {2}  {3}  {4} {5}  {6}  {7}", reader["employeeId"], reader["firstName"], reader["lastName"], reader["emailId"], reader["phoneNo"], reader["eAddress"], reader["createDate"], reader["modifiedDate"]);
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
