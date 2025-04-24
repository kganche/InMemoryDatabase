using Database.Models;

namespace Database.Handlers;

public class ErrorReporterHandler : DatabaseHandler
{
    public override void AddUser(User user)
    {
        try
        {
            base.AddUser(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while executing AddUser: {ex.Message}");
        }
    }

    public override User? GetUserById(int id)
    {
        try
        {
            return base.GetUserById(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while executing GetUserById: {ex.Message}");
            return null;
        }
    }

    public override void AddIndex(string columnName)
    {
        try
        {
            base.AddIndex(columnName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while executing AddIndex: {ex.Message}");
        }
    }

    public override List<User> GetUsersByIndexedColumn(string columnName, object value)
    {
        try
        {
            return base.GetUsersByIndexedColumn(columnName, value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while executing GetUsersByIndexedColumn: {ex.Message}");
            return [];
        }
    }

}
