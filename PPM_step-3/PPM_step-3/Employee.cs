using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPM_step_3
{
    public class Employee
    {
        public int empolyeeId { get; set; }
        public int roleId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailID { get; set; }
        public string phoneNo { get; set; }
        public string address { get; set; }

        public List<Role> employeesRoles = new List<Role>();


        //Default contructor
        public Employee()
        {
            try
            {
                Console.WriteLine(" - Enter the employee details :");

                Console.WriteLine(" Enter the employee Id");
                int eid = Convert.ToInt32(Console.ReadLine());
                empolyeeId = eid;

               /* Console.WriteLine(" Enter the emplyee role Id");
                int rid = Convert.ToInt32(Console.ReadLine());

                bool flag = false;
                for (int i = 0; i < Program.roleList.Count; i++)
                {
                    //Role is already exist than assign to it
                    if (rid == Program.roleList[i].roleId)
                    {
                        flag = true;
                        employeesRoles.Add(Program.roleList[i]);
                    }
                }

                if (!flag)
                {
                    Console.WriteLine("Oops! Role is not Found");
                }*/

                Console.WriteLine(" Enter the emplyee first name ");
                string fname = Console.ReadLine();
                firstName = fname;

                Console.WriteLine(" Enter the emplyee last name ");
                string lname = Console.ReadLine();
                lastName = lname;

                Console.WriteLine("Enter the emplyee email Id ");
                string email = Console.ReadLine();
                emailID = email;

                Console.WriteLine(" Enter the emplyee phone number ");
                string phone = Console.ReadLine();
                phoneNo = phone;

                Console.WriteLine(" Enter the emplyee address ");
                string addrss = Console.ReadLine();
                address = addrss;
            }
            catch (FormatException ex1)
            {
                Console.WriteLine(" Enter input proper value ");
                Console.WriteLine(ex1.Message);
            }

            catch (StackOverflowException ex2)
            {
                Console.WriteLine(ex2.Message);
            }
            catch (Exception ex3)
            {
                Console.Write(ex3.ToString());
            }
        }

        // single value contructor
        public Employee(int eid)
        { empolyeeId = eid; }


        //para contructor
        public Employee(int eid, string fname, string lname, string email, string phone, string addrss)
        {
            empolyeeId = eid;
            firstName = fname;
            lastName = lname;
            emailID = email;
            phoneNo = phone;
            address = addrss;

        }



        public void AddRoles()
        {
            //Add Role function
            Role role = new Role(roleId);
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
                        role.AddRole();
                        break;

                    default:
                        break;

                }


            }
            while (role_option <= 1);

        }

        public void AddRolesToEmployee()
        {
            //Assign role to employee
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
                        int k = employeesRoles.Count - 1;
                        employeesRoles[k].AddRole();
                        break;

                    default:
                        break;

                }


            }
            while (role_option <= 1);

        }

        public void ShowEmployeeDetails()
        {
            Console.WriteLine("  - Employee Id " + empolyeeId);

            for (int i = 0; i < employeesRoles.Count; i++)
            {
                employeesRoles[i].ViewRole();
            }
            Console.WriteLine("  - Name : " + firstName + " " + lastName);
            Console.WriteLine("  - Email Id : " + emailID);
            Console.WriteLine("  - Phone No : " + phoneNo);
            Console.WriteLine("  - Address : " + address);
            Console.WriteLine();
        }
    }
}
