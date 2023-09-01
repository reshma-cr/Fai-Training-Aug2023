using DotnetTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScores
{
    class Student
    {
        public string Name { get; set; }
        public Dictionary<string, int> SubjectScores {get; set;}

        public Student(string name)
        {
            Name = name;
            SubjectScores = new Dictionary<string, int>();
        }

        public void AddSubjectScores(string subject, int score )
        {
            SubjectScores[subject] = score;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                Console.WriteLine("Student Scores");
                Console.WriteLine("1. Insert Student");
                Console.WriteLine("2. Delete Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Display Student Scores");
                Console.WriteLine("5. Exit");
                int choice = Utilities.GetInteger("Enter your choice");

                switch (choice)
                {
                    case 1:
                        Student student = InsertStudentData();
                        students.Add(student);
                        Console.WriteLine("students added");
                        break;
                    case 2:
                        Console.WriteLine("enter the name of the student to delete: ");
                        string studentToDelete = Console.ReadLine();
                        DeleteStudent(students, studentToDelete);
                        break;
                    case 3:
                        Console.WriteLine("enter the name of the student to update scores: ");
                        string studentToUpdate = Console.ReadLine();
                        UpdateStudent(students, studentToUpdate);
                        break;
                    case 4:
                        DisplayStudentScores(students);
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static Student InsertStudentData()
        {
            Console.WriteLine("enter the name of student");
            string studentName = Console.ReadLine();
            Student student = new Student(studentName);
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine("enter the name of subject");
                string subject = Console.ReadLine();

                Console.WriteLine($"enter the score for {subject}: ");
                int score = int.Parse(Console.ReadLine());

                student.AddSubjectScores(subject, score);
            }
            return student;

        }
        static void DisplayStudentScores(List<Student> students)
        {
            foreach (var student in students)
            {
                int total = 0;
                Console.WriteLine($"{student.Name} score:");
                foreach (var kvp in student.SubjectScores)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    total += kvp.Value;
                }
                Console.WriteLine("Total marks scored: " + total);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static void DeleteStudent(List<Student> students, string studentName)
        {
            Student studentToDelete = students.Find(s => s.Name == studentName);
            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
                Console.WriteLine($"{studentName} has been deleted");
            } else
            {
                Console.WriteLine($"{studentName} not found.");
            }
        }

        static void UpdateStudent(List<Student> students, string studentName)
        {
            Student studentToUpdate = students.Find(s => s.Name == studentName);
            if (studentToUpdate != null)
            {
                Console.WriteLine($"update scores for: {studentName}");
                foreach (var subject in studentToUpdate.SubjectScores.Keys)
                {
                    Console.WriteLine($"enter score for {subject}");
                    int newScore = int.Parse(Console.ReadLine());
                    studentToUpdate.SubjectScores[subject] = newScore;
                }
                Console.WriteLine("Scores updated.");
            }
        }
    }   

}

