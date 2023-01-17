using uCondo.Galdino.Domain.Entity.User;
using uCondo.Galdino.Domain.Interface.User;
using uCondo.Galdino.Domain.Repositories.IService.User;

namespace uCondo.Galdino.Domain.Service.User;

public class UserService : IUserService
{
    private readonly IUserRepository Repository;
    public UserService(IUserRepository repository)
    {
        this.Repository = repository;
    }

    public async Task<UserEntity> GetUser(UserEntity model) =>
            await Repository.GetUser(model);
      
        
   
}