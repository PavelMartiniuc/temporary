using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Gitarist.Bll;
using GitaristInterfaces;
using Ninject;

namespace Gitarist.Ioc
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IThemeBll>().To<ThemeBll>();
            kernel.Bind<IArtistForeignBll>().To<ArtistForeignBll>();
            kernel.Bind<IArtistRussianBll>().To<ArtistRussianBll>();
            kernel.Bind<ISongForeignBll>().To<SongForeignBll>();
            kernel.Bind<ISongRussianBll>().To<SongRussianBll>();
            kernel.Bind<IDal>().To<Dal.Dal>();
            kernel.Bind(typeof(ILookupBll<>)).To(typeof(LookupBll<>));
        }
    }
}