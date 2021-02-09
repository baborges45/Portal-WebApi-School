using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalWeb.WebAPI.Data;
using PortalWeb.WebAPI.Models;

namespace PortalWeb.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AlunoController : ControllerBase
  {
    private readonly SmartContext _context;

    public AlunoController(SmartContext context)
    {
      _context = context;
    }


    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_context.Alunos);
    }
    [HttpGet("byId/{id}")]
    public IActionResult GetById(int id)
    {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
      if (aluno == null) return BadRequest("O aluno não foi encontrado.");
      return Ok(aluno);
    }
    [HttpGet("ByName")]
    public IActionResult GetByName(string Nome, string Sobrenome)
    {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(Nome)
      && a.Sobrenome.Contains(Sobrenome));
      if (aluno == null) return BadRequest("O aluno não foi encontrado.");
      return Ok(aluno);
    }
    [HttpPost()]
    public IActionResult Post(Aluno aluno)
    {
      _context.Add(aluno);
      _context.SaveChanges();
      return Ok(aluno);
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, Aluno aluno)
    {
      var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
      if (alu == null) return BadRequest("Aluno não encontrado");
      _context.Update(aluno);
      _context.SaveChanges();
      return Ok(aluno);
    }
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, Aluno aluno)
    {
      var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
      if (alu == null) return BadRequest("Aluno não encontrado");
      _context.Update(aluno);
      _context.SaveChanges();
      return Ok(aluno);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
      if (aluno == null) return BadRequest("Aluno não encontrado");
      _context.Remove(aluno);
      _context.SaveChanges();
      return Ok();
    }
  }
}