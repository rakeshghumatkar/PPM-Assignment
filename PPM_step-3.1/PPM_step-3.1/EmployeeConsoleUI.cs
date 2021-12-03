using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
namespace PPM_step_3._1
{
    public class EmployeeConsoleUI 
    {
        public EmployeeModel InputEmployee()
        {
            EmployeeModel e = new EmployeeModel();
            try
            {
                Console.WriteLine(" - Enter the employee details :");

                Console.WriteLine(" Enter the employee Id");
                int eid = Convert.ToInt32(Console.ReadLine());
                e.empolyeeId = eid;

                Console.WriteLine(" Enter the emplyee first name ");
                string fname = Console.ReadLine();
                e.firstName = fname;

                Console.WriteLine(" Enter the emplyee last name ");
                string lname = Console.ReadLine();
                e.lastName = lname;

                Console.WriteLine("Enter the emplyee email Id ");
                string email = Console.ReadLine();
                e.emailID = email;

                Console.WriteLine(" Enter the emplyee phone number ");
                string phone = Console.ReadLine();
                e.phoneNo = phone;

                Console.WriteLine(" Enter the emplyee address ");
                string addrss = Console.ReadLine();
                e.address = addrss;
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
            return e;
        }

        public void EmployeeInputModule(ref int inputNo)
        {
            Console.WriteLine(" ~~~~~~~~~~~~~ Employee Module ~~~~~~~~~~~~~ ");
            Console.WriteLine("1. Add ");
            Console.WriteLine("2. List All");
            Console.WriteLine("3. List By ID ");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Update ");
            Console.WriteLine("6. Return To Main ");
            inputNo = int.Parse(Console.ReadLine());

        }

        public void ViewEmployeeList(List<EmployeeModel> employees)
        {
            var result = employees.Select(x => x);
            foreach(var emp in result)
            //for(int i=0; i< employees.Count; i++)
            {
                Console.WriteLine("\n - Employee Id " + emp.empolyeeId);
                Console.WriteLine("  - Name : " + emp.firstName + " " + emp.lastName);
                Console.WriteLine("  - Email Id : " + emp.emailID);
                Console.WriteLine("  - Phone No : " + emp.phoneNo);
                Console.WriteLine("  - Address : " + emp.address);
            }
        }

        public void ViewEmployee(EmployeeModel employee)
        {
            Console.WriteLine("\n - Employee Id " + employee.empolyeeId);
            Console.WriteLine("  - Name : " + employee.firstName + " " + employee.lastName);
            Console.WriteLine("  - Email Id : " + employee.emailID);
            Console.WriteLine("  - Phone No : " + employee.phoneNo);
            Console.WriteLine("  - Address : " + employee.address);
        }


        public EmployeeModel UpdateEmployee(int eid)
        {
            EmployeeModel e = new EmployeeModel();
            try
            {
                Console.WriteLine(" - Enter the employee details :");

                e.empolyeeId = eid;

                Console.WriteLine(" Enter the emplyee first name ");
                string fname = Console.ReadLine();
                e.firstName = fname;

                Console.WriteLine(" Enter the emplyee last name ");
                string lname = Console.ReadLine();
                e.lastName = lname;

                Console.WriteLine("Enter the emplyee email Id ");
                string email = Console.ReadLine();
                e.emailID = email;

                Console.WriteLine(" Enter the emplyee phone number ");
                string phone = Console.ReadLine();
                e.phoneNo = phone;

                Console.WriteLine(" Enter the emplyee address ");
                string addrss = Console.ReadLine();
                e.address = addrss;
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
            return e;
        }


    }
}
