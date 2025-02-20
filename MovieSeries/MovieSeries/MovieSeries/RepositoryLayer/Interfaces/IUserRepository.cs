using MovieSeries.CoreLayer.Entities;

namespace MovieSeries.RepositoryLayer.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        User GetUserById(int id);
        void AddUser(User user);

    }
}
