using Database.Contracts;
using Database.Models;
using System.Diagnostics;

namespace Database.Decorators;

public class StatisticsDecorator(
    IInMemoryDatabase database, 
    Statistics statistics) : IInMemoryDatabase
{
    public void AddIndex(string columnName)
    {
        database.AddIndex(columnName);
    }

    public void AddUser(User user)
    {
        database.AddUser(user);
    }

    public User? GetUserById(int id)
    {
        return database.GetUserById(id);
    }

    public List<User> GetUsersByIndexedColumn(string columnName, object value)
    {

        var stopwatch = Stopwatch.StartNew();
        var result = database.GetUsersByIndexedColumn(columnName, value);

        stopwatch.Stop();
        statistics.AddDuration(nameof(GetUsersByIndexedColumn), stopwatch.Elapsed);

        return result;

    }
}
