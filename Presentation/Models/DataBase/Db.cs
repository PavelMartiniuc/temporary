using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gitarist.Models.DataBase
{
    public static class Db
    {
        public static gitaristEntities Instanse()
        {
            return new gitaristEntities();
        }

    }
}