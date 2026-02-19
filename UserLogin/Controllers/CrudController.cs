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
        private readonly FunctionalService _functionalService;

        public CrudController(DbService dbService, FunctionalService functionalService)
        {
            _dbService = dbService;
            _functionalService = functionalService;
        }

        [HttpPost]
        public async Task<IActionResult> AddInfo(UserDataModel us)
        {
            try {
                var result = await _dbService.AddInfoToDb(us);
                return Ok(_functionalService.ConvertDataTable(result));

            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditUserBasicInfo(UserDataModel us)
        {
            try
            {
                var result = await _dbService.AddInfoToDb(us);
                return Ok(_functionalService.ConvertDataTable(result));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
