using Database.Contracts;
using Database.Models;

namespace Database.Decorators;

public class LoggingDecorator(IInMemoryDatabase database) : IInMemoryDatabase
{
    public void AddIndex(string columnName)
    {

        Console.WriteLine($"AddIndex called with column {columnName}");
        database.AddIndex(columnName);
    }

    public void AddUser(User user)
    {

        Console.WriteLine($"AddUser called with {user.FullName}");
        database.AddUser(user);
    }

    public User? GetUserById(int id)
    {
        Console.WriteLine($"GetUserById called with id {id}");
        return database.GetUserById(id);
    }

    public List<User> GetUsersByIndexedColumn(string columnName, object value)
    {

        Console.WriteLine($"GetUsersByIndexedColumn called with column {columnName} and value {value}");
        return database.GetUsersByIndexedColumn(columnName, value);
    }
}
