using Database.Models;

namespace Database.Contracts;

public interface IInMemoryDatabase
{
    void AddUser(User user);

    User? GetUserById(int id);

    void AddIndex(string columnName);

    List<User> GetUsersByIndexedColumn(string columnName, object value);
}
