// Assignment.cs
public class Assignment
{
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Getter so derived classes can use the student's name
    public string GetStudentName()
    {
        return _studentName;
    }

    // Method
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}
