using CarPartsShop.Enums;
using System;

namespace CarPartsShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Manufacturer bmw = new Manufacturer("BMW", "Germany", "Bavaria", "665544", "876666");
            Manufacturer lada = new Manufacturer("Lada", "Russia", "Moscow", "653443", "893321");

            Car bmw316i = new Car("BMW", "316i", 1994);
            Car ladaSamara = new Car("Lada", "Samara", 1987);
            Car mazdaMX5 = new Car("Mazda", "MX5", 1999);
            Car mercedesC500 = new Car("Mercedes", "C500", 2008);
            Car trabant = new Car("Trabant", "super", 1966);
            Car opelAstra = new Car("Opel", "Astra", 1997);

            Part cheapPart = new Part("Tires 165/50/13", 302.36, 345.58, lada, "T332", PartCategory.Tires);
            cheapPart.AddSupportedCar(ladaSamara);
            cheapPart.AddSupportedCar(trabant);

            Part expensivePart = new Part("BMW Engine Oil", 633.17, 670.0, bmw, "Oil431", PartCategory.Engine);
            expensivePart.AddSupportedCar(bmw316i);
            expensivePart.AddSupportedCar(mazdaMX5);
            expensivePart.AddSupportedCar(mercedesC500);
            expensivePart.AddSupportedCar(opelAstra);

            Shop newShop = new Shop("Tunning shop");
            newShop.AddPart(cheapPart);
            newShop.AddPart(expensivePart);

            Console.WriteLine(newShop);
        }
    }
}
