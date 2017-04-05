using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lawfirm.Areas.Admin.Models.User
{
    public class UserModel
    {
        public UserModel()
        {
            Role = new List<SelectListItem>();
        }
        public int Id { get; set; } 
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IList<SelectListItem> Role { get; set; }
    }
}