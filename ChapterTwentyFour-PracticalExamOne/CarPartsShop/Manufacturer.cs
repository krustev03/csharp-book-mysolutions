using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsShop
{
    public class Manufacturer
    {
        private string name;
        private string country;
        private string adress;
        private string phoneNumber;
        private string fax;

        public Manufacturer(string name, string country, string adress, string phoneNumber, string fax)
        {
            this.name = name;
            this.country = country;
            this.adress = adress;
            this.phoneNumber = phoneNumber;
            this.fax = fax;
        }

        public override string ToString() => $"{this.name}<{this.country}, {this.adress}, {this.phoneNumber}, {this.fax}>";
    }
}
