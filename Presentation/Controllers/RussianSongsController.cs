using AutoMapper;
using Gitarist.Bll;
using Gitarist.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gitarist.Models.ViewModels.Base;
using Gitarist.Domain;
using Gitarist.Models.ViewModels.Theme;
using GitaristInterfaces;

namespace Gitarist.Controllers
{
    public class RussianSongsController : Controller
    {
        private readonly ISongRussianBll _songRuBll;
        
        private readonly IThemeBll _themell;

        private readonly IArtistRussianBll _artistRuBll;

        public RussianSongsController(ISongRussianBll songRuBll, IThemeBll themeBll, IArtistRussianBll artistRuBll)
        {
            _songRuBll = songRuBll;
            _themell = themeBll;

            _artistRuBll = artistRuBll;
        }
        
       public ActionResult ArtistSongs(string id)
        {
            ArtistRussian dbArtist = _artistRuBll.GetByIdOrClearUrlName(id);
            if (dbArtist == null) return RedirectToAction("Index", "Home");

            var artistModel = Mapper.Map<ArtistViewModel>(dbArtist);
            var dbSongs = dbArtist.SongRussians.Where(song => !song.Deleted).ToList();

            var ruSongsModel = Mapper.Map<List<SongViewModel>>(dbSongs);

            return View("ByArtist", new SongRusianByArtist
            {
                Artist = artistModel,
                ArtistSongs = ruSongsModel
            });
        }

        public ActionResult ShowChords(string id, string idc)
        {
            string artist = id;
            string song = idc;

            SongRussian dbSong = null;
            ArtistRussian dbArtist = null;
            
            if (string.IsNullOrEmpty(song) )
                dbSong =  _songRuBll.GetByIdOrClearUrlName(artist);
            else
            {
                dbArtist = _artistRuBll.GetByIdOrClearUrlName(artist);
                if (dbArtist != null)
                    dbSong = _songRuBll.GetByArtistIdAndSongIdOrClearUrlName(dbArtist.Id, song);
            }
            
            if (dbSong==null)
                return RedirectToAction("Index", "Home");

            var songModel = Mapper.Map<SongViewModel>(dbSong);

            return View("ById", songModel);
        }

        public ActionResult ById(string id)
        {
            var newSongs = _songRuBll.GetNew();
            var songModel = Mapper.Map<SongViewModel>(_songRuBll.Get(Convert.ToInt64(id)));
            return View(songModel);
        }
     
        public ActionResult New()
        {
            var newSongs = _songRuBll.GetNew();
            var songsModel = Mapper.Map<List<SongViewModel>>(newSongs);
            return View(songsModel);
        }
    
       public ActionResult Popular()
       {
            
           var popularSongs = _songRuBll.GetPopular();
            var songsModel = Mapper.Map<List<SongViewModel>>(popularSongs);
            return View(songsModel);
       }

       public ActionResult SongsByThemes()
       {
           var songsByThemes = _songRuBll.SongsCountByThemes();

           var model = Mapper.Map<List<ThemeSongCount>>(songsByThemes);
         
           return View(model);
       }

       public ActionResult ThemeSongs(string id)
       {
           var themeDb = _themell.GetByIdOrClearUrlName(id);

           var themeSongs = Mapper.Map<List<SongViewModel>>(_songRuBll.SongsByThemes(themeDb.Id));
           
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
