using System;
using System.Collections.Generic;
using System.Linq;
using Gitarist.Bll.Models;
using Gitarist.Domain;
using GitaristInterfaces;
using NHibernate.Transform;

namespace Gitarist.Bll
{
    public class SongRussianBll : ISongRussianBll
    {
        private IDal dal;

        public SongRussianBll(IDal dalObj)
        {
            dal = dalObj;
        }

        public List<SongRussian> GelAll(int topCount = 0)
        {
            var query = dal.Query<SongRussian>();
                
            query = query.Where(x => !x.Deleted)
                .OrderByDescending(x => x.DateCreate)
                .ThenBy(x => x.Name);
            
            if (topCount > 0)
                 query = query.Take(20);
            
            var result = query.ToList();

            return result;
        }

        public List<SongRussian> PopularBySong(int topCount = 0)
        {
            var query = dal.Query<SongRussian>();

            query = query.Where(x => !x.Deleted)
                .Where(x => x.IsPopular)
                .OrderByDescending(x => x.DateCreate)
                .ThenBy(x => x.Name);

            if (topCount > 0)
                query = query.Take(20);

            var result = query.ToList();

            return result;
        }

        public SongRussian Get(long id)
        {
            var song = dal.Get<SongRussian>(id);
            if (song.Deleted) return null;
            return song;
        }

        public SongRussian GetByArtistIdAndSongIdOrClearUrlName(long artistId, string song)
        {
            var searchedSong = GetByIdOrClearUrlName(song);

            var resultSong = dal.Query<SongRussian>()
                    .FirstOrDefault(x => !x.Deleted && x.ArtistRussian.Id == artistId && x.Id == searchedSong.Id);
            return resultSong;
        }

        public SongRussian GetByIdOrClearUrlName(string id)
        {
            SongRussian song;

            long songId = 0;

            if (Int64.TryParse(id, out songId))
                song = dal.Query<SongRussian>()
                    .FirstOrDefault(x => !x.Deleted && x.Id == songId);
            else
                song = dal.Query<SongRussian>()
                    .FirstOrDefault(x => !x.Deleted && x.ClearUrlName == id);

            return song;
        }

        public List<SongRussian> GetNew()
        {
            return dal.Query<SongRussian>()
                .Where(x => !x.Deleted && x.IsNew)
                .OrderByDescending(x => x.DateCreate)
                .ToList();
        }

        public List<SongRussian> GetPopular()
        {
            return dal.Query<SongRussian>()
                .Where(x => !x.Deleted && x.IsPopular)
                .OrderByDescending(x => x.DateCreate)
                .ToList();
        }

        public IList<SongsByThemesModel> SongsCountByThemes()
        {
            SongsByThemesModel model = null;

            var songs = dal.GetSession()
                .QueryOver<SongRussian>()
                .Where(x=> !x.Deleted && x.Theme!=null)
                .SelectList(list => list
                    .SelectGroup(x => x.Theme).WithAlias(() => model.Theme)
                    .SelectCount(x => x.Theme).WithAlias(() => model.SongsCount)
                    )
                .TransformUsing(Transformers.AliasToBean<SongsByThemesModel>())
                .List<SongsByThemesModel>();
                
            return songs;
        }

        public IList<SongRussian> SongsByThemes(long themeId)
        {
            var songs = dal.Query<SongRussian>()
                    .Where(x => x.Theme.Id == themeId)
                    .ToList();
            return songs;
        }

        public void SaveOrUpdate(SongRussian song)
        {
            if (song.Id == 0)
                song.DateCreate = DateTime.Now;
            dal.SaveOrUpdate(song);
        }

        public void AddSong(EditSongModel song)
        {
            var newSong = new SongRussian();
            newSong.Name = song.name;
            newSong.ArtistRussian = dal.GetEntityByNullableId<ArtistRussian>(song.artistId);
            newSong.Theme = dal.GetEntityByNullableId<Theme>(song.themeId);
            newSong.Chords = song.chords;
            newSong.ClearUrlName = song.clearUrlName;
            if (song.id == 0)
                newSong.DateCreate = DateTime.Now;

            dal.SaveOrUpdate(newSong);
        }

        public void Delete(long id)
        {
            dal.Delete<SongRussian>(id);
        }

        public List<SongRussian> GelSongsByArtistAndTheme(string _artistId, string _themeId)
        {
            var query = dal.Query<SongRussian>()
                .Where(x => !x.Deleted);

            if (!string.IsNullOrEmpty(_artistId))
            {
                switch (_artistId)
                {
                    case "0":
                        query = query.Where(x => x.ArtistRussian == null);
                        break;
                    case "-1": break;
                    default:
                        query = query.Where(x => x.ArtistRussian.Id == System.Convert.ToInt64(_artistId));
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
            editedSong.ArtistRussian = (song.artistId.HasValue && song.artistId != 0 && song.artistId != -1) ? dal.Get<ArtistRussian>(song.artistId.Value) : null;
            editedSong.Theme = (song.themeId.HasValue && song.themeId != 0 && song.themeId != -1) ? dal.Get<Theme>(song.themeId.Value) : null;
            editedSong.IsNew = song.isNew;
            editedSong.IsPopular = song.isPopular;
            editedSong.Chords = song.chords;
            editedSong.ClearUrlName = song.clearUrlName;

            dal.SaveOrUpdate(editedSong);
        }

        public List<SongRussian> Search(string criteria)
        {
            var searchQuery = dal.Query<SongRussian>();
            if (!string.IsNullOrEmpty(criteria))
                searchQuery =
                    searchQuery.Where(
                        song =>
                            song.ArtistRussian.Name.Contains(criteria) || song.Name.Contains(criteria) ||
                            song.Chords.Contains(criteria));

            var searchResults = searchQuery.ToList();

            return searchResults;
        }

        public List<SongRussian> ArtistLessRussianSongsByArtistStartLetter(string startLetter)
        {
            var songs = dal.Query<SongRussian>()
                .Where(x => !x.Deleted)
                .Where(x => x.Name.ToLower().StartsWith(startLetter))
                .Where(x => x.ArtistRussian == null)
                .ToList();
            return songs;
        }
    }
}
