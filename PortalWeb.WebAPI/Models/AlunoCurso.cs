using System;

namespace PortalWeb.WebAPI.Models
{
  public class AlunoCurso
  {
    public AlunoCurso() { }
    public AlunoCurso(int alunoId, int cursoId)
    {
      this.AlunoId = alunoId;
      this.CursoId = cursoId;
    }
    public int AlunoId { get; set; }

    public Aluno Aluno { get; set; }

    public DateTime DataIni { get; set; } = DateTime.Now;

    public DateTime? DataFim { get; set; }

    public int CursoId { get; set; }

    public Cursos Curso { get; set; }
  }
}