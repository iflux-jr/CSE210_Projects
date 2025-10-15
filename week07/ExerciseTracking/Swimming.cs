public class Swimming : Activity
{
    private int _laps;
    private const double LapLength = 50 / 1000.0 * 0.62; // 50m = 0.031 miles

    public Swimming(string date, int length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapLength;
    public override double GetSpeed() => (GetDistance() / GetLength()) * 60;
    public override double GetPace() => GetLength() / GetDistance();
}