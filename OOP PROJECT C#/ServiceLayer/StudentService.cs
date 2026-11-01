
using System.Collections.Generic;

public class StudentService
{
    public StudentRepository repository;

    public StudentService()
    {
        repository = new StudentRepository();
    }

    public void CalculateResult(Student s)
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

    public void AddStudent(int id, string name, string className,
                           float math, float english, float computer)
    {
        Student s = new Student(id, name, className,
            math, english, computer, 0, 0, "", "");

        CalculateResult(s);
        repository.AddStudent(s);
    }

    public List<Student> GetAllStudents()
    {
        return repository.GetAllStudents();
    }

    public Student SearchStudent(int id)
    {
        return repository.SearchStudent(id);
    }

    public bool UpdateStudent(int id, string name, string className,
                              float math, float english, float computer)
    {
        Student s = repository.SearchStudent(id);

        if (s == null)
            return false;

        s.Name = name;
        s.ClassName = className;
        s.Math = math;
        s.English = english;
        s.Computer = computer;

        CalculateResult(s);
        repository.SaveChanges();

        return true;
    }

    public bool DeleteStudent(int id)
    {
        Student s = repository.SearchStudent(id);

        if (s == null)
            return false;

        repository.DeleteStudent(id);
        return true;
    }

    public Student ShowTopper()
    {
        List<Student> students = repository.GetAllStudents();

        if (students.Count == 0)
            return null;

        Student topper = students[0];

        foreach (Student s in students)
        {
            if (s.Percentage > topper.Percentage)
            {
                topper = s;
            }
        }

        return topper;
    }

    public List<Student> ShowFailedStudents()
    {
        List<Student> failed = new List<Student>();

        foreach (Student s in repository.GetAllStudents())
        {
            if (s.Result == "Fail")
            {
                failed.Add(s);
            }
        }

        return failed;
    }

    public int TotalStudentsCount()
    {
        return repository.GetAllStudents().Count;
    }

    public void ClearAllData()
    {
        repository.ClearAllData();
    }
}
