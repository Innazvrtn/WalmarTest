using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Walmar.BLL.Interfaces;
using Walmar.DLL.Interface;
using Newtonsoft.Json;
using Walmar.BLL.JsonParseLogic;
using Walmar.DLL;
using AutoMapper;
using Walmar.BLL.DTO;

namespace Walmar.BLL.Services
{
    public class GoodsService : IGoodsService
    {
        IUnitOfWork DataBase { get; set; }
        public GoodsService(IUnitOfWork uow)
        {
            DataBase = uow;
        }
        public void CreateGoods(string url)
        {
            var json = new WebClient();
            json.Headers.Add("User-Agent: Other");
            string data = getBetween(json.DownloadString(url), "\"midasContext\":", "}");
            var temp = JsonConvert.DeserializeObject<GoodsJson>(data);
            var check=DataBase.Goods.Find(g => g.ProductId == temp.ProductId);
            if (check.Count()!=0)
            {
                CreateReview(url, DataBase.Goods.GetAll().Where(g => g.ProductId == temp.ProductId).Select(g => g.Id).FirstOrDefault());
            }
            else
            {
                List<Goods> goods = new List<Goods>
                {
                   new Goods { Id = Guid.NewGuid(),
                    ProductId = temp.ProductId,
                    Price = temp.Price,
                    Name = temp.Query }
                };
                DataBase.Goods.Create(goods);
                DataBase.Save();
                CreateReview(url, goods[0].Id);
            }

        }
        public void CreateReview(string url, Guid goodsId)
        {
            
            Uri myUri = new Uri(url);
            string[] pathsegments = myUri.Segments;
            var s = pathsegments[3];
            var urlForReviev = @"https://www.walmart.com/terra-firma/item/" + s + @"/reviews?showProduct=false&sort=relevancy&filters=&page=1&limit=10";
            var json = new WebClient();
            json.Headers.Add("User-Agent: Other");
            var review = JsonConvert.DeserializeObject<JsonParseLogic.GoodsReviewJ>(json.DownloadString(urlForReviev));
            for (var i = 1; i < Math.Ceiling(Convert.ToDouble(review.payload.totalReviewCount/ 10)); i++)
            {
                urlForReviev = @"https://www.walmart.com/terra-firma/item/" + s + @"/reviews?showProduct=false&sort=relevancy&filters=&page=" + i + "&limit=10";
                json.Headers.Add("User-Agent: Other");
                review = JsonConvert.DeserializeObject<JsonParseLogic.GoodsReviewJ>(json.DownloadString(urlForReviev));
                List<GoodsReview> reviews = new List<GoodsReview>();
                foreach (var r in review.payload.customerReviews)
                {
                   
                    if (DataBase.GoodsReview.Find(g => g.ReviewIdWalmar == r.reviewId).Count() == 0)
                    {
                        reviews.Add(new GoodsReview
                        {
                            ReviewText = r.reviewText,
                            Id = Guid.NewGuid(),
                            GoodId = goodsId,
                            ReviewIdWalmar = r.reviewId
                        });
                      
                    } 
                }
                DataBase.GoodsReview.Create(reviews);
                DataBase.Save();
            }   
        }


        public IEnumerable<GoodsReviewDTO> SearchByKeyWords(string word)
        {
            var search = DataBase.GoodsReview.Find(sc => sc.ReviewText.Contains(" "+word+" "));
            Mapper.Initialize(cfg => cfg.CreateMap<GoodsReview, GoodsReviewDTO>());
            var com = Mapper.Map<IEnumerable<GoodsReview>, List<GoodsReviewDTO>>(search);
            return com;

        }

        private static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start + 1);
            }
            else
            {
                return "";
            }
        }
        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
