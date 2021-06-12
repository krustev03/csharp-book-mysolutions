using System;

namespace _05.RealEstateSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Estate shop = new Shop(10.5, 99.99m, "Montana");
            Estate apartment = new Apartment(10.4, 90.04m, "Vratsa", 2, false, false);

            Employee employee1 = new Employee("Pesho", "Secutiry", "30 years");
            Employee employee2 = new Employee("Gosho", "Cleaner", "3 years");

            EstateCompany company = new EstateCompany("Sharks", "Petar Cardone", "123 456 789A");
            company.AddEmployee(employee1);
            company.AddEmployee(employee2);
            company.AddEstate(shop);
            company.AddEstate(apartment);
            Console.WriteLine(company);
        }
    }
}
