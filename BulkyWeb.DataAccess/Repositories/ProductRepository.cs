using BulkyWeb.Infrastructure.Data;
using BulkyWeb.Domain.Models;
using BulkyWeb.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext) 
        {
            
        }
    }
}
