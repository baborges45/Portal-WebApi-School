using System.Collections.Generic;

namespace PortalWeb.WebAPI.Models
{
  public class Aluno
  {
    public Aluno() { }
    public Aluno(int id, string nome, string sobrenome, string email)
    {
      this.Id = id;
      this.Nome = nome;
      this.Sobrenome = sobrenome;
      this.Email = email;

    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }

    public IEnumerable<AlunoDisciplina> AlunosDisciplina { get; set; }
  }
}