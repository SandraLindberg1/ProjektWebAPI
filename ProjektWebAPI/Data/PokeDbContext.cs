using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektWebAPI.Data
{
    public class PokeDbContext : DbContext
    {
        public PokeDbContext(DbContextOptions<PokeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pokeapi> Pokeapis { get; set; }

        public static async Task Reset(IServiceProvider provider)
        {
            var context = provider.GetRequiredService<PokeDbContext>();

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            await context.Pokeapis.AddRangeAsync(
                new Pokeapi { Name = "spearow", Url = "https://pokeapi.co/api/v2/pokemon/21/" },
                new Pokeapi { Name = "fearow", Url = "https://pokeapi.co/api/v2/pokemon/22/" },
                new Pokeapi { Name = "ekans", Url = "https://pokeapi.co/api/v2/pokemon/23/" },
                new Pokeapi { Name = "arbok", Url = "https://pokeapi.co/api/v2/pokemon/24/" },
                new Pokeapi { Name = "pikachu", Url = "https://pokeapi.co/api/v2/pokemon/25/" },
                new Pokeapi { Name = "raichu", Url = "https://pokeapi.co/api/v2/pokemon/26/" },
                new Pokeapi { Name = "sandshrew", Url = "https://pokeapi.co/api/v2/pokemon/27/" },
                new Pokeapi { Name = "sandslash", Url = "https://pokeapi.co/api/v2/pokemon/28/" },
                new Pokeapi { Name = "nidoran-f", Url = "https://pokeapi.co/api/v2/pokemon/29/" },
                new Pokeapi { Name = "nidorina", Url = "https://pokeapi.co/api/v2/pokemon/30/" }
                );
            await context.SaveChangesAsync();
        }


    }
}
