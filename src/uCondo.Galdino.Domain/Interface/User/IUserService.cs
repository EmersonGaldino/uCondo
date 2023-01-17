using uCondo.Galdino.Domain.Entity.User;

namespace uCondo.Galdino.Domain.Interface.User;

public interface IUserService
{
    Task<UserEntity> GetUser(UserEntity model);
}