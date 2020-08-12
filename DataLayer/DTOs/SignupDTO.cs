using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTOs
{
    public class SignupDTO
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }

    }
}
