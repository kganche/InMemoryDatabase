using Database.Models;

namespace Database.Handlers;

public class LoggingHandler : DatabaseHandler
{
    public override void AddUser(User user)
    {
        Console.WriteLine($"AddUser called with {user.FullName}");
        base.AddUser(user);
    }

    public override User? GetUserById(int id)
    {
        Console.WriteLine($"GetUserById called with id {id}");
        return base.GetUserById(id);
    }

    public override void AddIndex(string columnName)
    {
        Console.WriteLine($"AddIndex called with column {columnName}");
        base.AddIndex(columnName);
    }

    public override List<User> GetUsersByIndexedColumn(string columnName, object value)
    {
        Console.WriteLine($"GetUsersByIndexedColumn called with column {columnName} and value {value}");
        return base.GetUsersByIndexedColumn(columnName, value);
    }
}
