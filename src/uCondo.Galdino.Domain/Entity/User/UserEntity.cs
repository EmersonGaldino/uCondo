using uCondo.Galdino.Domain.Entity.Base;

namespace uCondo.Galdino.Domain.Entity.User;

public class UserEntity : BaseEntity
{
    public string Company { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public string AssingKey { get; set; }
}