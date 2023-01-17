using Microsoft.EntityFrameworkCore;
using uCondo.Galdino.Domain.Entity.Account;
using uCondo.Galdino.Domain.Repositories.IService.Account;
using uCondo.Galdino.Repository.Repository.Context;

namespace uCondo.Galdino.Repository.Repository.Account;

public class AccountRepository : BaseRepository<AccountEntity>, IAccountRepository
{
    private readonly uCondoContext context;

    public AccountRepository(uCondoContext context) : base(context)
    {
        this.context = context;
    }


    public async Task<List<AccountEntity>> Get() =>
        await GetAllAsync();

    public async Task<AccountEntity> Post(AccountEntity model)
    {
        await AddOrUpdateAsync(model);
        return model;
    }

    public async Task<List<AccountEntity>> GetByAccount(int id)
    {
        var all = await this.Get();
        return all.Where(x => x.AccountFather == id).ToList();
    }

    public async Task Put(AccountEntity model) =>  await AddOrUpdateAsync(model);
    public async Task Delete(int id) => await Remove(id);

}