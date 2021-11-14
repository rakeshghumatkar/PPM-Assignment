using System;
using BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_step_3._1
{
    public class RoleConsoleUI 
    {
        public RoleModel InputRole()
        {
            RoleModel r = new RoleModel();
            try
            {
                Console.WriteLine(" - Enter the Role-ID");
                r.roleId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(" - Enter the Role Of Employee ");
                r.roleName = Console.ReadLine();
                //r.AddRole(str);
                
            }
            catch (FormatException ex1)
            {
                Console.WriteLine("Please enter the Numeric value only");
                Console.WriteLine(ex1.Message);
            }

            catch (StackOverflowException ex2)
            {
                Console.WriteLine("Enter only the single digit value");
                Console.WriteLine(ex2.Message);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }


            return r;
        }

        public void ViewRole(List<RoleModel> roles)
        {
            try
            {
                for (int i = 0; i < roles.Count; i++)
                {
                    Console.WriteLine("\n- Role Id : " + roles[i].roleId);
                    Console.WriteLine(" - Role Name : " + roles[i].roleName);
                    /*for (int j = 0; j < roles[i].roleNames.Count; j++)
                    {  
                        Console.WriteLine("   Roles : " + roles[i].roleNames[j]);
                    }*/
                }
            }
            catch (FormatException ex1)
            {
                Console.WriteLine("Please enter the Numeric value only");
                Console.WriteLine(ex1.Message);
            }

            catch (StackOverflowException ex2)
            {
                Console.WriteLine("Enter only the single digit value");
                Console.WriteLine(ex2.Message);
            }
            catch (Exception ex3)
            {
                Console.Write(ex3.ToString());
            }



        }
    }
}
