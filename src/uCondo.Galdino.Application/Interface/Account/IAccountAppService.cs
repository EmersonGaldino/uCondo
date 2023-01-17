using uCondo.Galdino.Domain.Entity.Account;

namespace uCondo.Galdino.Application.Interface.Account;

public interface IAccountAppService
{
    Task<List<AccountEntity>> Get();
    Task<AccountEntity> Post(AccountEntity model);
    Task Put(AccountEntity model);
    Task Delete(int id);
}
