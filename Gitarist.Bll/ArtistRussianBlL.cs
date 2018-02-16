using System.Collections.Generic;
using System.Linq;
using Gitarist.Bll.Models;
using Gitarist.Domain;
using System;
using GitaristInterfaces;
using NHibernate.Transform;

namespace Gitarist.Bll
{
    public class ArtistRussianBll : IArtistRussianBll
    {
        private readonly IDal dal;

        public ArtistRussianBll(IDal dalObj)
        {
            dal = dalObj;
        }

        public List<ArtistRussian> GelAll()
        {
            var result = dal.Query<ArtistRussian>()
                .Where(x => !x.Deleted)
                .OrderBy(x => x.Name).ToList();

            return result;
        }

        public List<ArtistRussian> GelPopular(int topCount = 0)
        {
            var query = dal.Query<ArtistRussian>()
                .Where(x => x.IsPopular)
                .Where(x => !x.Deleted);

            if (topCount > 0)
                query = query.Take(topCount);

            var result = query
                .OrderBy(x => x.Name).ToList();

            return result;
        }

        public ArtistRussian Get(long id)
        {
            var artist = dal.Get<ArtistRussian>(id);
            if (artist.Deleted)
                return null;
            return artist;
        }

        public ArtistRussian GetByIdOrClearUrlName(string id)
        {
            ArtistRussian artist;

            long artistId = 0;

            if (Int64.TryParse(id, out artistId))
                artist = dal.Query<ArtistRussian>()
                    .FirstOrDefault(x=> !x.Deleted && x.Id == artistId);
            else
                artist = artist = dal.Query<ArtistRussian>()
                    .FirstOrDefault(x => !x.Deleted && x.ClearUrlName == id);

            return artist;
        }

        public void SaveOrUpdate(ArtistRussian theme)
        {
            dal.SaveOrUpdate(theme);
        }

        public void Delete(long id)
        {
            dal.Delete<ArtistRussian>(id);
        }

        public List<ArtistRussianSongsCount> ArtistSongsCountByArtistStartLetter(string artistStartletter)
        {
            var artists = dal.Query<ArtistRussian>()
                .Where(x => !x.Deleted)
                .Where(x => x.Name.ToLower().StartsWith(artistStartletter))
                .OrderBy(x => x.Name)
                .Select(x => new ArtistRussianSongsCount
                    {
                        Artist = x,
                        SongCount = x.SongRussians.Count
                    }
                ).ToList();

            return artists;
        }

        public IList<SongsByArtistRussianModel> GetPopular()
        {
            SongsByArtistRussianModel model = null;

            var songs = dal.GetSession()
                .QueryOver<SongRussian>()
                .Where(x => !x.Deleted && x.ArtistRussian != null)
                .SelectList(list => list
                    .SelectGroup(x => x.ArtistRussian).WithAlias(() => model.Artist)
                    .SelectCount(x => x.ArtistRussian).WithAlias(() => model.SongsCount)
                    )
                .TransformUsing(Transformers.AliasToBean<SongsByArtistRussianModel>())
                .List<SongsByArtistRussianModel>();

            return songs;
        }
    }
}
