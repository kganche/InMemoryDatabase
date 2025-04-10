namespace Database.Models;

public class Statistics
{
    public Dictionary<string, TimeSpan> MethodDurations { get; } = [];

    public void AddDuration(string methodName, TimeSpan duration)
    {
        if (MethodDurations.ContainsKey(methodName))
        {
            MethodDurations[methodName] += duration;
        }
        else
        {
            MethodDurations[methodName] = duration;
        }
    }
}
