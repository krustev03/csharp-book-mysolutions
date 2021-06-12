using System.Text;

namespace _05.RealEstateSystem
{
    public class House : Estate
    {
        private int builtPartSquareMeters;
        private int yardSquareMeters;
        private int floors;
        private bool isFurnished;

        public House(double space, decimal price, string location, int builtPartSquareMeters, int yardSquareMeters, int floors, bool isFurnished) : base(space, price, location)
        {
            this.builtPartSquareMeters = builtPartSquareMeters;
            this.yardSquareMeters = yardSquareMeters;
            this.floors = floors;
            this.isFurnished = isFurnished;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Built part: {this.builtPartSquareMeters} square meters");
            sb.AppendLine($"Yard: {this.yardSquareMeters} square meters");
            sb.AppendLine($"Number of floors: {this.floors}");
            sb.AppendLine($"Is furnished: {this.isFurnished}");

            return sb.ToString();
        }
    }
}
