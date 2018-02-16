using System;
using System.Collections.Generic;
using System.Linq;
using Gitarist.Bll.Models;
using Gitarist.Domain;
using GitaristInterfaces;
using NHibernate.Transform;

namespace Gitarist.Bll
{
    public class SongForeignBll : ISongForeignBll
    {
        private IDal dal;

        public SongForeignBll(IDal dalObj)
        {
            dal = dalObj;
        }

        public List<SongForeign> GelAll(int topCount = 0)
        {
            var query = dal.Query<SongForeign>();

            query = query.Where(x => !x.Deleted)
                .OrderByDescending(x => x.DateCreate)
                .ThenBy(x => x.Name);

            if (topCount > 0)
                query = query.Take(20);

            var result = query.ToList();

            return result;
        }

        public List<SongForeign> PopularBySong(int topCount = 0)
        {
            var query = dal.Query<SongForeign>();

            query = query.Where(x => !x.Deleted)
                .Where(x => x.IsPopular)
                .OrderByDescending(x => x.DateCreate)
                .ThenBy(x => x.Name);
            
            if (topCount > 0)
                query = query.Take(20);

            var result = query.ToList();

            return result;
        }


        public SongForeign Get(long id)
        {
            return dal.Get<SongForeign>(id);
        }

        public void AddSong(EditSongModel song)
        {
            var newSong = new SongForeign();
            newSong.Name = song.name;
            newSong.ArtistForeign = dal.GetEntityByNullableId<ArtistForeign>(song.artistId);
            newSong.Theme = dal.GetEntityByNullableId<Theme>(song.themeId);
            newSong.Chords = song.chords;
            newSong.ClearUrlName = song.clearUrlName;
            if (song.id == 0)
                newSong.DateCreate = DateTime.Now;

            dal.SaveOrUpdate(newSong);
        }

        public void SaveOrUpdate(SongForeign song)
        {
            if (song.Id == 0)
                song.DateCreate = DateTime.Now;
            dal.SaveOrUpdate(song);
        }

        public void Delete(long id)
        {
            dal.Delete<SongForeign>(id);
        }

        public List<SongForeign> GelSongsByArtistAndTheme(string _artistId, string _themeId)
        {
            var query = dal.Query<SongForeign>()
                .Where(x => !x.Deleted);

            if (!string.IsNullOrEmpty(_artistId))
            {
                switch (_artistId)
                {
                    case "0":
                        query = query.Where(x => x.ArtistForeign == null);
                        break;
                    case "-1": break;
                    default:
                        query = query.Where(x => x.ArtistForeign.Id == System.Convert.ToInt64(_artistId));
                        break;
                }
            }

            if (!string.IsNullOrEmpty(_themeId))
            {
                switch (_themeId)
                {
                    case "0":
                        query = query.Where(x => x.Theme == null);
                        break;
                    case "-1": break;
                    default:
                        query = query.Where(x => x.Theme.Id == System.Convert.ToInt64(_themeId));
                        break;
                }
            }

            return query.ToList();
        }

        public void UpdateSong(EditSongModel song)
        {
            var editedSong = Get(song.id);

            if (editedSong == null) return;

            editedSong.Name = song.name;
            editedSong.ArtistForeign = (song.artistId.HasValue && song.artistId != 0 && song.artistId != -1) ? dal.Get<ArtistForeign>(song.artistId.Value) : null;
            editedSong.Theme = ( song.themeId.HasValue && song.themeId != 0 && song.themeId != -1) ? dal.Get<Theme>(song.themeId.Value) : null;
            editedSong.IsNew = song.isNew;
            editedSong.IsPopular = song.isPopular;
            editedSong.Chords = song.chords;
            editedSong.ClearUrlName = song.clearUrlName;

            dal.SaveOrUpdate(editedSong);
        }

        public List<SongForeign> Search(string criteria)
        {
            var searchQuery = dal.Query<SongForeign>();
            if (!string.IsNullOrEmpty(criteria))
                searchQuery =
                    searchQuery.Where(
                        song =>
                            song.ArtistForeign.Name.Contains(criteria) || song.Name.Contains(criteria) ||
                            song.Chords.Contains(criteria));

            var searchResults = searchQuery.ToList();

            return searchResults;
        }


        public SongForeign GetByArtistIdAndSongIdOrClearUrlName(long artistId, string song)
        {
            var searchedSong = GetByIdOrClearUrlName(song);

            var resultSong = dal.Query<SongForeign>()
                    .FirstOrDefault(x => !x.Deleted && x.ArtistForeign.Id == artistId && x.Id == searchedSong.Id);
            return resultSong;
        }

        public SongForeign GetByIdOrClearUrlName(string id)
        {
            SongForeign song;

            long songId = 0;

            if (Int64.TryParse(id, out songId))
                song = dal.Query<SongForeign>()
                    .FirstOrDefault(x => !x.Deleted && x.Id == songId);
            else
                song = dal.Query<SongForeign>()
                    .FirstOrDefault(x => !x.Deleted && x.ClearUrlName == id);

            return song;
        }

        public List<SongForeign> GetNew()
        {
            return dal.Query<SongForeign>()
                .Where(x => !x.Deleted && x.IsNew)
                .OrderByDescending(x => x.DateCreate)
                .ToList();
        }

        public List<SongForeign> GetPopular()
        {
            return dal.Query<SongForeign>()
                .Where(x => !x.Deleted && x.IsPopular)
                .OrderByDescending(x => x.DateCreate)
                .ToList();
        }

        public IList<SongsByThemesModel> SongsCountByThemes()
        {
            SongsByThemesModel model = null;

            var songs = dal.GetSession()
                .QueryOver<SongForeign>()
                .Where(x => !x.Deleted && x.Theme != null)
                .SelectList(list => list
                    .SelectGroup(x => x.Theme).WithAlias(() => model.Theme)
                    .SelectCount(x => x.Theme).WithAlias(() => model.SongsCount)
                    )
                .TransformUsing(Transformers.AliasToBean<SongsByThemesModel>())
                .List<SongsByThemesModel>();

            return songs;
        }

        public IList<SongForeign> SongsByThemes(long themeId)
        {
            var songs = dal.Query<SongForeign>()
                    .Where(x => x.Theme.Id == themeId)
                    .ToList();
            return songs;
        }

        public List<SongForeign> ArtistLessRussianSongsByArtistStartLetter(string startLetter)
        {
            var songs = dal.Query<SongForeign>()
                .Where(x => !x.Deleted)
                .Where(x => x.Name.ToLower().StartsWith(startLetter))
                .Where(x => x.ArtistForeign == null)
                .ToList();
            return songs;
        }

    }
}
