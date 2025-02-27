using BulkyWeb.Infrastructure.Data;
using BulkyWeb.Infrastructure.Repositories;
using BulkyWeb.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IProductRepository Product { get; set; }
        public ICategoryRepository Category { get; set; }
        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
            Product = new ProductRepository(dbContext);
            Category = new CategoryRepository(dbContext);
        }
        public async Task SaveAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    throw new Exception($"Inner exception : {ex.InnerException.Message}");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
