using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib.Files.Utility.Interfaces
{
    public interface IFileUtility
    {
        string GetFileName(string directoryPath);
        string GetFileNameWithExtension(string directoryPath);
        List<string> GetFileNameList(string directoryPath);
        void CreateDirectory(string directoryPath);
        void CopyFiles(string sourcePath, string directoryPath);
        //void Save(IFormFile file, string path, string filename);
        void DeleteFiles(string directoryPath);
        void DeleteDirectory(string directoryPath);
    }
}
