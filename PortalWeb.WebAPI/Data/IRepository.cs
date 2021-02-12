using PortalWeb.WebAPI.Models;

namespace PortalWeb.WebAPI.Data
{
  public interface IRepository
  {
    //string pegaResposta();
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    bool SaveChanges();
    //void Remove<T>(T entity) where T : class;
    //Alunos
    Aluno[] GetAllAlunos(bool includeProfessor = false);
    Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
    Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

    //Professores
    Professor[] GetAllProfessores(bool includeAlunos = false);
    Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
    Professor GetProfessorById(int professorId, bool includeProfessor = false);
  }
}