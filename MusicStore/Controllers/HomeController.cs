using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MusicStore.Models;


namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private List<Album> albums;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchBy, string searchText) 
        {
            var searchtxt = searchText.ToLower();
            List<Album> records = new List<Album>();

            makeAlbums();
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
                    records = albums.Where(x => x.Year == Int32.Parse(searchtxt)).ToList();
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

        private void makeAlbums()
        {
            albums = new List<Album>
            {
                new Album {
                    Id = 1,
                    Title = "Look What the Cat Dragged In",
                    Artist = "Poison",
                    Year = 1986
                },

               new Album {
                    Id = 2,
                    Title = "Shout at the Devil",
                    Artist = "Motley Crue",
                    Year = 1983
                },

                new Album {
                    Id = 3,
                    Title = "Appetite for Destruction",
                    Artist = "Guns N Roses",
                    Year = 1987
                },

                new Album {
                    Id = 4,
                    Title = "Detonator",
                    Artist = "Ratt",
                    Year = 1990
                },

                new Album {
                    Id = 5,
                    Title = "Dirty Rotten Filthy Stinking Rich",
                    Artist = "Warrant",
                    Year = 1988
                },

                new Album {
                    Id = 6,
                    Title = "New Jersey",
                    Artist = "Bon Jovi",
                    Year = 1988
                },

                new Album {
                    Id = 7,
                    Title = "Master of Puppets",
                    Artist = "Metallica",
                    Year = 1986
                },

                new Album {
                    Id = 8,
                    Title = "Screaming for Venegance",
                    Artist = "Judas Priest",
                    Year = 1982
                },

                new Album {
                    Id = 9,
                    Title = "Blackout",
                    Artist = "Die Scorpions",
                    Year = 1982
                },

                new Album {
                    Id = 10,
                    Title = "Hysteria",
                    Artist = "Def Leppard",
                    Year = 1987
                },

                new Album {
                    Id = 11,
                    Title = "Whitesnake",
                    Artist = "Whitesnake",
                    Year = 1987
                },

                new Album {
                    Id = 12,
                    Title = "Long Cold Winter",
                    Artist = "Cinderella",
                    Year = 1988
                },

                new Album
                {
                    Id = 13,
                    Title = "Out of the Blue",
                    Artist = "Debbie Gibson",
                    Year = 1987
                },

                new Album
                {
                    Id = 14,
                    Title = "Slave to the Grind",
                    Artist = "Skid Row",
                    Year = 1991
                },

                new Album
                {
                    Id = 15,
                    Title = "Stay Hungry",
                    Artist = "Twisted Sister",
                    Year = 1984
                }
            };
        }

    }
}