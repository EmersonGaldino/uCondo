using uCondo.Galdino.Domain.Entity.Account;
using UCondo.Galdino.Models.Base;

namespace UCondo.Galdino.Models.ModelView.Account;

public class AccountModelView : IModelView<AccountEntity>
{
   

    public string Cod { get; set; }
    public string Description { get; set; }

    public int AccountFather { get; set; }
    public bool Launch { get; set; }
    public int Type { get; set; }
    public double Coding { get; set; }
}