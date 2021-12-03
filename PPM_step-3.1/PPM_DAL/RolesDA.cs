using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_DAL
{
    public class RolesDA
    {
        public void SaveRole(int roleId, string roleName)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            //Role Store in DB
            try
            {
                conn.Open();
                string command = string.Format("insert into Roles (roleId, roleName, createDate, modifiedDate) values (" + roleId + ",'" + roleName + "', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP);");
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

        public void DeleteRole(int rid)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            //Role Store in DB
            try
            {
                conn.Open();
                string command = string.Format("delete from Roles where roleId = " + rid + ";");
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

        public void GetRole(string query)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            //Role Store in DB
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
                        Console.WriteLine(" {0}  {1} ", reader["roleId"], reader["roleName"]);
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
