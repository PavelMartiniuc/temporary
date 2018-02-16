using System.Collections.Generic;
using Gitarist.Bll.Models;
using Gitarist.Domain;

namespace GitaristInterfaces
{
    public interface IArtistRussianBll
    {
        List<ArtistRussian> GelAll();

        List<ArtistRussian> GelPopular(int topCount = 0);

        ArtistRussian Get(long id);

        ArtistRussian GetByIdOrClearUrlName(string id);

        void SaveOrUpdate(ArtistRussian theme);

        void Delete(long id);

        List<ArtistRussianSongsCount> ArtistSongsCountByArtistStartLetter(string artistStartletter);

        IList<SongsByArtistRussianModel> GetPopular();
    }
}