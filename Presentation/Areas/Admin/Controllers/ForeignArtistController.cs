using AutoMapper;
using Gitarist.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Gitarist.Bll;
using Gitarist.Domain;
using GitaristInterfaces;

namespace Gitarist.Areas.Admin.Controllers
{
    [Authorize]
    public class ForeignArtistController : Controller
    {
        private readonly IArtistForeignBll _artistForeignBll;

        public ForeignArtistController(IArtistForeignBll artistForeignBll)
        {
            _artistForeignBll = artistForeignBll;
        }


        [HttpGet]
        public ActionResult Index()
        {

            var dbArtists = _artistForeignBll.GelAll();
            var viewModel = Mapper.Map<List<ArtistForeignViewModel>>(dbArtists);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View(new ArtistForeignViewModel());
        }

        [HttpPost]
        public ActionResult Add(ArtistForeignViewModel artist)
        {
            if (ModelState.IsValid)
            {
                var newArtist = Mapper.Map<ArtistForeign>(artist);
                _artistForeignBll.SaveOrUpdate(newArtist);

                return RedirectToAction("Index");
            }
            
            return View(artist);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dbArtistForeign = _artistForeignBll.Get(id);
            var viewModel = Mapper.Map<ArtistForeignViewModel>(dbArtistForeign);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ArtistForeignViewModel artist)
        {
            if (ModelState.IsValid)
            {
                var editedArtist = _artistForeignBll.Get(artist.id);
                if (editedArtist != null)
                {
                    editedArtist.Name = artist.name;
                    editedArtist.Biography = artist.biography;
                    editedArtist.IsPopular = artist.isPopular;
                    editedArtist.ClearUrlName = artist.clearUrlName;
                    _artistForeignBll.SaveOrUpdate(editedArtist);
                }
                return RedirectToAction("Index");
            }
            
            return View(artist);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _artistForeignBll.Delete(id);   
            
            return RedirectToAction("Index");
        }

    }
}
