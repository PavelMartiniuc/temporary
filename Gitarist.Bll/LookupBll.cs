using System.Collections.Generic;
using System.Linq;
using Gitarist.Domain;
using GitaristInterfaces;

namespace Gitarist.Bll
{
    public class LookupBll<T> : ILookupBll<T> where T : BaseEntity
    {

        private readonly IDal dal;

        public LookupBll()
        {
            dal = new Dal.Dal();
        }

        public List<T> GelAll()
        {
            return dal.Query<T>()
                .Where(x => !x.Deleted)
                .OrderBy(x => x.Name).ToList();
        }

        public T Get(long id)
        {
            return dal.Get<T>(id);
        }

        /*
        public void SaveOrUpdate(Theme theme)
        {
            dal.SaveOrUpdate(theme);
        }

        public void Delete(long id)
        {
            dal.Delete<Theme>(id);
        }
        */
    }
}
