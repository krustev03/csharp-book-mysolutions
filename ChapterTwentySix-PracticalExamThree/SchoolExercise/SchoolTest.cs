using System;

namespace SchoolExercise
{
    class SchoolTest
    {
        static void Main(string[] args)
        {
            var studentPeter = new Student("Peter", "Lee");
            var studentGeorge = new Student("George", "Redwood");
            var studentMaria = new Student("Maria", "Steward");
            var studentMichael = new Student("Michael", "Robinson");

            var groupEnglish = new Group("English Language course");
            groupEnglish.Students.Add(studentPeter);
            groupEnglish.Students.Add(studentGeorge);
            groupEnglish.Students.Add(studentMaria);
            groupEnglish.Students.Add(studentMichael);

            var groupJava = new Group("Java Programming course");
            groupJava.Students.Add(studentMaria);
            groupJava.Students.Add(studentPeter);

            var teacherNatasha = new Teacher("Natasha", "Walters");
            teacherNatasha.Groups.Add(groupEnglish);
            teacherNatasha.Groups.Add(groupJava);
            groupEnglish.Teacher = teacherNatasha;
            groupJava.Teacher = teacherNatasha;

            var teacherSteve = new Teacher("Steve", "Porter");
            var groupHTML = new Group("HTML course");
            groupHTML.Students.Add(studentMaria);
            groupHTML.Students.Add(studentMichael);
            groupHTML.Teacher = teacherSteve;
            teacherSteve.Groups.Add(groupHTML);

            var school = new School("Saint George High School");
            school.Students.Add(studentPeter);
            school.Students.Add(studentGeorge);
            school.Students.Add(studentMaria);
            school.Students.Add(studentMichael);

            school.Groups.Add(groupEnglish);
            school.Groups.Add(groupJava);
            school.Groups.Add(groupHTML);

            school.Teachers.Add(teacherSteve);
            school.Teachers.Add(teacherNatasha);

            groupEnglish.Name = "Advanced English";
            groupEnglish.Students.RemoveAt(0);
            studentPeter.LastName = "White";
            teacherNatasha.LastName = "Hudson";

            Console.WriteLine(school);
        }
    }
}
