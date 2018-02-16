using System.Collections.Generic;
using AutoMapper;
using Gitarist.Areas.Admin.Models;
using Gitarist.Areas.Admin.Models.Song;
using Gitarist.Bll;
using Gitarist.Helpers;
using System;
using System.Web.Mvc;
using Gitarist.Bll.Models;
using GitaristInterfaces;

namespace Gitarist.Areas.Admin.Controllers
{
    [Authorize]
    public class ForeignSongController : Controller
    {
        private readonly ISongForeignBll _songBll;

        public ForeignSongController(ISongForeignBll songBll)
        {
            _songBll = songBll;
        }

        [HttpGet]
        public ActionResult Index(string id, string idc)
        {
            var enSongsDb = _songBll.GelSongsByArtistAndTheme(id, idc);

            var enSongsModel = Mapper.Map<List<SongForeignViewModel>>(enSongsDb);

            var viewModel = new SongForeignFilteredViewModel
            {
                ArtistId = !string.IsNullOrEmpty(id) ? Convert.ToInt64(id) : -1,
                ThemeId = !string.IsNullOrEmpty(idc) ? Convert.ToInt64(idc) : -1,
                Songs = enSongsModel
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new SongForeignViewModel());
        }

        [HttpPost]
        public ActionResult Add(SongForeignViewModel song)
        {
            if (ModelState.IsValid)
            {
                var newSong = Mapper.Map<EditSongModel>(song);
                _songBll.AddSong(newSong);

                return RedirectToAction("Index");
            }

            return View(song);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var ruSongDb = _songBll.Get(id);

            if (ruSongDb != null)
            {
                var viewModel = Mapper.Map<SongForeignViewModel>(ruSongDb);
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(SongForeignViewModel song)
        {
            if (ModelState.IsValid)
            {
                song.chords = ChordsHelper.ReplaceChordsHToB(song.chords);

                _songBll.UpdateSong(Mapper.Map<EditSongModel>(song));


                if (!string.IsNullOrEmpty(Request.Form["Save"]))
                    return View(song);
                if (!string.IsNullOrEmpty(Request.Form["SaveAndClose"]))
                    return RedirectToAction("Index");

                return RedirectToAction("Index");
            }

            return View(song);
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            _songBll.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Search(SearchResult searchResult)
        {
            string id = searchResult.Criteria;

            var ruSongs = _songBll.Search(id);
            ViewBag.SearchCriteria = searchResult.Criteria;
            searchResult = new SearchResult {Criteria = id, engSongs = Mapper.Map<List<SongForeignViewModel>>(ruSongs)};
            return View(searchResult);
        }
    }
}