using System;
using System.Collections.Generic;

namespace PPM_step_3
{
    public class Role
    {
        public int roleId { get; set; }

        public List<string> roleNames = new List<string>();
        public Role()
        {
            try
            {
                Console.WriteLine("Enter the Role Id ");
                roleId = Convert.ToInt32(Console.ReadLine());
                int role_option;
                do
                {

                    Console.WriteLine("Enter the value with respective following operations : ");
                    Console.WriteLine("1. Add Role");
                    Console.WriteLine("2. Exist");
                    role_option = Convert.ToInt32(Console.ReadLine());

                    switch (role_option)
                    {
                        case 1:
                            AddRole();
                            break;

                        default:
                            break;

                    }


                }
                while (role_option <= 1);
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

        public Role(int roleId)
        {
            this.roleId = roleId;

        }


        public Role(int roleId, string roleName)
        {
            this.roleId = roleId;
            string a = roleName;
            roleNames.Add(a);
        }

        public void AddRole()
        {
            Console.WriteLine("Enter the employee-role : ");
            string role = Console.ReadLine();
            roleNames.Add(role);

        }




        public void ViewRole()
        {
            Console.WriteLine("    - Role Id : " + roleId);
            for (int i = 0; i < roleNames.Count; i++)
            {
                Console.WriteLine("      Roles : " + roleNames[i]);
            }

        }
    }
}
