using Microsoft.AspNetCore.Mvc;

namespace PortalWeb.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfessorController : ControllerBase
  {
    public ProfessorController() { }
    [HttpGet]
    public IActionResult Get()
    {
      return Ok("Professores: Zenilton, Magali, Julio, Lucila");
    }
  }
}