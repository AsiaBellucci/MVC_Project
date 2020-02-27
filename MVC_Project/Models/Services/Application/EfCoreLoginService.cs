using MVC_Project.Models.Entities;
using MVC_Project.Models.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project.Models.Services.Application
{
    public class EfCoreLoginService
    {
        private readonly MyCourseDbContext dbContext;
        public EfCoreLoginService(MyCourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool DoLogin(string username, string pw)
        {
            

            return true;
        }
    }
}
