using Agentie_turism.domain;

namespace Agentie_turism.repository.userRepo;

public interface IUserRepository : IRepository<long, User>
{
    #nullable enable
    User? FindUserByUsername(string username);
}