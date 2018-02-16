using FluentNHibernate.Mapping;
using Gitarist.Domain;

namespace Gitarist.DomainMapping
{
    public class ArtistRussianMap : ClassMap<ArtistRussian>
    {
        public ArtistRussianMap()
        {
            Table("ArtistRusians");

            Id(x => x.Id).Column("id").GeneratedBy.Identity();

            Map(x => x.Deleted).Column("deleted").Not.Nullable();

            Map(x => x.Name).Column("name").Not.Nullable();

            Map(x => x.ClearUrlName).Column("clearUrlName").Nullable();

            Map(x => x.IsPopular).Column("isPopular").Not.Nullable();

            HasMany(x => x.SongRussians).Inverse().KeyColumn("ArtistId");
        }
    }
}
