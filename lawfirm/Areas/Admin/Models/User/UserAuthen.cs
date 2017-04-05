using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lawfirm.Areas.Admin.Models.User
{
    public class UserAuthen
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}