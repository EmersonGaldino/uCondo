using uCondo.Galdino.Domain.Entity.Account;
using uCondo.Galdino.Domain.Interface.Account;
using uCondo.Galdino.Domain.Repositories.IService.Account;

namespace uCondo.Galdino.Domain.Service.Account;

public class AccountService : IAccountService
{
    private readonly IAccountRepository repository;
    public AccountService(IAccountRepository repository)
    {
        this.repository = repository;
    }

    public async Task<List<AccountEntity>> Get()
    {
        var data = await repository.Get();
        return data;
    }

    public async Task<AccountEntity> Post(AccountEntity model)
    {
        var item =  await GenerateCoding(model);
        var data = await repository.Post(item);
        return data;
    }

    public async Task Put(AccountEntity model) => await repository.Put(model);
    public async Task Delete(int id) => await repository.Delete(id);
    
    private async Task<AccountEntity> GenerateCoding(AccountEntity model)
    {
        var items = await repository.GetByAccount(model.AccountFather);
        var count = items.Count(x => x.AccountFather == model.AccountFather);
      
        if(count > 999)
            model.Cod = $"{model.AccountFather.ToString()}.{count + 1}";
        
        if (model is { Launch: true, Type: 1 })
            model.Cod = $"{model.AccountFather.ToString()}.{count + 1}";
        
        return model;
    }
}