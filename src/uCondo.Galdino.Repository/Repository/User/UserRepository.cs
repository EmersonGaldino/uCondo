
using Microsoft.EntityFrameworkCore;
using uCondo.Galdino.Domain.Entity.User;
using uCondo.Galdino.Domain.Repositories.IService.User;
using uCondo.Galdino.Repository.Repository.Context;

namespace uCondo.Galdino.Repository.Repository.User;

public class UserRepository : BaseRepository<UserEntity>, IUserRepository
{
    private readonly uCondoContext context;
    public UserRepository(uCondoContext context) : base(context)
    {
        this.context = context;
    }
    public async Task<UserEntity> GetUser(UserEntity model)
    {
        var data = await context.User.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
        return data;
    }
}