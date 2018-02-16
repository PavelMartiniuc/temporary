using Gitarist.Bll.Models;
using Gitarist.Domain;
using System.Collections.Generic;

namespace GitaristInterfaces
{
    public interface IArtistForeignBll
    {
        List<ArtistForeign> GelAll();

        List<ArtistForeign> GelPopular(int topCount = 0);


        ArtistForeign Get(long id);

        void SaveOrUpdate(ArtistForeign theme);

        void Delete(long id);

        ArtistForeign GetByIdOrClearUrlName(string id);

        List<ArtistForeignSongsCount> ArtistSongsCountByArtistStartLetter(string artistStartletter);

        IList<SongsByArtistForeignModel> GetPopular();

    }
}
