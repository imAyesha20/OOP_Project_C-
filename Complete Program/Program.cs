using System;
using System.IO;

// Student calss
public class Student
{
    public int Id;
    public string Name;
    public string ClassName;

    public float Math;
    public float English;
    public float Computer;

    public float TotalMarks;
    public float Percentage;

    public string Grade;
    public string Result;

    public Student(int id, string name, string className,
        float math, float english, float computer)
    {
        Id = id;
        Name = name;
        ClassName = className;
        Math = math;
        English = english;
        Computer = computer;
    }
}

// Student Results class
public class StudentResults
{
    public static void Calculate(Student s)
    {
        s.TotalMarks = s.Math + s.English + s.Computer;
        s.Percentage = s.TotalMarks / 3;

        if (s.Percentage >= 80)
            s.Grade = "A";
        else if (s.Percentage >= 60)
            s.Grade = "B";
        else if (s.Percentage >= 50)
            s.Grade = "C";
        else
            s.Grade = "F";

        if (s.Math < 40 || s.English < 40 || s.Computer < 40)
            s.Result = "Fail";
        else
            s.Result = "Pass";
    }

    public static int GetTopper(Student[] students, int total)
    {
        if (total == 0)
            return -1;

        int topIndex = 0;

        for (int i = 1; i < total; i++)
        {
            if (students[i].Percentage > students[topIndex].Percentage)
                topIndex = i;
        }

        return topIndex;
    }
}

// File Handling class
public class FileHandling
{
    static string fileName = "students.txt";

    public static void SaveData(Student[] students, int total)
    {
        StreamWriter file = new StreamWriter(fileName);

        for (int i = 0; i < total; i++)
        {
            file.WriteLine(
                students[i].Id + "|" +
                students[i].Name + "|" +
                students[i].ClassName + "|" +
                students[i].Math + "|" +
                students[i].English + "|" +
                students[i].Computer + "|" +
                students[i].TotalMarks + "|" +
                students[i].Percentage + "|" +
                students[i].Grade + "|" +
                students[i].Result
            );
        }

        file.Close();
    }

    public static int LoadData(Student[] students)
    {
        int total = 0;

        if (File.Exists(fileName))
        {
            StreamReader file = new StreamReader(fileName);

            while (!file.EndOfStream && total < 100)
            {
                string line = file.ReadLine();
                string[] data = line.Split('|');

                Student s = new Student(
                    int.Parse(data[0]),
                    data[1],
                    data[2],
                    float.Parse(data[3]),
                    float.Parse(data[4]),
                    float.Parse(data[5])
                );

                StudentResults.Calculate(s);

                students[total] = s;
                total++;
            }

            file.Close();
        }

        return total;
    }
}

// Student Operations class
public class StudentOperations
{
    public static Student[] students = new Student[100];
    public static int total = 0;

    public static void AddStudent()
    {
        if (total >= 100)
        {
            Console.WriteLine("Student Limit Reached!");
            return;
        }

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

        Student s = new Student(id, name, className,
            math, english, computer);

        StudentResults.Calculate(s);

        students[total] = s;
        total++;

        FileHandling.SaveData(students, total);

        Console.WriteLine("Student Added Successfully!");
    }

    public static void ShowAllStudents()
    {
        if (total == 0)
        {
            Console.WriteLine("No Record Found!");
        }
        else
        {
            for (int i = 0; i < total; i++)
            {
                DisplayStudent(i);
            }
        }
    }

    public static void DisplayStudent(int i)
    {
        Console.WriteLine("ID: " + students[i].Id);
        Console.WriteLine("Name: " + students[i].Name);
        Console.WriteLine("Class: " + students[i].ClassName);

        Console.WriteLine("Math: " + students[i].Math);
        Console.WriteLine("English: " + students[i].English);
        Console.WriteLine("Computer: " + students[i].Computer);

        Console.WriteLine("Total: " + students[i].TotalMarks);
        Console.WriteLine("Percentage: " + students[i].Percentage);

        Console.WriteLine("Grade: " + students[i].Grade);
        Console.WriteLine("Result: " + students[i].Result);

        Console.WriteLine("---------------------------------");
    }

    public static void SearchStudent()
    {
        Console.Write("Enter ID: ");
        int searchId = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < total; i++)
        {
            if (students[i].Id == searchId)
            {
                Console.WriteLine("Found!");
                DisplayStudent(i);
                found = true;
                break;
            }
        }

        if (!found)
            Console.WriteLine("Not Found!");
    }

    public static void UpdateStudent()
    {
        Console.Write("Enter ID: ");
        int updateId = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < total; i++)
        {
            if (students[i].Id == updateId)
            {
                Console.Write("New Name: ");
                students[i].Name = Console.ReadLine();

                Console.Write("New Class: ");
                students[i].ClassName = Console.ReadLine();

                Console.Write("New Math: ");
                students[i].Math = float.Parse(Console.ReadLine());

                Console.Write("New English: ");
                students[i].English = float.Parse(Console.ReadLine());

                Console.Write("New Computer: ");
                students[i].Computer = float.Parse(Console.ReadLine());

                StudentResults.Calculate(students[i]);

                FileHandling.SaveData(students, total);

                Console.WriteLine("Updated!");

                found = true;
                break;
            }
        }

        if (!found)
            Console.WriteLine("Not Found!");
    }

    public static void DeleteStudent()
    {
        Console.Write("Enter ID: ");
        int deleteId = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < total; i++)
        {
            if (students[i].Id == deleteId)
            {
                for (int j = i; j < total - 1; j++)
                {
                    students[j] = students[j + 1];
                }

                total--;

                FileHandling.SaveData(students, total);

                Console.WriteLine("Deleted!");

                found = true;
                break;
            }
        }

        if (!found)
            Console.WriteLine("Not Found!");
    }

    public static void ShowTopper()
    {
        int topIndex = StudentResults.GetTopper(students, total);

        if (topIndex == -1)
        {
            Console.WriteLine("No Data!");
        }
        else
        {
            Console.WriteLine("Topper Name: " + students[topIndex].Name);
            Console.WriteLine("Percentage: " + students[topIndex].Percentage);
        }
    }

    public static void ShowFailedStudents()
    {
        bool found = false;

        for (int i = 0; i < total; i++)
        {
            if (students[i].Result == "Fail")
            {
                Console.WriteLine("Name: " + students[i].Name);
                Console.WriteLine("Percentage: " + students[i].Percentage);

                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Failed Students!");
    }

    public static void TotalStudentsCount()
    {
        Console.WriteLine("Total Students: " + total);
    }

    public static void ClearAllData()
    {
        total = 0;

        FileHandling.SaveData(students, total);

        Console.WriteLine("All Data Cleared!");
    }
}

// Main Program class
public class Program
{
    public static void Main(string[] args)
    {
        StudentOperations.total =
            FileHandling.LoadData(StudentOperations.students);

        int choice;

        while (true)
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
                    StudentOperations.AddStudent();
                    break;

                case 2:
                    StudentOperations.ShowAllStudents();
                    break;

                case 3:
                    StudentOperations.SearchStudent();
                    break;

                case 4:
                    StudentOperations.UpdateStudent();
                    break;

                case 5:
                    StudentOperations.DeleteStudent();
                    break;

                case 6:
                    StudentOperations.ShowTopper();
                    break;

                case 7:
                    StudentOperations.ShowFailedStudents();
                    break;

                case 8:
                    StudentOperations.TotalStudentsCount();
                    break;

                case 9:
                    StudentOperations.ClearAllData();
                    break;

                case 10:
                    Console.WriteLine("Program Ended!");
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }
}

