using System;
using System.Collections.Generic;
using System.Text;

namespace _05.RealEstateSystem
{
    public class EstateCompany
    {
        private string name;
        private string ownerName;
        private string commercialRegisterNumber;
        private List<Employee> employees;
        private List<Estate> estate;

        public EstateCompany(string name, string ownerName, string commercialRegisterNumber)
        {
            this.name = name;
            this.ownerName = ownerName;
            this.commercialRegisterNumber = commercialRegisterNumber;
            this.employees = new List<Employee>();
            this.estate = new List<Estate>();
        }

        public void AddEmployee(Employee employee)
        {
            this.employees.Add(employee);
        }

        public void AddEstate(Estate estate)
        {
            this.estate.Add(estate);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.name}");
            sb.AppendLine($"Owner Name: {this.ownerName}");
            sb.AppendLine($"CRN: {this.commercialRegisterNumber}");
            sb.AppendLine($"Employees:");

            foreach (var employee in this.employees)
            {
                sb.AppendLine(" " + employee);
            }

            sb.AppendLine($"Estate:");

            foreach (var estate in this.estate)
            {
                sb.AppendLine(" " + estate);
            }

            return sb.ToString();
        }
    }
}
