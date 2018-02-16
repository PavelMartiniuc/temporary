using System.Collections.Generic;
using System.Linq;
using Gitarist.Bll.Models;
using Gitarist.Domain;
using System;
using GitaristInterfaces;
using NHibernate.Transform;

namespace Gitarist.Bll
{
    public class ArtistForeignBll : IArtistForeignBll
    {
        private readonly IDal dal;

        public ArtistForeignBll(IDal dalObj)
        {
            dal = dalObj;
        }

        public List<ArtistForeign> GelAll()
        {
            var result = dal.Query<ArtistForeign>()
                .Where(x => !x.Deleted)
                .OrderBy(x => x.Name).ToList();

            return result;
        }

        public List<ArtistForeign> GelPopular(int topCount = 0)
        {
            var query = dal.Query<ArtistForeign>()
                .Where(x => x.IsPopular)
                .Where(x => !x.Deleted);
                
            if (topCount > 0)
                query = query.Take(topCount);
            
            var result = query
                .OrderBy(x => x.Name).ToList();

            return result;
        }

        public ArtistForeign Get(long id)
        {
            return dal.Get<ArtistForeign>(id);
        }

        public void SaveOrUpdate(ArtistForeign theme)
        {
            dal.SaveOrUpdate(theme);
        }

        public void Delete(long id)
        {
            dal.Delete<ArtistForeign>(id);
        }

        public ArtistForeign GetByIdOrClearUrlName(string id)
        {
            ArtistForeign artist;

            long artistId = 0;

            if (Int64.TryParse(id, out artistId))
                artist = dal.Query<ArtistForeign>()
                    .FirstOrDefault(x => !x.Deleted && x.Id == artistId);
            else
                artist = dal.Query<ArtistForeign>()
                    .FirstOrDefault(x => !x.Deleted && x.ClearUrlName == id);

            return artist;
        }

        public List<ArtistForeignSongsCount> ArtistSongsCountByArtistStartLetter(string artistStartletter)
        {
            var artists = dal.Query<ArtistForeign>()
                .Where(x => !x.Deleted)
                .Where(x => x.Name.ToLower().StartsWith(artistStartletter))
                .OrderBy(x => x.Name)
                .Select(x => new ArtistForeignSongsCount
                {
                    Artist = x,
                    SongCount = x.SongsForeign.Count
                }
                ).ToList();

            return artists;
        }

        public IList<SongsByArtistForeignModel> GetPopular()
        {
            SongsByArtistRussianModel model = null;

            var songs = dal.GetSession()
                .QueryOver<SongForeign>()
                .Where(x => !x.Deleted && x.ArtistForeign != null)
                .SelectList(list => list
                    .SelectGroup(x => x.ArtistForeign).WithAlias(() => model.Artist)
                    .SelectCount(x => x.ArtistForeign).WithAlias(() => model.SongsCount)
                    )
                .TransformUsing(Transformers.AliasToBean<SongsByArtistForeignModel>())
                .List<SongsByArtistForeignModel>();

            return songs;
        }
    }
}
