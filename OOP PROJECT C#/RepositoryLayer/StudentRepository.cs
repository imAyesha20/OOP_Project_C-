
using System.Collections.Generic;

public class StudentRepository
{
    public List<Student> students;
    public DataLayer dataLayer;

    public StudentRepository()
    {
        dataLayer = new DataLayer();
        students = dataLayer.LoadData();
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
        dataLayer.SaveData(students);
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }

    public Student SearchStudent(int id)
    {
        foreach (Student s in students)
        {
            if (s.Id == id)
            {
                return s;
            }
        }

        return null;
    }

    public void DeleteStudent(int id)
    {
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Id == id)
            {
                students.RemoveAt(i);
                dataLayer.SaveData(students);
                return;
            }
        }
    }

    public void SaveChanges()
    {
        dataLayer.SaveData(students);
    }

    public void ClearAllData()
    {
        students.Clear();
        dataLayer.SaveData(students);
    }
}
