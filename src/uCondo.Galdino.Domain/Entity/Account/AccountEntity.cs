using System.ComponentModel.DataAnnotations.Schema;
using uCondo.Galdino.Domain.Entity.Base;

namespace uCondo.Galdino.Domain.Entity.Account;

[Table("Account")]
public class AccountEntity : BaseEntity
{
    public string Cod { get; set; }
    public string Description { get; set; }
    public int AccountFather { get; set; }
    public bool Launch { get; set; }
    public int Type { get; set; }
    // public double Coding { get; set; }
}