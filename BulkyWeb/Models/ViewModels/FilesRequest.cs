using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models.ViewModels
{
    public class FilesRequest
    {
        public IFormFile? File1 { get; set; }
        public IFormFile? File2 { get; set; }
        public IFormFile? File3 { get; set; }
    }
}
