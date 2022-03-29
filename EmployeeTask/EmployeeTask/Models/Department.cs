using EmployeeTask.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models
{
    public class Department
    {
        private int _employeeLimit;

        public string Name { get; set; }
        public int EmployeeLimit { get { return _employeeLimit; } set { if(value > 0 && value < 1000000) _employeeLimit = value; } }

        //public Employee this[int index]
        //{
        //    get { return employees[index]; }
        //    set { employees[index] = value; }
        //}

        //Employee[] employees = new Employee[0];

        public static List<Employee> employees;

        static Department()
        {
            employees = new List<Employee>();
        }

        private Department()
        {
        }

        public Department(string name, int employeeLimit)
        {
            Name = name;
            EmployeeLimit = employeeLimit;
        }

        public void AddEmployee(Employee employee)
        {
            //    if(employees.Length < EmployeeLimit)
            //    {
            //       Array.Resize(ref employees, employees.Length + 1);
            //        employees[^1] = employee;
            //   }
            if(employees.Count < EmployeeLimit)
            { 
                employees.Add(employee);
            }
            else
            {
                throw new CapacityLimitException("Can't add employee. Because employee limit is full.");
            }
        }
        public static void RemoveEmployee(Employee employee)
        {
            if(employees.Count > 0)
            {
                int index = employees.IndexOf(employee);
                employees.RemoveAt(index);
            }
            Console.WriteLine("-------------------------------------------\n" +
                             $"-------- Selected employee removed --------\n" +
                              "-------------------------------------------");
        }

        public static void RemoveEmployeeByConsole()
        {
            Console.WriteLine("-------------------------------------------\n" +
                             $"------ Select employee ID for remove ------\n" +
                              "-------------------------------------------");
            PrintAllEmployees();
            int id = Program.GetIntInputByConsole("id");
            Employee employeeForRemove = employees.Find(x => x.Id == id);
            RemoveEmployee(employeeForRemove);
        }

        public static void PrintAllEmployees()
        {
            if(employees.Count > 0)
            {
                Console.WriteLine("-------------------------------------------\n" +
                             $"------- All employees in department -------\n" +
                              "-------------------------------------------");
                foreach (Employee employee in employees)
                {
                    Console.WriteLine(employee.ToString());
                }
                Console.WriteLine("-------------------------------------------");
            }
            else
            {
                Console.WriteLine("-------------------------------------------\n" +
                                 $"--- There are no employees in department --\n" +
                                  "-------------------------------------------");
            }
        }
    }
}
