using AutoMapper;
using Gitarist.Bll;
using Gitarist.Models.ViewModels.Artist;
using Gitarist.Models.ViewModels.ArtistForeign;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Gitarist.Models.ViewModels.Base;
using GitaristInterfaces;

namespace Gitarist.Controllers
{
    public class ForeignArtistController : Controller
    {
        private readonly IArtistForeignBll _artistEnBll;
        private readonly ISongForeignBll _songForeignBll;

        public ForeignArtistController(IArtistForeignBll artistEnBll, ISongForeignBll songForeignBll)
        {
            _artistEnBll = artistEnBll;
            _songForeignBll = songForeignBll;
        }

        public ActionResult ViewByLetter(int id)
        {
            var letterString = Convert.ToChar(id).ToString().ToLower();

            var artists = Mapper.Map<List<ArtistForeignCount>>(_artistEnBll.ArtistSongsCountByArtistStartLetter(letterString));

            var artistSongs = Mapper.Map<List<SongViewModel>>(_songForeignBll.ArtistLessRussianSongsByArtistStartLetter(letterString));

            return View(
                new ArtistsForeignByLetter
                {
                    Letter = letterString,
                    Artists = artists,
                    ArtistLessSongs = artistSongs
                }
                );
        }

        public ActionResult Popular()
        {
            var viewModel = Mapper.Map<List<PopularArtistCount>>(_artistEnBll.GetPopular());

            return View(viewModel);
        }

    }

        
}