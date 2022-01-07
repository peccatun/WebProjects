using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeaChess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeaChess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<GameRequest> GameRequests { get; set; }

        public DbSet<GameState> GameStates { get; set; }

        public DbSet<Game> Games { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
