using System.ComponentModel.DataAnnotations;
using System.Net;

namespace UserLogin.Models.Api
{
    public class UserDataModel
    {
        [Required]
        public string first_name {get; set;}
        public string last_name { get; set; }
        public string user_email { get; set; }
        public string phone_no { get; set; }
        public Address user_address { get; set; }

    }

    public class Address {
        public string line_1 { get; set; }
        public string line_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pincode { get; set; }
        public string landmark { get; set; }
    }

 
}
