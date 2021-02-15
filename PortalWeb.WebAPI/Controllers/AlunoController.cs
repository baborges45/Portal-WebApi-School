using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalWeb.WebAPI.Data;
using PortalWeb.WebAPI.Dtos;
using PortalWeb.WebAPI.Helpers;
using PortalWeb.WebAPI.Models;

namespace PortalWeb.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AlunoController : ControllerBase
  {

    public readonly IRepository _repo;
    public readonly IMapper _mapper;

    public AlunoController(IRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
    {
      var alunos = await _repo.GetAllAlunosAsync(pageParams, true);

      var alunosResult = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

      Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalCount, alunos.TotalPages);

      return Ok(alunosResult);
    }

    [HttpGet("getRegister")]
    public IActionResult GetRegister()
    {
      return Ok(new AlunoRegistrarDto());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var aluno = _repo.GetAlunoById(id, false);
      if (aluno == null) return BadRequest("O aluno não foi encontrado.");

      var alunoDto = _mapper.Map<AlunoDto>(aluno);
      return Ok(alunoDto);
    }
    // [HttpGet("ByName")]
    // public IActionResult GetByName(string Nome, string Sobrenome)
    // {
    //   var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(Nome)
    //   && a.Sobrenome.Contains(Sobrenome));
    //   if (aluno == null) return BadRequest("O aluno não foi encontrado.");
    //   return Ok(aluno);
    // }
    [HttpPost()]
    public IActionResult Post(AlunoRegistrarDto model)
    {
      var aluno = _mapper.Map<Aluno>(model);

      _repo.Add(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
      }
      return BadRequest("Aluno não cadastrado");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, AlunoRegistrarDto model)
    {
      var aluno = _repo.GetAlunoById(id);
      if (aluno == null) return BadRequest("Aluno não encontrado");

      _mapper.Map(model, aluno);
      _repo.Update(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
      }
      return BadRequest("Aluno não atualizado");
    }
    [HttpPatch("{id}")]
    public IActionResult Patch(int id, AlunoRegistrarDto model)
    {
      var aluno = _repo.GetAlunoById(id);
      if (aluno == null) return BadRequest("Aluno não encontrado");

      _mapper.Map(model, aluno);

      _repo.Update(aluno);
      if (_repo.SaveChanges())
      {
        return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
      }
      return BadRequest("Aluno não atualizado");
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var aluno = _repo.GetAlunoById(id);
      if (aluno == null) return BadRequest("Aluno não encontrado.");

      _repo.Delete(aluno);
      if (_repo.SaveChanges())
      {
        return Ok("Aluno deletado.");
      }
      return BadRequest("Aluno não deletado.");
    }
  }
}