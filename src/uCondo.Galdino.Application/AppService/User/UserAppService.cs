using uCondo.Galdino.Application.Interface.User;
using uCondo.Galdino.Domain.Entity.User;
using uCondo.Galdino.Domain.Interface.User;

namespace uCondo.Galdino.Application.AppService.User;

public class UserAppService: IUserAppService
{
    private IUserService Service;
   
    public UserAppService(IUserService service)
    {
        this.Service = service;
        
    }

    public async Task<UserEntity> GetUser(UserEntity model) => await Service.GetUser(model);


    
}