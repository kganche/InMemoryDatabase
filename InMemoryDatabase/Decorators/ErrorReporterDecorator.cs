using Database.Contracts;
using Database.Models;

namespace Database.Decorators;

public class ErrorReporterDecorator(IInMemoryDatabase database) : IInMemoryDatabase
{
    public void AddUser(User user)
    {
        try
        {
            database.AddUser(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured while executing AddUser: {ex.Message}");
        }
    }

    public User? GetUserById(int id)
    {
        try
        {
            return database.GetUserById(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured while executing GetUserById: {ex.Message}");
            return null;
        }
    }

    public void AddIndex(string columnName)
    {
        try
        {
            database.AddIndex(columnName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured while executing AddIndex: {ex.Message}");
        }
    }

    public List<User> GetUsersByIndexedColumn(string columnName, object value)
    {
        try
        {
            return database.GetUsersByIndexedColumn(columnName, value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured while executing GetUsersByIndexedColumn: {ex.Message}");
            return [];
        }
    }
}