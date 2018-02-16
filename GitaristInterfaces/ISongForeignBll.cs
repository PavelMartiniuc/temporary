using System.Collections.Generic;
using Gitarist.Bll.Models;
using Gitarist.Domain;

namespace GitaristInterfaces
{
    public interface ISongForeignBll
    {
        List<SongForeign> GelAll(int topCount = 0);

        List<SongForeign> PopularBySong(int topCount = 0);

        SongForeign Get(long id);

        void AddSong(EditSongModel song);

        void SaveOrUpdate(SongForeign song);

        void Delete(long id);

        List<SongForeign> GelSongsByArtistAndTheme(string _artistId, string _themeId);

        void UpdateSong(EditSongModel song);

        List<SongForeign> Search(string criteria);

        SongForeign GetByArtistIdAndSongIdOrClearUrlName(long artistId, string song);

        SongForeign GetByIdOrClearUrlName(string id);

        List<SongForeign> GetNew();

        List<SongForeign> GetPopular();

        IList<SongsByThemesModel> SongsCountByThemes();

        IList<SongForeign> SongsByThemes(long themeId);

        List<SongForeign> ArtistLessRussianSongsByArtistStartLetter(string startLetter);

    }
}
