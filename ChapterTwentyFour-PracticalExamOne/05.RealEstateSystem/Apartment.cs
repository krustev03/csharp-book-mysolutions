using System.Text;

namespace _05.RealEstateSystem
{
    public class Apartment : Estate
    {
        private int floorNumber;
        private bool hasElevator;
        private bool isFurnished;

        public Apartment(double space, decimal price, string location, int floorNumber, bool hasElevator, bool isFurnished)
            : base(space, price, location)
        {
            this.floorNumber = floorNumber;
            this.hasElevator = hasElevator;
            this.isFurnished = isFurnished;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine($" Floor number: {this.floorNumber}");
            sb.AppendLine($" Has elevator: {this.hasElevator}");
            sb.AppendLine($" Is furnished: {this.isFurnished}");

            return sb.ToString();
        }
    }
}
