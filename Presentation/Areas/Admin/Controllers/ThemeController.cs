using AutoMapper;
using Gitarist.Areas.Admin.Models;
using Gitarist.Bll;
using System.Collections.Generic;
using System.Web.Mvc;
using Gitarist.Domain;
using GitaristInterfaces;

namespace Gitarist.Areas.Admin.Controllers
{
    [Authorize]
    public class ThemeController : Controller
    {
        private readonly IThemeBll _themeBll;
        public ThemeController(IThemeBll themeBll)
        {
            _themeBll = themeBll;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var dbThemes = _themeBll.GelAll();
            var viewModel = Mapper.Map<List<ThemeViewModel>>(dbThemes);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View(new ThemeViewModel());
        }

        [HttpPost]
        public ActionResult Add(ThemeViewModel theme)
        {

            if (ModelState.IsValid)
            {
                var newTheme = Mapper.Map<Theme>(theme);
                _themeBll.SaveOrUpdate(newTheme);
                
                return RedirectToAction("Index");
            }
         
            return View(theme);

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var editedTheme = _themeBll.Get(id);
            
            var themeViewModel = Mapper.Map<ThemeViewModel>(editedTheme);
            
            return View(themeViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ThemeViewModel theme)
        {

            if (ModelState.IsValid)
            {
                var editedTheme = _themeBll.Get(theme.id);
                
                if (editedTheme != null)
                {
                    editedTheme.Name = theme.name;
                    editedTheme.ClearUrlName = theme.clearUrlName;
                    
                    _themeBll.SaveOrUpdate(editedTheme);
                }
                return RedirectToAction("Index");
            }
            
            return View(theme);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _themeBll.Delete(id);

            return RedirectToAction("Index");
        }

    }
}
