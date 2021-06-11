using CarPartsShop.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsShop
{
    public class Part
    {
        private string name;
        private string code;
        private PartCategory category;
        private HashSet<Car> supportedCars;
        private double buyPrice;
        private double sellPrice;
        private Manufacturer manufacturer;

        public Part(string name, double buyPrice, double sellPrice, Manufacturer manufacturer, string code, PartCategory category)
        {
            this.name = name;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.manufacturer = manufacturer;
            this.code = code;
            this.category = category;
            this.supportedCars = new HashSet<Car>();
        }

        public void AddSupportedCar(Car car) => this.supportedCars.Add(car);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Part: {this.name} \n");
            sb.Append($"-code: {this.code} \n");
            sb.Append($"-category: {this.category} \n");
            sb.Append($"-buyPrice: {this.buyPrice} \n");
            sb.Append($"-sellPrice: {this.sellPrice} \n");
            sb.Append($"-manufacturer: {this.manufacturer} \n");
            sb.Append($"---Supported cars--- \n");

            foreach (var car in this.supportedCars)
            {
                sb.Append($"{car} \n");
            }

            sb.Append("----------------------\n");
            return sb.ToString();
        }
    }
}
