using System.Collections.Generic;
using Gitarist.Bll.Models;
using Gitarist.Domain;

namespace GitaristInterfaces
{
    public interface ISongRussianBll
    {
        List<SongRussian> GelAll(int topCount = 0);

        List<SongRussian> PopularBySong(int topCount = 0);

        SongRussian Get(long id);

        SongRussian GetByArtistIdAndSongIdOrClearUrlName(long artistId, string song);

        SongRussian GetByIdOrClearUrlName(string id);

        List<SongRussian> GetNew();

        List<SongRussian> GetPopular();

        IList<SongsByThemesModel> SongsCountByThemes();

        IList<SongRussian> SongsByThemes(long themeId);

        void SaveOrUpdate(SongRussian song);

        void AddSong(EditSongModel song);

        void Delete(long id);

        List<SongRussian> GelSongsByArtistAndTheme(string _artistId, string _themeId);

        void UpdateSong(EditSongModel song);

        List<SongRussian> Search(string criteria);

        List<SongRussian> ArtistLessRussianSongsByArtistStartLetter(string startLetter);
    }
}
