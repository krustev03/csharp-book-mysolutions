using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolExercise
{
    public class School
    {
        public School(string name)
        {
            this.Name = name;
            this.Teachers = new List<Teacher>();
            this.Groups = new List<Group>();
            this.Students = new List<Student>();
        }

        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Group> Groups { get; set; }
        public List<Student> Students { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"School name: {this.Name}");
            sb.AppendLine($"Teachers: {String.Join(", ", this.Teachers.Select(t => t.Name))}");
            sb.AppendLine($"Students: {String.Join(", ", this.Students.Select(s => s.Name))}");
            sb.AppendLine($"Groups: {String.Join(", ", this.Groups.Select(g => g.Name))}");

            foreach (var teacher in this.Teachers)
            {
                sb.Append("\n---\n");
                sb.Append(teacher);
            }

            foreach (var group in this.Groups)
            {
                sb.Append("\n---\n");
                sb.Append(group);
            }

            foreach (var student in this.Students)
            {
                sb.Append("\n---\n");
                sb.Append(student);
            }

            return sb.ToString();
        }
    }
}
