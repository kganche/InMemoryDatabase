using Database.Contracts;
using Database.Models;

namespace Database.Handlers;

public abstract class DatabaseHandler : IInMemoryDatabase
{
    protected IInMemoryDatabase _nextHandler;


    public void SetNext(IInMemoryDatabase nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public virtual void AddIndex(string columnName)
    {
        _nextHandler?.AddIndex(columnName);
    }

    public virtual void AddUser(User user)
    {
        _nextHandler?.AddUser(user);
    }

    public virtual User? GetUserById(int id)
    {
        return _nextHandler?.GetUserById(id);
    }

    public virtual List<User> GetUsersByIndexedColumn(string columnName, object value)
    {
        return _nextHandler?.GetUsersByIndexedColumn(columnName, value)!;
    }
}
