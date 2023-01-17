using System.ComponentModel.DataAnnotations;
using uCondo.Galdino.Domain.Entity.Account;
using UCondo.Galdino.Models.Base;

namespace UCondo.Galdino.Models.ViewModel.Account;

public class AccountViewModel : IViewModel<AccountEntity>
{
    [Required]
    public string Description { get; set; }

    public int AccountFather { get; set; } = 0;
    [Required]
    public bool Launch { get; set; }
    [Required]
    public int Type { get; set; }
    [Required]
    public string Cod { get; set; }
    
    public double Coding { get; set; }
    public int Id { get; set; }
}