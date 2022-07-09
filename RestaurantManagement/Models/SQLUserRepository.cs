namespace RestaurantManagement.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private AppDbContext context;

        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        
        public User Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public User Delete(string username)
        {
           User user =  context.Users.Find(username);
            if(user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAllUser()
        {
            return context.Users;
        }

        public User GetUser(string username)
        {
            return context.Users.Find(username);
        }

        public User Update(User userChanges)
        {
            var user = context.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return userChanges;
        }
    }
}
