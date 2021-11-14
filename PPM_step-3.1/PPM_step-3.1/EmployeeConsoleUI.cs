using System;
using System.Collections.Generic;
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

        public void ViewEmployeeList(List<EmployeeModel> employees)
        {
            for(int i=0; i< employees.Count; i++)
            {
                Console.WriteLine("\n - Employee Id " + employees[i].empolyeeId);
                Console.WriteLine("  - Name : " + employees[i].firstName + " " + employees[i].lastName);
                Console.WriteLine("  - Email Id : " + employees[i].emailID);
                Console.WriteLine("  - Phone No : " + employees[i].phoneNo);
                Console.WriteLine("  - Address : " + employees[i].address);
            }
    
        }
    }
}
