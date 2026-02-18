using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserLogin.Models.Api;
using UserLogin.Services;

namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly DbService _dbService;

        public CrudController(DbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public async Task<IActionResult> AddInfo(UserDataModel us)
        {
            try {
                var result = await _dbService.AddInfoToDb(us);
                return Ok(result);
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
