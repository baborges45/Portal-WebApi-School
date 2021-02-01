using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PortalWeb.WebAPI.Models;

namespace PortalWeb.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AlunoController : ControllerBase
  {
    public List<Aluno> Alunos = new List<Aluno>(){
          new Aluno(){
                Id = 1,
                Nome = "Bruno",
                Sobrenome = "Borges",
                Email = "gmail.com"
          },
                    new Aluno(){
                Id = 2,
                Nome = "Carol",
                Sobrenome = "Lobo",
                Email = "outlook.com"
          },
                    new Aluno(){
                Id = 3,
                Nome = "Pedro",
                Sobrenome = "Costa",
                Email = "hotmail.com"
          },
      };
    public AlunoController() { }
    [HttpGet]
    public IActionResult Get()
    {
      return Ok(Alunos);
    }
    [HttpGet("byId/{id}")]
    public IActionResult GetById(int id)
    {
      var aluno = Alunos.FirstOrDefault(a => a.Id == id);
      if (aluno == null) return BadRequest("O aluno não foi encontrado.");
      return Ok(aluno);
    }
    [HttpGet("ByName")]
    public IActionResult GetByName(string Nome, string Sobrenome)
    {
      var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(Nome)
      && a.Sobrenome.Contains(Sobrenome));
      if (aluno == null) return BadRequest("O aluno não foi encontrado.");
      return Ok(aluno);
    }
    [HttpPost()]
    public IActionResult Post(Aluno aluno)
    {
      return Ok(aluno);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, Aluno aluno)
    {
      return Ok(aluno);
    }
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Aluno aluno)
    {
      return Ok(aluno);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Ok();
    }
  }
}