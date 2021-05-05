using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MusicStore.Models;
using MusicStore.DataContexts;


namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private List<Album> albums;
        private EFDbContext db = new EFDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Albums()
        {
            ViewBag.Albums = db.Albums.Tolist().OrderBy(album => album.Title);

            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchBy, string searchText) 
        {
            var searchtxt = searchText.ToLower();
            List<AlbumListModel> records = new List<AlbumListModel>();

            var albums = GetAlbums();

            if (searchText != "" || searchText != null)
            {
                if(searchBy == "Artist")
                {
                    records = albums.Where(x => x.Artist.ToLower().Contains(searchtxt)).ToList();
                }
                else if(searchBy == "Title")
                {
                    records = albums.Where(x => x.Title.ToLower().Contains(searchtxt)).ToList();
                }
                else if (searchBy == "Year")
                {
                    int yearInt = Int32.Parse(searchtxt);
                    records = albums.Where(x => x.Year == yearInt).ToList();
                }
                else
                {
                    records = albums.Where(x => x.Title.ToLower().Contains(searchtxt) || x.Artist.ToLower().Contains(searchtxt)).ToList();
                }
                return View(records);
            }
            else
            {
                var orderedAlbums = albums.OrderBy(a => a.Year);
                return View(orderedAlbums);
            }
        }

        private IQueryable<AlbumListModel> GetAlbums()
        {
            var albums = from alb in db.Albums join art in db.Artists on alb.ArtistId equals art.ArtistId select new AlbumListModel { AlbumId = alb.AlbumId, Artist = art.Name, Title = alb.Title, Year = alb.Year };

            return albums;
        }
    }
}