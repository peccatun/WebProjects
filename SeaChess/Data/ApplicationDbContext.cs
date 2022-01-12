using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeaChess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeaChess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<GameRequest> GameRequests { get; set; }

        public DbSet<GameState> GameStates { get; set; }

        public DbSet<Game> Game { get; set; }

        public DbSet<GameSign> GameSigns { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
