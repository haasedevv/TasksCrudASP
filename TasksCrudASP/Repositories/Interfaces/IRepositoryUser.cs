using TasksCrudASP.Models;

namespace TasksCrudASP.Repositories.Interfaces;

public interface IRepositoryUser
{
    Task<List<UserModel>> GetAllUsers();
    Task<UserModel> GetUserById(int id);
    Task<UserModel> AddUser(UserModel user);
    Task<UserModel> UpdateUser(UserModel user, int id);
    Task<bool> DeleteUser(int id);
}
