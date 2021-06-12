using System;
using System.Collections.Generic;
using System.Text;

namespace _05.RealEstateSystem
{
    public abstract class Estate
    {
        private double space;
        private decimal price;
        private string location;

        public Estate(double space, decimal price, string location)
        {
            this.space = space;
            this.price = price;
            this.location = location;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($" Space: {this.space} square meters");
            sb.AppendLine($" Price for square meter: {this.price} leva");
            sb.AppendLine($" Location: {this.location}");

            return sb.ToString();
        }
    }
}
