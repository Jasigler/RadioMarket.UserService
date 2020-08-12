using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTOs
{
    public class NewUserDTO
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password_hash { get; set; }
    }
}
