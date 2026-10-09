using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Playlist.Controllers
{

    public class PlaylistController : Controller
    {

        private string[] songs =
    {
    "Bohemian Rhapsody - Queen",
    "Don't Stop Believin' - Journey",
    "Stayin' Alive - Bee Gees",
    "Rolling in the Deep - Adele",
    "Sweet Caroline - Neil Diamond",
    "Hotel California - Eagles"
};
        [Route("liner-notes")]
        public IActionResult Notes()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(songs);
        }

        [Route("track/{number:int?}")]
        public IActionResult Track(int number = 1)
        {
            if (number < 1 || number > songs.Length)
            {
                return NotFound();
            }

            ViewBag.Number = number;
            ViewBag.TotalTracks = songs.Length;

            return View("Track", songs[number - 1]);
        }


        public IActionResult Find(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return View();
            }

            var results = songs
                .Where(song => song.Contains(
                    searchTerm,
                    StringComparison.OrdinalIgnoreCase))
                .ToArray();

            return View("Find", results);
        }
    }
}