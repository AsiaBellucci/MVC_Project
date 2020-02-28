using MVC_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Models.Services.Interfaces
{
    public interface IUserService
    {
        public bool DoLogin(string username, string pw);
    }
}
