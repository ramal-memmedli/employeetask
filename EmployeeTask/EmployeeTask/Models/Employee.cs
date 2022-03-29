using EmployeeTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTask.Models
{
    public class Employee : IPerson
    {
        private int _age;
        private int _salary;
        private static int _id;


        public int Id { get; private set; }
        public int Salary { get { return _salary; } set { if (value > 0 && value < 1000000000) _salary = value; } }
        public string Name { get; set; }
        public int Age { get { return _age; } set { if (value > 0 && value < 150) _age = value; } }

        static Employee()
        {
            _id = 0;
        }

        private Employee()
        {
            Id = ++_id;
        }

        public Employee(string name, int age, int salary) : this()
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public string ShowInfo()
        {
            return $"Id : {Id} | Name : {Name} | Age : {Age} | Salary : {Salary}";
        }

        public override string ToString()
        {
            return ShowInfo();
        }

        public static Employee CreateEmployeeByConsole()
        {
        TryAgainCreateEmployee:
            Console.WriteLine("-------------------------------------------\n" +
                             $"----------- Create new employee -----------\n" +
                              "-------------------------------------------");
            string employeeName = Program.GetStringInputByConsole("name");
            if (String.IsNullOrEmpty(employeeName))
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                 $"--- Employee name can't be empty or null --\n" +
                                  "-------------------------------------------");
                goto TryAgainCreateEmployee;
            }
            int employeeAge = Program.GetIntInputByConsole("age");
            if (employeeAge <= 0 || employeeAge > 150)
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------------\n" +
                                 $"-----Employee age can't be under one and over 150-----\n" +
                                  "------------------------------------------------------");
                goto TryAgainCreateEmployee;
            }
            int employeeSalary = Program.GetIntInputByConsole("salary");
            if (employeeSalary <= 0 || employeeSalary > 1000000000)
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------------\n" +
                                 $"--------- Employee salary can't be under one ---------\n" +
                                  "------------------------------------------------------");
                goto TryAgainCreateEmployee;
            }

            Console.WriteLine("-------------------------------------------\n" +
                             $"------ Employee successfully created ------\n" +
                              "-------------------------------------------");

            return new Employee(employeeName, employeeAge, employeeSalary);
        }
    }
}
