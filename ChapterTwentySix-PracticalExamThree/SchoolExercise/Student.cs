namespace SchoolExercise
{
    public class Student
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Name => $"{this.FirstName} {this.LastName}";

        public override string ToString() => $"Student: {this.Name}";
    }
}
