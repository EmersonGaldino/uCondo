using uCondo.Galdino.Application.Interface.Account;
using uCondo.Galdino.Domain.Entity.Account;
using uCondo.Galdino.Domain.Interface.Account;

namespace uCondo.Galdino.Application.AppService.Account;

public class AccountAppService : IAccountAppService
{
    private readonly IAccountService service;
    public AccountAppService(IAccountService service)
    {
        this.service = service;
    }

    public async Task<List<AccountEntity>> Get() => await service.Get();
    public async Task<AccountEntity> Post(AccountEntity model) => await service.Post(model);
    public async Task Put(AccountEntity model) => await service.Put(model);
    public async Task Delete(int id) => await service.Delete(id);

}