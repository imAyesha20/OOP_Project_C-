
using System;
using System.Collections.Generic;

public class StudentUI
{
    public StudentService service;

    public StudentUI()
    {
        service = new StudentService();
    }

    public void Menu()
    {
        int choice = 0;

        while (choice != 10)
        {
            Console.WriteLine("\n========== SCHOOL MANAGEMENT SYSTEM ==========");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Show All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Show Topper");
            Console.WriteLine("7. Show Failed Students");
            Console.WriteLine("8. Total Students Count");
            Console.WriteLine("9. Clear All Data");
            Console.WriteLine("10. Exit");

            Console.Write("Enter Choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;

                case 2:
                    ShowAllStudents();
                    break;

                case 3:
                    SearchStudent();
                    break;

                case 4:
                    UpdateStudent();
                    break;

                case 5:
                    DeleteStudent();
                    break;

                case 6:
                    ShowTopper();
                    break;

                case 7:
                    ShowFailedStudents();
                    break;

                case 8:
                    Console.WriteLine("Total Students: " +
                        service.TotalStudentsCount());
                    break;

                case 9:
                    service.ClearAllData();
                    Console.WriteLine("All Data Cleared!");
                    break;

                case 10:
                    Console.WriteLine("Program Ended!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    public void AddStudent()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Class: ");
        string className = Console.ReadLine();

        Console.Write("Math Marks: ");
        float math = float.Parse(Console.ReadLine());

        Console.Write("English Marks: ");
        float english = float.Parse(Console.ReadLine());

        Console.Write("Computer Marks: ");
        float computer = float.Parse(Console.ReadLine());

        service.AddStudent(id, name, className,
            math, english, computer);

        Console.WriteLine("Student Added Successfully!");
    }

    public void ShowAllStudents()
    {
        List<Student> students = service.GetAllStudents();

        if (students.Count == 0)
        {
            Console.WriteLine("No Record Found!");
        }
        else
        {
            foreach (Student s in students)
            {
                DisplayStudent(s);
            }
        }
    }

    public void SearchStudent()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Student s = service.SearchStudent(id);

        if (s != null)
        {
            Console.WriteLine("Found!");
            DisplayStudent(s);
        }
        else
        {
            Console.WriteLine("Not Found!");
        }
    }

    public void UpdateStudent()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New Name: ");
        string name = Console.ReadLine();

        Console.Write("New Class: ");
        string className = Console.ReadLine();

        Console.Write("New Math: ");
        float math = float.Parse(Console.ReadLine());

        Console.Write("New English: ");
        float english = float.Parse(Console.ReadLine());

        Console.Write("New Computer: ");
        float computer = float.Parse(Console.ReadLine());

        bool updated = service.UpdateStudent(id, name,
            className, math, english, computer);

        if (updated)
            Console.WriteLine("Updated!");
        else
            Console.WriteLine("Not Found!");
    }

    public void DeleteStudent()
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        bool deleted = service.DeleteStudent(id);

        if (deleted)
            Console.WriteLine("Deleted!");
        else
            Console.WriteLine("Not Found!");
    }

    public void ShowTopper()
    {
        Student s = service.ShowTopper();

        if (s == null)
        {
            Console.WriteLine("No Data!");
        }
        else
        {
            Console.WriteLine("Topper Name: " + s.Name);
            Console.WriteLine("Percentage: " + s.Percentage);
        }
    }

    public void ShowFailedStudents()
    {
        List<Student> failed = service.ShowFailedStudents();

        if (failed.Count == 0)
        {
            Console.WriteLine("No Failed Students!");
        }
        else
        {
            foreach (Student s in failed)
            {
                Console.WriteLine("Name: " + s.Name);
                Console.WriteLine("Percentage: " + s.Percentage);
            }
        }
    }

    public void DisplayStudent(Student s)
    {
        Console.WriteLine("ID: " + s.Id);
        Console.WriteLine("Name: " + s.Name);
        Console.WriteLine("Class: " + s.ClassName);

        Console.WriteLine("Math: " + s.Math);
        Console.WriteLine("English: " + s.English);
        Console.WriteLine("Computer: " + s.Computer);

        Console.WriteLine("Total: " + s.TotalMarks);
        Console.WriteLine("Percentage: " + s.Percentage);

        Console.WriteLine("Grade: " + s.Grade);
        Console.WriteLine("Result: " + s.Result);

        Console.WriteLine("---------------------------------");
    }
}
