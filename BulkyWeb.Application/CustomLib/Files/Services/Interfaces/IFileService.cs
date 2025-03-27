using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib.Files.Services.Interfaces
{
    public interface IFileService
    {
        Task<byte[]> ExportAsync<T>(IEnumerable<T> data) where T : class;
    }
}
