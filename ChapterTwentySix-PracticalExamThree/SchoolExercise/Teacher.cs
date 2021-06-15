using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolExercise
{
    public class Teacher
    {
        public Teacher(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Groups = new List<Group>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Group> Groups { get; set; }

        public string Name => $"{this.FirstName} {this.LastName}";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Teacher name: {this.Name} ");
            sb.Append($"Groups of this teacher: {String.Join(", ", this.Groups.Select(g => g.Name))}");

            return sb.ToString();
        }
    }
}
