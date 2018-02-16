using AutoMapper;
using Gitarist.Areas.Admin.Models;
using Gitarist.Areas.Admin.Models.Song;
using Gitarist.Bll;
using System.Collections.Generic;
using System.Web.Mvc;
using GitaristInterfaces;

namespace Gitarist.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongRussianBll _songRuBll;
        private readonly ISongForeignBll _songEnBll;

        public SongController(ISongRussianBll songRuBll, ISongForeignBll songEnBll)
        {
            _songRuBll = songRuBll;
            _songEnBll = songEnBll;
        }

        public ActionResult Search(SearchResult searchResult)
        {
            string id = searchResult.Criteria;

            var ruSongs = _songRuBll.Search(id);
            var enSongs = _songEnBll.Search(id);
            ViewBag.SearchCriteria = searchResult.Criteria;
            
            searchResult = new SearchResult { Criteria = id, ruSongs = Mapper.Map<List<SongRusianViewModel>>(ruSongs), engSongs = Mapper.Map<List<SongForeignViewModel>>(enSongs) };
            
            return View(searchResult);
        }

    }
}
