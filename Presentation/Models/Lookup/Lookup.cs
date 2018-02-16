using System.Collections.Generic;
using System.Linq;
using Gitarist.Areas.Admin.Models.Lookup;
using Gitarist.Bll;
using Gitarist.Domain;
using GitaristInterfaces;

namespace Gitarist.Models.Lookup
{
    public class Lookup<T> where T: BaseEntity
    {
        private readonly ILookupBll<T> _lookupBll;

        private readonly bool _selectAllSongsIsEnabled;
        private readonly bool _showUnlinkedSongsIsEnabled;

        public Lookup(bool selectAllSongsIsEnabled, bool showUnlinkedSongsIsEnabled)
        {
            _selectAllSongsIsEnabled = selectAllSongsIsEnabled;
            _showUnlinkedSongsIsEnabled = showUnlinkedSongsIsEnabled;
            _lookupBll = new LookupBll<T>();
        }

        public List<LookupItem> GetItems()
        {
            var entityItems = _lookupBll.GelAll();

            
            var result = (from dbItem in entityItems select new LookupItem {Id = dbItem.Id, Name = dbItem.Name}).ToList();

            if (_showUnlinkedSongsIsEnabled)
                result.Insert(0, new LookupItem { Id = 0, Name = "---Не выбран---" });

            if (_selectAllSongsIsEnabled)
                result.Insert(0, new LookupItem { Id = -1, Name = "---Все---" });

            return result;
        }
    }
}