using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fanbase.Models
{
  public class Actor
  {
    public Actor()
    {
      this.JoinEntities = new HashSet<ActorFilm>();
      this.Oscar = false;
    }

    public int ActorId { get; set; }
    public string Name { get; set; }
    public bool Oscar { get; set; }
    public bool IsMcu { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfBirth { get; set; }
    public virtual Country Country { get; set; }
    public int CountryId { get; set; }

    public virtual ICollection<ActorFilm> JoinEntities { get; set; }
  }
}

