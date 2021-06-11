using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsShop
{
    public class Shop
    {
        private string name;
        private List<Part> parts;

        public Shop(string name)
        {
            this.name = name;
            this.parts = new List<Part>();
        }

        public void AddPart(Part part) => this.parts.Add(part);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Shop: {this.name}\n\n");

            foreach (Part part in this.parts)
            {
                sb.Append($"{part}\n");
            }

            return sb.ToString();
        }
    }
}
