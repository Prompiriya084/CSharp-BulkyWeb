using BulkyWeb.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.Services
{
    public interface IUnitOfWork
    {
        IProductRepository Product {  get; }
        ICategoryRepository Category { get; }
        IUserAuthenRepository UserAuthen { get; }
        IUserInfoRepository UserInfo { get; }
        IUserAuthorizeRepository UserAuthorize { get; }
        Task SaveAsync();
    }
}
