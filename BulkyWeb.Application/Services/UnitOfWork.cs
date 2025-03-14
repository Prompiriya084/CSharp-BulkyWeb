using BulkyWeb.Infrastructure.Data;
using BulkyWeb.Infrastructure.Repositories;
using BulkyWeb.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
        public IUserAuthenRepository UserAuthen { get; set; }
        public IUserInfoRepository UserInfo { get; set; }
        public IUserAuthorizeRepository UserAuthorize { get; set; }
        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
            Product = new ProductRepository(dbContext);
            Category = new CategoryRepository(dbContext);
            UserAuthen = new UserAthenRepository(dbContext);
            UserInfo = new UserInfoRepository(dbContext);
            UserAuthorize = new UserAuthorizeRepository(dbContext);
        }
        public async Task<IDbContextTransaction> BeginTransaction()
        {
            try
            {
               return await _dbContext.Database.BeginTransactionAsync();
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
