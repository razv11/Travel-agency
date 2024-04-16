using model;

namespace persistence.userRepo;

public interface IUserRepository : IRepository<long, User>
{
    #nullable enable
    User? FindUserByUsername(string username);
}