using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

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
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOfRelease { get; set; }
    public string Director { get; set; }
    public bool IsOriginalWork { get; set; }
    public virtual ICollection<ActorFilm> JoinEntities { get; set; }
    public virtual Country Country { get; set; }
    public int CountryId { get; set; }
  }
}