using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace UserLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserAccountController : ControllerBase
    {
        //public readonly AppDbContext _dbContext;
        //public UserAccountController(AppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
          
        //}

        //[HttpGet]
        //public async Task<List<UserAccount>> Get()
        //{
        //    return await _dbContext.UserAccounts.ToListAsync();
        //}
        //[HttpGet("{id}")]
        //public async Task<List<UserAccount?>> GetById(int id) { 
        //    return await _dbContext.UserAccounts.FirstOrDefaultAsync(x => x.Id == id);

        //}
    }
}
