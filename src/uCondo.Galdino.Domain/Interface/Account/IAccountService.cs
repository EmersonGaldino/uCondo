using uCondo.Galdino.Domain.Entity.Account;

namespace uCondo.Galdino.Domain.Interface.Account;

public interface IAccountService
{
    Task<List<AccountEntity>> Get();
    Task<AccountEntity> Post(AccountEntity model);
    Task Put(AccountEntity model);
    Task Delete(int id);
    Task<AccountEntity> GetById(int id);
}