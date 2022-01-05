using Microsoft.EntityFrameworkCore;

namespace Fanbase.Models
{
  public class FanbaseContext : DbContext
  {
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<ActorFilm> ActorFilm { get; set; }
    public DbSet<Country> Countries { get; set; }

    public FanbaseContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}