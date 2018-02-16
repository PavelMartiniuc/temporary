using System.Linq;
using Amdaris.Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Gitarist.DomainMapping;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using Gitarist.Domain;
using GitaristInterfaces;

namespace Gitarist.Dal
{
    public class Repository : IDal
    {
        private static ISession _session;

        public Repository()
        {
            _session = _session ?? OpenSession();
        }

        private static ISession OpenSession()
        {
            var connectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["gitaristNhibernate"].ConnectionString;
            ISessionFactory sessionFactory = Fluently.Configure()
               .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
               .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(ThemeMap).Assembly))
               .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, false))
               .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }

        public void SaveOrUpdate<T>(T entity) where T : IEntity
        {
            _session.Transaction.Begin();
            _session.SaveOrUpdate(entity);
            _session.Transaction.Commit();
        }

        public void Delete<T>(long id) where T : BaseEntity
        {

            _session.Transaction.Begin();
            var deletedEntity = Get<T>(id);

            if (deletedEntity != null)
                deletedEntity.Deleted = true;
            
            _session.SaveOrUpdate(deletedEntity);
            _session.Transaction.Commit();
        }

        public T Get<T>(long id) where T : IEntity
        {
            var entity = _session.Get<T>(id);
            return entity;
        }

        public  T GetEntityByNullableId<T>(long? id) where T : IEntity
        {
            if (!id.HasValue) return default(T);

            return Get<T>(id.Value);
        }

        public T LoadProxy<T>(long id) where T : IEntity
        {
            return _session.Load<T>(id);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _session.Query<T>();
        }

        public ISession GetSession()
        {
            return _session;
        }
        
    }
}
