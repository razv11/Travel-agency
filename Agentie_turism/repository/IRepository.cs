using System.Collections.Generic;
using Agentie_turism.domain;

namespace Agentie_turism.repository
{
    public interface IRepository<TId, TE> where TE : Entity<TId>
    {
        #nullable enable
        IEnumerable<TE> FindAll();
        
        TE? Save(TE entity);

        TE? Update(TE entity);
    }
}