using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reflection.Models
{
    interface IEmployee
    {
        public void Work();
    }

    class Employee: IEmployee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public Employee(int id,string firstName,string lastName)
        {
            Id = Id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetFullName()
        {
            return AppendString(FirstName,LastName);
        }

        public void Work()
        {
            Console.WriteLine("Doing work");
        }


        private string AppendString(string firstName,string lastName)
        {
            return firstName +" " +lastName;
        }

        public static Employee DuplicateEmployee(Employee employee)
        {
            var duplicate = new Employee(employee.Id, employee.FirstName, employee.LastName);
            return duplicate;
        }
        
    }
}
