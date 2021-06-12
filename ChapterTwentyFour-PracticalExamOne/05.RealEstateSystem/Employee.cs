using System.Text;

namespace _05.RealEstateSystem
{
    public class Employee
    {
        private string name;
        private string duty;
        private string internship;

        public Employee(string name, string duty, string internship)
        {
            this.name = name;
            this.duty = duty;
            this.internship = internship;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.name}");
            sb.AppendLine($" Duty: {this.duty}");
            sb.AppendLine($" Internship: {this.internship}");

            return sb.ToString();
        }
    }
}
