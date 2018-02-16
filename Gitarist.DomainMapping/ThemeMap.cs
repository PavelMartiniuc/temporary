using FluentNHibernate.Mapping;
using Gitarist.Domain;

namespace Gitarist.DomainMapping
{
    public class ThemeMap : ClassMap<Theme>
    {
        public ThemeMap()
        {
            Table("Themes");

            Id(x => x.Id).Column("id").GeneratedBy.Identity();

            Map(x => x.Deleted).Column("deleted").Not.Nullable();

            Map(x => x.Name).Column("name").Not.Nullable();

            Map(x => x.ClearUrlName).Column("clearUrlName").Nullable();

        }
    }
}
