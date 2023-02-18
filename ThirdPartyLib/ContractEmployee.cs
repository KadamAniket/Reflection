using System;

namespace ThirdPartyLib
{
    public class ContractEmployee
    {
        public ContractEmployee(int period,int workingHours)
        {
            ContractPeriod = period;
            WorkingHoursPerDay = workingHours;
        }
        public int ContractPeriod { get; set; }

        public int WorkingHoursPerDay { get; set; }

        public int CalculateSalary()
        {
            Console.WriteLine("Calculating salary");

            return WorkingHoursPerDay * ContractPeriod;
        }
    }
}
