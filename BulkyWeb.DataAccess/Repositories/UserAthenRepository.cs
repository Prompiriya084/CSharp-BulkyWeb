using BulkyWeb.Domain.Models;
using BulkyWeb.Infrastructure.Data;
using BulkyWeb.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Infrastructure.Repositories
{
    public class UserAthenRepository : GenericRepository<UserAuthen>, IUserAuthenRepository
    {
        public UserAthenRepository(DbContext dbContext) : base(dbContext) { }
    }
}
