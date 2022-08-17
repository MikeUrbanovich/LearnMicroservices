public class UserRepository
{
    public List<User> TestUsers;

    public UserRepository()
    {
        TestUsers = new List<User>();
        TestUsers.Add(new User() { Username = "Test1@gmail.com", Password = "Pass1", Role = UserRole.Admin});
        TestUsers.Add(new User() { Username = "Test2@gmail.com", Password = "Pass2", Role = UserRole.User });
    }

    public User GetUser(string username)
    {
        try
        {
            return TestUsers.First(user => user.Username.Equals(username));
        }
        catch
        {
            return null;
        }
    }
}