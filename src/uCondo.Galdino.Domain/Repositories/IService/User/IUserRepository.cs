using uCondo.Galdino.Domain.Entity.User;
using uCondo.Galdino.Domain.Repositories.IRepository.Base;

namespace uCondo.Galdino.Domain.Repositories.IService.User;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<UserEntity> GetUser(UserEntity model);
}