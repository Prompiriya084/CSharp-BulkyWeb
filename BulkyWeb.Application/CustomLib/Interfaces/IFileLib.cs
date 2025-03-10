using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib.Interfaces
{
    public interface IFileLib
    {
        string GetFileName(string directoryPath);
        string GetFileNameWithExtension(string directoryPath);
        void CreateDirectory(string directoryPath);
        void CopyFile(string sourcePath, string directoryPath);
        //void Save(IFormFile file, string path, string filename);
        void Delete(string directoryPath);
        List<string> GetDirectory(string directoryPath);
        void DeleteDirectory(string directoryPath);
    }
}
