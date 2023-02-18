using System;
using System.Linq;
using System.Reflection;
using Reflection.Models;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            
             // Get type information
             Employee aniket = new Employee(1, "Aniket", "Kadam");
            Console.WriteLine(aniket.GetFullName());

            Type t = aniket.GetType();

            Console.WriteLine(t.Name);
            Console.WriteLine(t.Namespace);
            Console.WriteLine(t.FullName);

            Console.WriteLine("--------------------");
            Type t2 = Type.GetType("Reflection.Models.Employee", false, true);
            Console.WriteLine(t2.Name);
            Console.WriteLine(t2.Namespace);
            Console.WriteLine(t2.FullName);

            Console.WriteLine("--------------------");
            Type t3 = typeof(Employee);
            Console.WriteLine(t3.Name);
            Console.WriteLine(t3.Namespace);
            Console.WriteLine(t3.FullName);
            Console.WriteLine(t3.IsAbstract);
            Console.WriteLine(t3.IsClass);
            Console.WriteLine(t3.IsPublic);


            // Access all the members
            //MemberInfo[] members = t3.GetMembers();
            //Console.WriteLine("\n All Members \n");
            //foreach(MemberInfo member in members)
            //{
            //    Console.WriteLine(member.Name);
            //}

            // Access all the methods
            Console.WriteLine("---------------Methods-------------");
            var methods = t3.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine("{0} {1}", method.Name, method.IsPublic);
            }

            // Show only current class methods
            Console.WriteLine("---------------Only current Class Methods-------------");
            var onlyClassmethods = t3.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in onlyClassmethods)
            {
                Console.WriteLine("{0} {1}", method.Name, method.IsPublic);
            }

            // Show interfaces
            Console.WriteLine("---------------Only current Class Methods-------------");
            var interfaces = t3.GetInterfaces();
            foreach (var inter in interfaces)
            {
                Console.WriteLine("{0}", inter.Name);
            }


            // Dynamically load assembly and explore its content
            // LateBinding
            var assembly = AppDomain.CurrentDomain.GetAssemblies().ToList();

            var thirdPartyAssembly = Assembly.Load("ThirdPartyLib");

            Console.WriteLine("Types");
            foreach(var clas in thirdPartyAssembly.GetTypes()){
                Console.WriteLine(clas.FullName);
                var sumit = Activator.CreateInstance(clas,10,10);
                

                var method = clas.GetMethod("CalculateSalary");
                var result = method.Invoke(sumit,null);

                Console.WriteLine("result:{0}",result); ;
                

            }


            Console.ReadLine();
        }
    }
}
