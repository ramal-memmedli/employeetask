using EmployeeTask.Models;
using System;

namespace EmployeeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
        TryAgainCreateDepartment:
            Console.WriteLine("-------------------------------------------\n" +
                             $"---------- Create new department ----------\n" +
                              "-------------------------------------------");
            string departmentName = Program.GetStringInputByConsole("name");
            if (String.IsNullOrEmpty(departmentName))
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                 $"-- Department name can't be empty or null -\n" +
                                  "-------------------------------------------");
                goto TryAgainCreateDepartment;
            }
            int employeeLimit = Program.GetIntInputByConsole("employee limit");
            if (employeeLimit <= 0 || employeeLimit > 1000000)
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------------\n" +
                                 $"Employee limit can't be under one and over one million\n" +
                                  "------------------------------------------------------");
                goto TryAgainCreateDepartment;
            }
            Department department = new Department(departmentName, employeeLimit);
            Console.WriteLine("-------------------------------------------\n" +
                             $"----- Department successfully created -----\n" +
                              "-------------------------------------------");

        Menu:
            Console.WriteLine("-------------------------------------------\n" +
                              "" +
                              "1 - Add Employee\n" +
                              "2 - Print all employees in department\n" +
                              "3 - Remove employee from department by ID\n" +
                              "" +
                              "-------------------------------------------");

            int input = GetIntInputByConsole("input");
            switch (input)
            {
                case 1:
                    Console.Clear();
                    department.AddEmployee(Employee.CreateEmployeeByConsole());
                    Console.WriteLine("-------------------------------------------\n" +
                                     $"Employee successfully added to department\n" +
                                      "-------------------------------------------");
                    goto Menu;
                case 2:
                    Console.Clear();
                    Department.PrintAllEmployees();
                    goto Menu;
                case 3:
                    Console.Clear();
                    Department.RemoveEmployeeByConsole();
                    goto Menu;
                default:
                    return;
            }
        }

        public static string GetStringInputByConsole(string content)
        {
        ReEnterStringInput:
            Console.Write($"Please enter {content} : ");
            string input = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                 $"--------- {content} can't be empty! --------\n" +
                                  "-------------------------------------------");
                goto ReEnterStringInput;
            }

            return input;
        }

        public static int GetIntInputByConsole(string content)
        {
        ReEnterIntInput:

            Console.Write($"Please enter {content} : ");
            string inputString = Console.ReadLine().Trim().ToLower();
            int? input;

            try
            {
                input = Convert.ToInt32(inputString);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------\n" +
                                  $"------- {content} must be digit! ------\n" +
                                  "-------------------------------------------");
                goto ReEnterIntInput;
            }

            return (int)input;
        }
    }
}
