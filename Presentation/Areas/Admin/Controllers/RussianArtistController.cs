using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Gitarist.Bll;
using Gitarist.Areas.Admin.Models;
using Gitarist.Domain;
using GitaristInterfaces;

namespace Gitarist.Areas.Admin.Controllers
{
    [Authorize]
    public class RussianArtistController : Controller
    {
        //
        // GET: /Admin/RussianArtist/

        private IArtistRussianBll _artistRussianBll;

        public RussianArtistController(IArtistRussianBll artistRussianBll)
        {
            _artistRussianBll = artistRussianBll;
        }


        [HttpGet]
        public ActionResult Index()
        {

            var dbArtists = _artistRussianBll.GelAll();
            var viewModel = Mapper.Map<List<ArtistRusianViewModel>>(dbArtists);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View(new ArtistRusianViewModel());
        }

        [HttpPost]
        public ActionResult Add(ArtistRusianViewModel artist)
        {
            if (ModelState.IsValid)
            {
                var newArtist = Mapper.Map<ArtistRussian>(artist);
                _artistRussianBll.SaveOrUpdate(newArtist);

                return RedirectToAction("Index");
            }
            
            return View(artist);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dbArtistRussian = _artistRussianBll.Get(id);
            var viewModel = Mapper.Map<ArtistRusianViewModel>(dbArtistRussian);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ArtistRusianViewModel artist)
        {
            if (ModelState.IsValid)
            {
                var editedArtist = _artistRussianBll.Get(artist.id);
                if (editedArtist != null)
                {
                    editedArtist.Name = artist.name;
                    editedArtist.Biography = artist.biography;
                    editedArtist.IsPopular = artist.isPopular;
                    editedArtist.ClearUrlName = artist.clearUrlName;
                    _artistRussianBll.SaveOrUpdate(editedArtist);
                }
                return RedirectToAction("Index");
            }
            
            return View(artist);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _artistRussianBll.Delete(id);   
            
            return RedirectToAction("Index");
        }

    }
}
