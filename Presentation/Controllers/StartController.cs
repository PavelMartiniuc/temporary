using System;
using AutoMapper;
using Gitarist.Bll;
using Gitarist.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using Gitarist.Models.ViewModels.Base;
using GitaristInterfaces;

namespace Gitarist.Controllers
{
    public class Test
    {
        public string GetStrig()
        {
            return "string";
        }
    }

    [HandleError]
    public class StartController : Controller
    {
        //
        // GET: /Home/

        private readonly ISongRussianBll _songRuBll;
        private readonly ISongForeignBll _songEnBll;

        private readonly IArtistRussianBll _artistRuBll;
        private readonly IArtistForeignBll _artistEnBll;

        public StartController(ISongRussianBll songRuBll, ISongForeignBll songEnBll, IArtistRussianBll artistRuBll, IArtistForeignBll artistEnBll)
        {
            _songRuBll = songRuBll;
            _songEnBll = songEnBll;

            _artistRuBll = artistRuBll;
            _artistEnBll = artistEnBll;
        }

        private void DoSomeWork()
        {
            
        }

        public ActionResult Index()
        {

               
            Test( new Test() , t => t.GetStrig());
            var model = new StartPage

            {
                LastRuSongs = Mapper.Map<List<SongViewModel>>(_songRuBll.GelAll(20)),
                PopularRuSongs = Mapper.Map<List<SongViewModel>>(_songRuBll.PopularBySong(20)),
                PopularRuArtists = Mapper.Map<List<ArtistViewModel>>(_artistRuBll.GelPopular(20)),

                LastEngSongs = Mapper.Map<List<SongViewModel>>(_songEnBll.GelAll(20)),
                PopularEngSongs = Mapper.Map<List<SongViewModel>>(_songEnBll.PopularBySong(20)),
                PopularEngArtists = Mapper.Map<List<ArtistViewModel>>(_artistEnBll.GelPopular(20))
            };
            return View(model); 
        }

        public void Test(Test t, Action<Test> acton)
        {
            acton(t);
        }


        public ActionResult Exam()
        {
            return View();
        }

        public ActionResult Ajax(string name, string surname)
        {
            //for (var i = 0; i <= 9000000000; i++)
            //{
            //    var a = i + 1;
            //}
            return View(model: name + " " +surname);
        }


    }
}
