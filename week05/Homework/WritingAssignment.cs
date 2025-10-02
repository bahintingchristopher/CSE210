public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string assignmentTitle, string title)
        : base(studentName, assignmentTitle)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}