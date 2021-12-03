using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace PPM_DAL
{
   
    public class CommonOperation
    {
        public void IsExist(string query, ref bool flag)
        {
            SqlConnection conn;
            SqlCommand cmd;
            //string con = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

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
                    flag = true;
                }
                else
                    flag = false;
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

        public void ExcuteQuery(string query)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=DESKTOP-VJ33EHT\\SQLEXPRESS;Initial Catalog=PPM;Integrated Security=True");
            try
            {
                conn.Open();
                string command = string.Format(query);
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



    }


}
