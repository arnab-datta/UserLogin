using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserLogin.Models.Api;

namespace UserLogin.Services
{
    public class JwtService
    {
        //public readonly AppDbContext _dbContext;
        public readonly IConfiguration _configuration;

        //public JwtService(AppDbContext dbContext, IConfiguration configuration) {
        public JwtService(IConfiguration configuration)
        {
            //_dbContext = dbContext;
            _configuration = configuration;
        }

        //public async Task<LoginResponseModel?> Authenticate(LoginRequestModel request) {
        //    if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password)) { 
        //        return null;
        //    }
        //    var userAccount = await _dbContext.UserAccounts.FirstorDefaultAsync(x => x.userName == request.UserName);
        //    if(userAccount is null || )
        //}

        public async Task<LoginResponseModel?> Authenticate(LoginRequestModel request)
        {
            var issuer = _configuration["JwtConfig:Issuer"];
            var audience = _configuration["JwtConfig:Audience"];
            var key = _configuration["JwtConfig:Key"];
            var tokenValidityInMinutes = _configuration.GetValue<int>("JwtConfig:ExpirationMinutes");
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(tokenValidityInMinutes);
            var signingCreds = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, request.UserName)
                }),
                Expires = tokenExpiryTimeStamp,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCreds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return new LoginResponseModel
            {
                AccessToken = accessToken,
                UserName = request.UserName,
                ExpiersIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
            };
        }


    }
}
