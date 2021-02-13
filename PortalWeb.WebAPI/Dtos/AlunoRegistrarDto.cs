using System;

namespace PortalWeb.WebAPI.Dtos
{
  public class AlunoRegistrarDto
  {
    public int Id { get; set; }
    public int Matricula { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public DateTime DataNasc { get; set; }
    public DateTime DataIni { get; set; } = DateTime.Now;
    public DateTime? DataFim { get; set; } = null;
    public bool Ativo { get; set; } = true;
  }
}