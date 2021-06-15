using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolExercise
{
    public class Group
    {
        public Group(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        }

        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Teacher Teacher { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Group name: {this.Name}");
            sb.AppendLine($"Students in the group: {String.Join(", ", this.Students.Select(s => s.Name))}");

            if (this.Teacher != null)
            {
                sb.Append($"Group teacher: {this.Teacher.Name}");
            }

            return sb.ToString();
        }
    }
}
