namespace InMemoryDatabase;

public class InMemoryDatabase
{
    private SortedList<User, User> _users = new(new UserComparer());
    private Dictionary<string, Dictionary<object, List<int>>> _indexes = [];

    public void AddUser(User user)
    {
        _users.Add(user, user);
        RebuildIndexes();
    }
    public User? GetUserById(int id)
    {
        int index = BinarySearchById(id);
        return index >= 0 ? _users.Values[index] : null;
    }

    public void AddIndex(string columnName)
    {
        if (!_indexes.ContainsKey(columnName))
        {
            _indexes[columnName] = [];
            foreach (var user in _users.Values)
            {
                AddToIndex(columnName, user);
            }
        }
    }

    public List<User> GetUsersByIndexedColumn(string columnName, object valueObect)
    {
        if (_indexes.TryGetValue(columnName, out Dictionary<object, List<int>>? value)
            && value.TryGetValue(valueObect, out List<int>? userIds))
        {
            var result = new List<User>();

            foreach (var id in userIds)
            {
                var user = GetUserById(id);

                if (user != null)
                {
                    result.Add(user);
                }
            }

            return result;
        }

        return [];
    }

    private int BinarySearchById(int id)
    {
        int left = 0;
        int right = _users.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (_users.Values[mid].Id == id)
            {
                return mid;
            }

            if (_users.Values[mid].Id < id)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    private void AddToIndex(string columnName, User user)
    {
        var columnValue = GetColumnValue(user, columnName);

        if (!_indexes[columnName].TryGetValue(columnValue, out List<int>? value))
        {
            value = [];
            _indexes[columnName][value] = value;
        }

        value.Add(user.Id);
    }

    private object GetColumnValue(User user, string columnName) => columnName switch
    {
        "FullName" => user.FullName,
        "Address" => user.Address,
        "Salary" => user.Salary,
        _ => throw new ArgumentException("Invalid column name"),
    };

    private void RebuildIndexes()
    {
        foreach (var columnName in _indexes.Keys)
        {
            _indexes[columnName].Clear();

            foreach (var user in _users.Values)
            {
                AddToIndex(columnName, user);
            }
        }
    }
}
