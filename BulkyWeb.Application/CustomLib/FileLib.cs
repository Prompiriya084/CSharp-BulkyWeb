using BulkyWeb.Application.CustomLib.Files.Services;
using BulkyWeb.Application.CustomLib.Files.Services.Interfaces;
using BulkyWeb.Application.CustomLib.Files.Utility;
using BulkyWeb.Application.CustomLib.Files.Utility.Interfaces;
using BulkyWeb.Application.CustomLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib
{
    public class FileLib : IFileLib
    {
        public IFileUtility Utilities { get; set; }
        public IExcelFileService Excel { get; set; }
        public IPDFFileService PDF { get; set; }
        public FileLib()
        {
            Utilities = new FileUtility();
            Excel = new ExcelFileService();
            PDF = new PDFFileService();
        }
    }
}
