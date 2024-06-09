using System.Collections.Generic;
using model;

namespace persistence
{
    public interface IRepository<TId, TE> where TE : Entity<TId>
    {
        IEnumerable<TE> FindAll();
        
        #nullable enable
        TE? Save(TE entity);
        TE? Update(TE entity);
    }
}