using BulkyWeb.Application.CustomLib.Files.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib.Files.Services
{
    public class PDFFileService : IPDFFileService
    {
        public PDFFileService()
        {

        }
        public async Task<byte[]> ExportAsync<T>(IEnumerable<T> request) where T : class
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    //Document document = new Document();
                    //PdfWriter.GetInstance(document, stream);
                    //document.Open();

                    //foreach (var row in request.Data)
                    //{
                    //    document.Add(new Paragraph(string.Join(" | ", row)));
                    //}

                    //document.Close();
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
