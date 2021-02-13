using System;
using System.Collections.Generic;

namespace PortalWeb.WebAPI.Models
{
  public class Aluno
  {
    public Aluno() { }
    public Aluno(int id,
                 int matricula,
                 string nome,
                 string sobrenome,
                 string email,
                 DateTime dataNasc)
    {
      this.Id = id;
      this.Matricula = matricula;
      this.Nome = nome;
      this.Sobrenome = sobrenome;
      this.Email = email;
      this.DataNasc = dataNasc;
    }
    public int Id { get; set; }
    public int Matricula { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public DateTime DataNasc { get; set; }
    public DateTime DataIni { get; set; } = DateTime.Now;
    public DateTime? DataFim { get; set; } = null;
    public bool Ativo { get; set; } = true;
    public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
  }
}