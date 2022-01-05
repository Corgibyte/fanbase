using System.Collections.Generic;

namespace Fanbase.Models
{
  public class Country
  {
    public int CountryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Actor> Actors { get; set; }
    public virtual ICollection<Film> Films { get; set; }

    public Country()
    {
      this.Actors = new HashSet<Actor>();
      this.Films = new HashSet<Film>();
    }
  }
}