namespace RestaurantManagement.Models
{
    public interface IUserRepository
    {
        User GetUser(string username);
        IEnumerable<User> GetAllUser();

        User Add(User user);
        User Update(User userChanges);

        User Delete(string username);
    }
}
