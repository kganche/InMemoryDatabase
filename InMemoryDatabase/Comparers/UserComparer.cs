using Database.Models;

namespace Database.Comparers;

public class UserComparer : IComparer<User>
{
    public int Compare(User? x, User? y) => x.Id.CompareTo(y.Id);
}
