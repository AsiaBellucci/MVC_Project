using Microsoft.EntityFrameworkCore;
using MVC_Project.Models.Entities;
using MVC_Project.Models.Services.Infrastructure;
using MVC_Project.Models.Services.Interfaces;
using MVC_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Models.Services.Application
{
    public class EfCoreLoginService : IUserService
    {
        private readonly MyCourseDbContext dbContext;
        public EfCoreLoginService(MyCourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public  bool DoLogin(string username, string pw)
        {
            IQueryable<UserViewModel> queryLinq = dbContext.Login
                .AsNoTracking()
                .Where(user => user.Username == username && user.Password == pw)
                .Select(user => UserViewModel.FromEntity(user));

            bool viewModel =  queryLinq.Any();
            if (viewModel == true)
                return viewModel;
            else
                return false;
            
        }
    }
}
