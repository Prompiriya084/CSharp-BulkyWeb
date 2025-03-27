using BulkyWeb.Application.CustomLib.Files.Services.Interfaces;
using BulkyWeb.Application.CustomLib.Files.Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib.Interfaces
{
    public interface IFileLib
    {
        IFileUtility Utilities { get; }
        IExcelFileService Excel { get; }
        IPDFFileService PDF { get; }
    }   
}
