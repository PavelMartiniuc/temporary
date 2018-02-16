using System;
using System.Collections.Generic;
using System.Linq;
using Gitarist.Domain;
using GitaristInterfaces;

namespace Gitarist.Bll
{

    public class ThemeBll : IThemeBll
    {
        private IDal dal;

        public ThemeBll(IDal dalObj)
        {
            dal = dalObj;
        }

        public List<Theme> GelAll()
        {
            return dal.Query<Theme>()
                .Where(x => !x.Deleted)
                .OrderBy(x => x.Name).ToList();
        }

        public Theme Get(long id)
        {
            return dal.Get<Theme>(id);
        }

        public Theme GetByIdOrClearUrlName(string id)
        {
            Theme theme;

            long themeId = 0;

            if (Int64.TryParse(id, out themeId))
                theme = dal.Query<Theme>()
                    .FirstOrDefault(x => !x.Deleted && x.Id == themeId);
            else
                theme = dal.Query<Theme>()
                    .FirstOrDefault(x => !x.Deleted && x.ClearUrlName == id);

            return theme;
        }


        public void SaveOrUpdate(Theme theme)
        {
            dal.SaveOrUpdate(theme);
        }

        public void Delete(long id)
        {
            dal.Delete<Theme>(id);
        }

    }

}
