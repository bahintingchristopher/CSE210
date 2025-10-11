using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _completedCount;
    private int _bonusPoints;


    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) : base(name, description, points)
    {
        _targetCount = targetCount;
        _completedCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override bool isComplete()
    {
        return _completedCount >= _targetCount;
    }

    public override int RecordEvent()
    {
        if (_completedCount < _targetCount)
        {
            _completedCount++;
            if (_completedCount == _targetCount)
            {
                return _points + _bonusPoints;
            }
            else
            {
                return _points;
            }
        }
        return 0;
    }

    public override string GetStringRepresentation()
    {
        return
        $"ChecklistGoal,{_name},{_description},{_points},{_completedCount},{_targetCount},{_bonusPoints}";
    }

    public override string GetDetailsString()
    {
        string status = isComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Completed {_completedCount} of {_targetCount}";
    }
}
