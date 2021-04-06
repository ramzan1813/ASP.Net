using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JokeWeb.Models;

namespace JokeWeb.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<JokeWeb.Models.Joke> Joke { get; set; }
		public DbSet<JokeWeb.Models.Ramzan> Ramzan { get; set; }
	}
}
