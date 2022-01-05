namespace Fanbase.Models
{
  public class ActorFilm
  {
    public int ActorFilmId { get; set; }
    public int ActorId { get; set; }
    public int FilmId { get; set; }
    public virtual Actor Actor { get; set; }
    public virtual Film Film { get; set; }
  }
}