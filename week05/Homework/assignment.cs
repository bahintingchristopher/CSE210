public class Assignment
{
    private string _studentName;
    private string _assignmentTitle;

    public Assignment(string studentName, string assignmentTitle)
    {
        _studentName = studentName;
        _assignmentTitle = assignmentTitle;
    }

    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetAssignmentTitle()
    {
        return _assignmentTitle;
    }

    public string GetSummary()
    {
        return _studentName + " - " + _assignmentTitle;
    }
}