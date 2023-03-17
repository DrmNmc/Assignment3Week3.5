using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqMethodSyntax
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public double Tuition { get; set; }
    }

    public class StudentClubs
    {
        public int StudentID { get; set; }
        public string ClubName { get; set; }
    }

    public class StudentGPA
    {
        public int StudentID { get; set; }
        public double GPA { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
                new Student() { StudentID = 1, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
                new Student() { StudentID = 2, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
                new Student() { StudentID = 3, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
                new Student() { StudentID = 3, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
                new Student() { StudentID = 4, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
                new Student() { StudentID = 5, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
            };

            // Student GPA Collection
            IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
                new StudentGPA() { StudentID = 1,  GPA=4.0} ,
                new StudentGPA() { StudentID = 2,  GPA=3.5} ,
                new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
                new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
                new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
                new StudentGPA() { StudentID = 6,  GPA=2.5} ,
                new StudentGPA() { StudentID = 7,  GPA=1.0 }
            };
            // Club collection
                IList<StudentClubs> studentClubList = new List<StudentClubs>() {
                new StudentClubs() {StudentID=1, ClubName="Photography" },
                new StudentClubs() {StudentID=1, ClubName="Game" },
                new StudentClubs() {StudentID=2, ClubName="Game" },
                new StudentClubs() {StudentID=5, ClubName="Photography" },
                new StudentClubs() {StudentID=6, ClubName="Game" },
                new StudentClubs() {StudentID=7, ClubName="Photography" },
                new StudentClubs() {StudentID=3, ClubName="PTK" },
            };

            //group by GPA. display ID.
            var queryA = studentGPAList.GroupBy(s => s.GPA);
            Console.WriteLine("Students grouped by GPA:");
            foreach (var group in queryA)
            {
                Console.WriteLine($"GPA: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($"StudentID: {student.StudentID}");
                }
            }
            Console.WriteLine();

            //sort club. group club. display id.
            var queryB = studentClubList.OrderBy(s => s.ClubName).GroupBy(s => s.ClubName);
            Console.WriteLine("Students sorted by club and grouped by club:");
            foreach (var group in queryB)
            {
                Console.WriteLine($"Club: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($"StudentID: {student.StudentID}");
                }
            }
            Console.WriteLine();

            //num of students between 2.5-4.0 GPA
            var queryC = studentGPAList.Count(s => s.GPA >= 2.5 && s.GPA <= 4.0);
            Console.WriteLine($"Number of students with a GPA between 2.5 and 4.0: {queryC}");
            Console.WriteLine();

            //Average student tuition
            var queryD = studentList.Average(s => s.Tuition);
            Console.WriteLine($"Average tuition: {queryD}");
            Console.WriteLine();

            //student paying the most tuition. display name, major and tuition, shame them thoroughly!
            var maxTuition = studentList.Max(s => s.Tuition);
            var queryE = studentList.Where(s => s.Tuition == maxTuition);
            Console.WriteLine("Student(s) paying the most tuition:");
            foreach (var student in queryE)
            {
                Console.WriteLine($"Name: {student.StudentName}, Major: {student.Major}, Tuition: {student.Tuition}");
            }
            Console.WriteLine();

            //join student list and GPA list on student ID and display the student's name, major, gpa
            var queryF = studentList.Join(studentGPAList, s => s.StudentID, gpa => gpa.StudentID, (s, gpa) => new { s.StudentName, s.Major, gpa.GPA });
            Console.WriteLine("Students' names, majors, and GPAs:");
            foreach (var student in queryF)
            {
                Console.WriteLine($"Name: {student.StudentName}, Major: {student.Major}, GPA: {student.GPA}");
            }
            Console.WriteLine();

            //join student list and club list. Display the names game club students.
            var queryG = studentList.Join(studentClubList, s => s.StudentID, club => club.StudentID, (s, club) => new { s.StudentName, club.ClubName })
                                    .Where(sc => sc.ClubName == "Game");
            Console.WriteLine("Nerds in the Game club:");
            foreach (var student in queryG)
            {
                Console.WriteLine($"Name: {student.StudentName}");
            }
            Console.WriteLine();
        }
    }
}

