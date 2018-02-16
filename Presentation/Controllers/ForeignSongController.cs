using AutoMapper;
using Gitarist.Bll;
using Gitarist.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gitarist.Models.ViewModels.Base;
using Gitarist.Domain;
using Gitarist.Models.ViewModels.Theme;
using GitaristInterfaces;

namespace Gitarist.Controllers
{
    public class ForeignSongsController : Controller
    {
 
        private readonly ISongForeignBll _songEnBll;
        private readonly IThemeBll _themell;

        private readonly IArtistForeignBll _artistEnBll;

        public ForeignSongsController(ISongForeignBll songEnBll, IThemeBll themell, IArtistForeignBll artistEnBll)
        {
            _songEnBll = songEnBll;
            _themell = themell;

            _artistEnBll = artistEnBll;
        }
        
       public ActionResult ArtistSongs(string id)
        {
            ArtistForeign dbArtist = _artistEnBll.GetByIdOrClearUrlName(id);
            if (dbArtist == null) return RedirectToAction("Index", "Start");

            var artistModel = Mapper.Map<ArtistViewModel>(dbArtist);
            var dbSongs = dbArtist.SongsForeign.Where(song => !song.Deleted).ToList();

            var ruSongsModel = Mapper.Map<List<SongViewModel>>(dbSongs);

            return View("ByArtist", new SongForeignByArtist
            {
                Artist = artistModel,
                ArtistSongs = ruSongsModel
            });
        }

       public ActionResult ById(string id)
       {
           var newSongs = _songEnBll.GetNew();
           var songModel = Mapper.Map<SongViewModel>(_songEnBll.Get(Convert.ToInt64(id)));
           return View(songModel);
       }
     

        public ActionResult ShowChords(string id, string idc)
        {
            string artist = id;
            string song = idc;

            SongForeign dbSong = null;
            ArtistForeign dbArtist = null;
            
            if (string.IsNullOrEmpty(song) )
                dbSong =  _songEnBll.GetByIdOrClearUrlName(artist);
            else
            {
                dbArtist = _artistEnBll.GetByIdOrClearUrlName(artist);
                if (dbArtist != null)
                    dbSong = _songEnBll.GetByArtistIdAndSongIdOrClearUrlName(dbArtist.Id, song);
            }
            
            if (dbSong==null)
                return RedirectToAction("Index", "Home");

            var songModel = Mapper.Map<SongViewModel>(dbSong);

            return View("ById", songModel);
        }

     
        public ActionResult New()
        {
            var newSongs = _songEnBll.GetNew();
            var songsModel = Mapper.Map<List<SongViewModel>>(newSongs);
            return View(songsModel);
        }
    
       public ActionResult Popular()
       {
            var popularSongs = _songEnBll.GetPopular();
            var songsModel = Mapper.Map<List<SongViewModel>>(popularSongs);
            return View(songsModel);
       }

       public ActionResult SongsByThemes()
       {
           var songsByThemes = _songEnBll.SongsCountByThemes();

           var model = Mapper.Map<List<ThemeSongCount>>(songsByThemes);
         
           return View(model);
       }

       public ActionResult ThemeSongs(string id)
       {
           var themeDb = _themell.GetByIdOrClearUrlName(id);

           var themeSongs = Mapper.Map<List<SongViewModel>>(_songEnBll.SongsByThemes(themeDb.Id));
           
           var themeModel = Mapper.Map<ThemeViewModel>(themeDb);

           return View(
               new SongsByTheme
               {
                   Theme = themeModel,
                   Songs = themeSongs
               }
          );

       }

    }
}
