using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerPlayers.Models
{
    public class Repository //CRUD и еще чут-чут
    {
        private readonly SoccerContext context;
        public Repository(SoccerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return context.Players.Include(player => player.Team).ToList();
        }
        public Player FindPlayer(int id)
        {
            return context.Players.Include(player => player.Team).Single(player => player.Id == id);
        }
        public void SavePlayer(Player player)
        {
            context.Players.Add(player);
            context.SaveChanges();
        }

        public void UpdatePlayer(Player player)
        {
            context.Players.Update(player);
            context.SaveChanges();
        }

        public void DeletePlayer(int id) //этот метод не используется, но если потребуется оставить команду, но удалить игрока, то можно прибегнуть к нему
        {
            context.Players.Remove(context.Players.Single(p => p.Id == id));
            context.SaveChanges();
        }

        public void DeleteTeam(int id) //чтобы удалить игрока, достаточно удалить команду, потому что есть каскадное удаление
        {
            context.Teams.Remove(context.Teams.Single(t => t.Id == id));
            context.SaveChanges();
        }

        public SelectList GetTeamNames()
        {
            return new SelectList(context.Teams, "Id", "TeamName");
        }
    }
}
