public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string assignmentTitle, string textbookSection, string problems)
        : base(studentName, assignmentTitle)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return "Section " + _textbookSection + " Problems " + _problems;
    }

   }