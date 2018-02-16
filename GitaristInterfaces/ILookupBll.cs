using System.Collections.Generic;
using Gitarist.Domain;

namespace GitaristInterfaces
{
    public interface ILookupBll<T> where T : BaseEntity
    {
        List<T> GelAll();

        T Get(long id);
    }
}
