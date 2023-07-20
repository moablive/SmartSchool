using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController(){}
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Alunos: Marta, Paula, Lucas");
        }
    }
}
