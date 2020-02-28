using MVC_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Models.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }

        internal static UserViewModel FromEntity(Login user)
        {
            return new UserViewModel
            {
                Name = user.Username,
                Password = user.Password
            };
        }
    }
}
