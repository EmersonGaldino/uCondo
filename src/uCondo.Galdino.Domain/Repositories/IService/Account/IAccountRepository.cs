using uCondo.Galdino.Domain.Entity.Account;

namespace uCondo.Galdino.Domain.Repositories.IService.Account;

public interface IAccountRepository
{
    Task<List<AccountEntity>> Get();
    Task<AccountEntity> Post(AccountEntity item);
    Task<List<AccountEntity>> GetByAccount(int id);
    Task Put(AccountEntity model);
}