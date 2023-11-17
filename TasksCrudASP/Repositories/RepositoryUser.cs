using Microsoft.EntityFrameworkCore;
using TasksCrudASP.Data;
using TasksCrudASP.Models;
using TasksCrudASP.Repositories.Interfaces;

namespace TasksCrudASP.Repositories;

public class RepositoryUser: IRepositoryUser
{
    private readonly TasksCrudDbContext _dbContext;
    public RepositoryUser(TasksCrudDbContext tasksCrudDbContext)
    {
        _dbContext = tasksCrudDbContext;
    }

    public async Task<List<UserModel>> GetAllUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<UserModel> GetUserById(int id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserModel> AddUser(UserModel user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

         return user;
    }

    public async Task<UserModel> UpdateUser(UserModel user, int id)
    {
        UserModel findedUserById = await GetUserById(id);

        if (findedUserById == null)
        {
            throw new Exception($"Usuário de ID: {id} não foi encontrado.");
        }

        findedUserById.Name = user.Name;
        findedUserById.Email = user.Email;

        _dbContext.Users.Update(findedUserById);
        await _dbContext.SaveChangesAsync();

        return findedUserById;
    }

    public async Task<bool> DeleteUser(int id)
    {
        UserModel findedUserById = await GetUserById(id);

        if (findedUserById == null)
        {
            throw new Exception($"Usuário de ID: {id} não foi encontrado.");
        }

        _dbContext.Remove(findedUserById);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
