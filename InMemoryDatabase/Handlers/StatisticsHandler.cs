using Database.Models;
using System.Diagnostics;

namespace Database.Handlers;

public class StatisticsHandler(Statistics statistics) : DatabaseHandler
{
    public override List<User> GetUsersByIndexedColumn(string columnName, object value)
    {
        var stopwatch = Stopwatch.StartNew();
        var result = base.GetUsersByIndexedColumn(columnName, value);

        stopwatch.Stop();
        statistics.AddDuration(nameof(GetUsersByIndexedColumn), stopwatch.Elapsed);

        return result;
    }
}
