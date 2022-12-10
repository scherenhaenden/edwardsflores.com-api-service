namespace EdwardSFlores.DataAccess.Database.Core.BaseDomain
{
    public interface IBaseEntity
    {
        public Guid Guid { get; set; }
        DateTime InsertedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        void OnNew();

        void OnUpdate();
    }
}


/*
public class RoleClaim : ClaimBase
{
    public string RoleId { get; set; }
}

public class UserClaim : ClaimBase
{
    public string UserId { get; set; }
}

public class UserLogin : UserLoginKey
{
    public string ProviderDisplayName { get; set; }
    public string UserId { get; set; }
}

public class UserLoginKey
{
    public string LoginProvider;
    public string ProviderKey;
}

public class UserToken : UserTokenKey
{
    public string Value { get; set; }
}

public class UserTokenKey
{
    public string UserId { get; set; }
    public string LoginProvider { get; set; }
    public string Name { get; set; }
}

public class User
{
    public string Id { get; set; }
    public int AccessFailedCount { get; set; }
    public string ConcurrencyStamp { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool LockoutEnabled { get; set; }
    public DateTimeOffset? LockoutEnd { get; set; }
    public string NormalizedEmail { get; set; }
    public string NormalizedUserName { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public string SecurityStamp { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public string UserName { get; set; }
}*/