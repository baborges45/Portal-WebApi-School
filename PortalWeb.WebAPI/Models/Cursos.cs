using System.Collections.Generic;

namespace PortalWeb.WebAPI.Models
{
  public class Cursos
  {
    public Cursos() { }

    public Cursos(int id, string nome)
    {
      this.Id = id;
      this.Nome = nome;

    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public IEnumerable<Disciplina> Disciplinas { get; set; }
  }
}