
using System.Linq;
using Amdaris.Domain;
using Gitarist.Domain;
using NHibernate;

namespace GitaristInterfaces
{
    public interface IDal
    {
        void SaveOrUpdate<T>(T entity) where T : IEntity;

        void Delete<T>(long id) where T : BaseEntity;

        T Get<T>(long id) where T : IEntity;

        T GetEntityByNullableId<T>(long? id) where T : IEntity;

        T LoadProxy<T>(long id) where T : IEntity;

        IQueryable<T> Query<T>() where T : Entity;

        ISession GetSession();

    }
}
