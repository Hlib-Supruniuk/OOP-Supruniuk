public class Student
{
    public string Name { get; set; }
    public int Course { get; set; }

    public Student(string name, int course)
    {
        Name = name;
        Course = course;
    }
}