class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;
    private bool _isComplete;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0, bool isComplete = false)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            return _points + _bonus;
        }
        return _points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetails()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_targetCount}|{_bonus}|{_currentCount}|{_isComplete}";
    }
}