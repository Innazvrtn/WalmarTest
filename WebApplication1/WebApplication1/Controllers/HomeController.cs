using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Walmar.BLL.Interfaces;
using System.Text.RegularExpressions;
using Walmar.BLL.DTO;
using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{



    public class HomeController : Controller
    {
        IGoodsService goodsService;
        public HomeController(IGoodsService serv)
        {
            goodsService = serv;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
       
        public string Index(string url)
        {
            goodsService.CreateGoods(url);
            return "Create";
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string word)
        {
            IEnumerable<GoodsReviewDTO> reviews = goodsService.SearchByKeyWords(word);
            Mapper.Initialize(cfg => cfg.CreateMap<GoodsReviewDTO, GoodsReviewViewModel>());
            var com = Mapper.Map<IEnumerable<GoodsReviewDTO>, List<GoodsReviewViewModel>>(reviews);
            if (com == null)
            {
                return View();
            }
            else
            {
                return View("SearchResult", com);
            }
           
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                goodsService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}