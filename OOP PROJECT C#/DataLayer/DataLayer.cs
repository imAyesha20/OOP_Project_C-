
using System;
using System.Collections.Generic;
using System.IO;

public class DataLayer
{
    string fileName = "students.txt";

    public void SaveData(List<Student> students)
    {
        StreamWriter file = new StreamWriter(fileName);

        foreach (Student s in students)
        {
            file.WriteLine(s.Id + "|" + s.Name + "|" +
                s.ClassName + "|" + s.Math + "|" +
                s.English + "|" + s.Computer + "|" +
                s.TotalMarks + "|" + s.Percentage + "|" +
                s.Grade + "|" + s.Result);
        }

        file.Close();
    }

    public List<Student> LoadData()
    {
        List<Student> students = new List<Student>();

        if (File.Exists(fileName))
        {
            StreamReader file = new StreamReader(fileName);

            while (!file.EndOfStream)
            {
                string line = file.ReadLine();

                string[] data = line.Split('|');

                Student s = new Student(
                    int.Parse(data[0]),
                    data[1],
                    data[2],
                    float.Parse(data[3]),
                    float.Parse(data[4]),
                    float.Parse(data[5]),
                    float.Parse(data[6]),
                    float.Parse(data[7]),
                    data[8],
                    data[9]
                );

                students.Add(s);
            }

            file.Close();
        }

        return students;
    }
}
