using System.Reflection;
using AutoMapper;
using System;
using System.Linq;
using Gitarist.Areas.Admin.AutoMapperProfiles;

namespace Gitarist.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(x => GetProfiles(Mapper.Configuration));
            Mapper.AssertConfigurationIsValid();
        }

        private static void GetProfiles(IConfiguration configuration)
        {
            var profiles = Assembly.GetAssembly(typeof(ThemeProfile)).GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Profile)));

            foreach (var profile in profiles)
            {
                var profileInstance = (Profile)Activator.CreateInstance(profile);
                configuration.AddProfile(profileInstance);
            }
        }
    }
}