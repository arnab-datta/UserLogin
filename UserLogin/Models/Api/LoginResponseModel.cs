namespace UserLogin.Models.Api
{
    public class LoginResponseModel
    {
        public String? UserName { get; set; }
        public String? AccessToken { get; set; }
        public int ExpiersIn { get; set; }
    }
}
