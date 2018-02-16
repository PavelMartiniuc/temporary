using FluentNHibernate.Mapping;
using Gitarist.Domain;

namespace Gitarist.DomainMapping
{
    public class SongRussianMap : ClassMap<SongRussian>
    {
        public SongRussianMap()
        {
            Table("SongRusians");
            
            Id(x => x.Id).Column("id").GeneratedBy.Identity();

            Map(x => x.Deleted).Column("deleted").Not.Nullable();

            Map(x => x.Name).Column("name").Not.Nullable();

            Map(x => x.Chords).Column("chords").Not.Nullable();

            Map(x => x.ClearUrlName).Column("clearUrlName").Nullable();

            Map(x => x.IsNew).Column("isNew").Not.Nullable();
            
            Map(x => x.IsPopular).Column("isPopular").Not.Nullable();

            Map(x => x.DateCreate).Column("datecreate").Not.Nullable();

            References(x => x.ArtistRussian)
                .Column("ArtistId")
                .ForeignKey("FK_SongRusian_ArtistRusian")
                .Nullable();

            References(x => x.Theme)
              .Column("ThemeId")
              .ForeignKey("FK_SongRusian_Theme")
              .Nullable();

        }
    }
}
