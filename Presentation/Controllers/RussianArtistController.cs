using AutoMapper;
using Gitarist.Bll;
using Gitarist.Models.ViewModels.Artist;
using Gitarist.Models.ViewModels.ArtistRusian;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Gitarist.Models.ViewModels.Base;
using GitaristInterfaces;

namespace Gitarist.Controllers
{
    public class RussianArtistController : Controller
    {
        private readonly IArtistRussianBll _artistRuBll;
        private readonly ISongRussianBll _songRussianBll;

        public RussianArtistController(IArtistRussianBll artistRuBll, ISongRussianBll songRussianBll)
        {
            _artistRuBll = artistRuBll;
            _songRussianBll = songRussianBll;
        }

        public ActionResult ViewByLetter(int id)
        {
            var letterString = Convert.ToChar(id).ToString().ToLower();
            
            var artists = Mapper.Map<List<ArtistRussianCount>>(_artistRuBll.ArtistSongsCountByArtistStartLetter(letterString));

            var artistSongs = Mapper.Map<List<SongViewModel>>(_songRussianBll.ArtistLessRussianSongsByArtistStartLetter(letterString));
            
            return View(
                new ArtistsRusianByLetter
                    {
                        Letter = letterString,
                        Artists = artists,
                        ArtistlessSongs = artistSongs
                    }
                );
        }

        public ActionResult Popular()
        {
            var viewModel = Mapper.Map<List<PopularArtistCount>>(_artistRuBll.GetPopular());

            return View(viewModel);
        }
    }
}