namespace MethodsDemo
{
    public class Student
    {
        public static int NumberOfStudents = 0;
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            NumberOfStudents++;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Student Count: {NumberOfStudents}");
        }
    }
}

namespace ExtensionMethodsDemo
{
    using MethodsDemo;
    public static class StudentExtensions
    {
        public static void DoubleTheAge(this Student student)
        {
            student.Age *= 2;
        }

        // Optional: parameterized version
        public static void MultiplyAge(this Student student, int factor)
        {
            student.Age *= factor;
        }
    }
}
