using BulkyWeb.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IUserAuthenRepository UserAuthen { get; }
        IUserInfoRepository UserInfo { get; }
        IUserAuthorizeRepository UserAuthorize { get; }
        Task<IDbContextTransaction> BeginTransaction();
        Task SaveAsync();
    }
}
