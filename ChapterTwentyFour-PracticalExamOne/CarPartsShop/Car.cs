using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsShop
{
    public class Car
    {
        private string brand;
        private string model;
        private int productionYear;

        public Car(string brand, string model, int productionYear)
        {
            this.brand = brand;
            this.model = model;
            this.productionYear = productionYear;
        }

        public override string ToString()
        {
            return $"<{this.brand}, {this.model}, {this.productionYear}>";
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((this.brand == null) ? 0 : this.brand.GetHashCode());
            result = prime * result + ((this.brand == null) ? 0 : this.model.GetHashCode());
            result = prime * result + this.productionYear.GetHashCode();

            return result;
        }

        public override bool Equals(object obj)
        {
            Car otherCar = obj as Car;
            
            if (otherCar == null)
            {
                return false;
            }

            bool equals = object.Equals(this.brand, otherCar.brand) &&
                          object.Equals(this.model, otherCar.model) &&
                          object.Equals(this.productionYear, otherCar.productionYear);

            return equals;
        }
    }
}
