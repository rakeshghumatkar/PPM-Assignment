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

        public void ViewAllRole(List<RoleModel> roles)
        {
            try
            {
                var result = roles.Select(x => x);
                foreach(var role in result)
                //for (int i = 0; i < roles.Count; i++)
                {
                    Console.WriteLine("\n- Role Id : " + role.roleId);
                    Console.WriteLine(" - Role Name : " + role.roleName);
                    
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

        public void RoleInputModule(ref int inputNo)
        {
            Console.WriteLine(" ~~~~~~~~~~~~~ Role Module ~~~~~~~~~~~~~ ");
            Console.WriteLine("1. Add ");
            Console.WriteLine("2. List All");
            Console.WriteLine("3. List By ID ");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Update ");
            Console.WriteLine("6. Return To Main ");
            inputNo = int.Parse(Console.ReadLine());

        }
    
    public void ViewRole(RoleModel role)
        {
            Console.WriteLine("\n- Role Id : " + role.roleId);
            Console.WriteLine(" - Role Name : " + role.roleName);
        }
    }
}
