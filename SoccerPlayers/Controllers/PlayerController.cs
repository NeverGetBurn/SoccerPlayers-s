using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerPlayers.Models;

namespace SoccerPlayers.Controllers
{
    public class PlayerController : Controller
    {
        private readonly Repository repo;
        public PlayerController(Repository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Index() 
        {
            var model = repo.GetPlayers();
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult AddPlayer()
        {
            ViewBag.Bag = repo.GetTeamNames();
            return View();
        }

        [HttpPost]
        public IActionResult AddPlayer(Player model)
        {
            repo.SavePlayer(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPlayer(int id)
        {
            if (id != null)
            {
                var player = repo.FindPlayer(id);
                if (player != null)
                {
                    return View(player);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditPlayer(Player player)
        {
            repo.UpdatePlayer(player);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletePlayer(int id)
        {
            repo.DeleteTeam(id); //описание в репозитории
            return RedirectToAction("Index");
               
        }
    }
}