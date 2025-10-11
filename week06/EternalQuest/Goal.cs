using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;


    public Goal(string name, string description, int points)
    {
    _name = name;
    _description = description;
    _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    public abstract bool isComplete();
    public abstract int RecordEvent();
    public abstract string GetStringRepresentation();
    public abstract string GetDetailsString();   
}