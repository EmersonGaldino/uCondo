using uCondo.Galdino.Domain.Entity.User;

namespace uCondo.Galdino.Application.Interface.User;

public interface IUserAppService
{
    Task<UserEntity> GetUser(UserEntity model);
}