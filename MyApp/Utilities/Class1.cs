namespace Utilities;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int DoubleTheAge()
    {
        return Age * 2;
    }
}

public class TryStudent
{
    public void DisplayStudentInfo(Student student)
    {
        Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
        Console.WriteLine($"Double The Age: {student.DoubleTheAge()}");
    }
}