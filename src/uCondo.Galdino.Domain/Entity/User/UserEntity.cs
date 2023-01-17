using uCondo.Galdino.Domain.Entity.Base;

namespace uCondo.Galdino.Domain.Entity.User;

public class UserEntity : BaseEntity
{
    public string Password { get; set; }
    public string Email { get; set; }

}