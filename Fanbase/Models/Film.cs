using System.Collections.Generic;
using System;

namespace Fanbase.Models
{
  public class Film
  {
    public Film()
    {
      this.JoinEntities = new HashSet<ActorFilm>();
    }

    public int FilmId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfRelease { get; set; }
    public string Director { get; set; }
    public bool IsOriginalWork { get; set; }
    public virtual ICollection<ActorFilm> JoinEntities { get; set; }
    public virtual Country Country { get; set; }
    public int CountryId { get; set; }
  }
}