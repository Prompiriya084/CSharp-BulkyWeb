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
        public string GetFileName(string directoryPath)
        {
            try
            {
                //string destinationPath = @"C:\Users\Example\Documents\MyFile.pdf";
                //string fileName = Path.GetFileName(destinationPath);

                string[] filePathlist = Directory.GetFiles(directoryPath);
                if (filePathlist.Length > 0)
                {
                    return Path.GetFileNameWithoutExtension(filePathlist[0]);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string GetFileNameWithExtension(string directoryPath)
        {
            try
            {
                //string destinationPath = @"C:\Users\Example\Documents\MyFile.pdf";
                //string fileName = Path.GetFileName(destinationPath);

                string[] filePathlist = Directory.GetFiles(directoryPath);

                if (filePathlist.Length > 0)
                {
                    return Path.GetFileName(filePathlist[0]);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CopyFile(string sourcePath, string directoryPath)
        {
            try
            {
                // Check if the source file exists
                if (File.Exists(sourcePath))
                {
                    //// Ensure the destination directory exists
                    //if (!Directory.Exists(destinationPath))
                    //{
                    //    Directory.CreateDirectory(destinationPath);
                    //}

                    // Copy the file to the destination path
                    File.Copy(sourcePath, directoryPath, overwrite: true);
                    Console.WriteLine("File copied successfully!");
                }
                else
                {
                    Console.WriteLine("Source file does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public void Save(IFormFile file, string filename, string directoryPath)
        //{
        //    try
        //    {
        //        string filePath = Path.Combine(directoryPath, filename);
        //        if (!Directory.Exists(directoryPath))
        //        {
        //            Directory.CreateDirectory(directoryPath);
        //        }

        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            file.CopyTo(fileStream);
        //            fileStream.Position = 0;
        //        }

        //        //foreach (var item in Directory.GetFiles(tempPath))
        //        //{
        //        //    result = true;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        public void Delete(string directoryPath)
        {
            try
            {
                //var result = false;
                //var filePath = path + "\\" + filename;
                if (Directory.Exists(directoryPath))
                {
                    foreach (string item in Directory.GetFiles(directoryPath))
                    {
                        File.Delete(item);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<string> GetDirectory(string directoryPath)
        {
            try
            {
                // Validate the folder path
                if (string.IsNullOrEmpty(directoryPath))
                {
                    throw new ArgumentException("The folder path cannot be null or empty.", nameof(directoryPath));
                }

                var folderList = new List<string>();
                var folderPathList = Directory.GetDirectories(directoryPath);

                foreach (var folder in folderPathList)
                {
                    folderList.Add(Path.GetFileName(folder));
                }
                //if (Directory.Exists(directoryPath))
                //{
                //    var folderPathList = Directory.GetDirectories(directoryPath);

                //    foreach (var folder in folderPathList)
                //    {
                //        folderList.Add(Path.GetFileName(folder));
                //    }
                //}
                //else
                //{
                //    folderList.Add(Directory.Exists("\\\\192.168.10.17\\wwwroot\\SupplierApplication\\Document\\fileAttach\\2023\\202312\\A202312-0001").ToString());
                //}

                return folderList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CreateDirectory(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void DeleteDirectory(string directoryPath)
        {
            try
            {
                //var result = false;
                //var filePath = path + "\\" + filename;

                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
