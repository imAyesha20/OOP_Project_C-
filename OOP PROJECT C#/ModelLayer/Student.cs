
using System;

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
                   float math, float english, float computer,
                   float totalMarks, float percentage,
                   string grade, string result)
    {
        Id = id;
        Name = name;
        ClassName = className;
        Math = math;
        English = english;
        Computer = computer;
        TotalMarks = totalMarks;
        Percentage = percentage;
        Grade = grade;
        Result = result;
    }
}
