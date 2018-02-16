
using Gitarist.Domain;
using System.Collections.Generic;

namespace GitaristInterfaces
{
    public interface IThemeBll
    {
        List<Theme> GelAll();

        Theme Get(long id);

        Theme GetByIdOrClearUrlName(string id);

        void SaveOrUpdate(Theme theme);

        void Delete(long id);

    }
}
