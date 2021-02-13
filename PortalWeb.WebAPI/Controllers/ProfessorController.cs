using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalWeb.WebAPI.Data;
using PortalWeb.WebAPI.Dtos;
using PortalWeb.WebAPI.Models;

namespace PortalWeb.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfessorController : ControllerBase
  {
    public readonly IRepository _repo;
    public readonly IMapper _mapper;

    public ProfessorController(IRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
    }
    [HttpGet]
    public IActionResult Get()
    {
      var professores = _repo.GetAllProfessores(true);
      return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
    }

    [HttpGet("getRegister")]
    public IActionResult GetRegister()
    {
      return Ok(new ProfessorRegistrarDto());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      var professor = _repo.GetProfessorById(id, false);
      if (professor == null) return BadRequest("O professor não foi encontrado.");

      var professorDto = _mapper.Map<AlunoDto>(professor);
      return Ok(professorDto);
    }
    // [HttpGet("ByName")]
    // public IActionResult GetByName(string Nome)
    // {
    //   var Professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(Nome));
    //   if (Professor == null) return BadRequest("O professor não foi encontrado.");
    //   return Ok(Professor);
    // }
    [HttpPost()]
    public IActionResult Post(ProfessorRegistrarDto model)
    {
      var professor = _mapper.Map<Professor>(model);

      _repo.Add(professor);
      if (_repo.SaveChanges())
      {
        return Created($"/api/ professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
      }
      return BadRequest("Professor não cadastrado");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, ProfessorRegistrarDto model)
    {
      var professor = _repo.GetProfessorById(id, false);
      if (professor == null) return BadRequest("Professor não encontrado");

      _mapper.Map(model, professor);
      _repo.Update(professor);
      if (_repo.SaveChanges())
      {
        return Created($"/api/ professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
      }
      return BadRequest("Professor não atualizado");
    }

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, ProfessorRegistrarDto model)
    {
      var professor = _repo.GetProfessorById(id, false);
      if (professor == null) return BadRequest("Professor não encontrado");

      _mapper.Map(model, professor);
      _repo.Update(professor);
      if (_repo.SaveChanges())
      {
        return Created($"/api/ professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
      }
      return BadRequest("Professor não atualizado");
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var professor = _repo.GetProfessorById(id, false);
      if (professor == null) return BadRequest("Professor não encontrado");

      _repo.Delete(professor);
      if (_repo.SaveChanges())
      {
        return Ok("Professor deletado.");
      }
      return BadRequest("Professor não deletado.");
    }
  }
}