using System.Collections.Generic;
using System;

namespace Fanbase.Models
{
  public class Actor
  {
    public Actor()
    {
      this.JoinEntities = new HashSet<ActorFilm>();
    }

    public int ActorId { get; set; }
    public string Name { get; set; }
    public bool Oscar { get; set; }
    public bool IsMcu { get; set; }
    public DateTime DateOfBirth { get; set; }
    public virtual Country Country { get; set; }
    public int CountryId { get; set; }

    public virtual ICollection<ActorFilm> JoinEntities { get; set; }
  }
}

