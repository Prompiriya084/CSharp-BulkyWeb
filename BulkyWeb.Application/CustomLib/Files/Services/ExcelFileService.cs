using BulkyWeb.Application.CustomLib.Files.Services.Interfaces;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib.Files.Services
{
    public class ExcelFileService : IExcelFileService
    {
        public ExcelFileService() { }
        public async Task<byte[]> ExportAsync<T>(IEnumerable<T> data) where T : class
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");
                    var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                    int rowNumber = 0;
                    foreach (var item in data)
                    {
                        for (int colNumber = 0; colNumber < properties.Length; colNumber++)
                        {
                            //var value = properties[colNumber].GetValue(item) != null ? properties[colNumber].GetValue(item).ToString() : "";
                            //worksheet.Cell(rowNumber, colNumber + 1).Value = value;

                            ////Row Border
                            //worksheet.Cell(rowNumber, colNumber + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                            if (colNumber != 9 && colNumber != 12)
                            {
                                int cellColNumber = (colNumber >= 10) ? colNumber - 1 : colNumber; //For hidden HDPrivilege column
                                var value = properties[colNumber].GetValue(item) != null ? properties[colNumber].GetValue(item).ToString() : "";
                                worksheet.Cell(rowNumber, cellColNumber + 1).Value = value;

                                //Row Border
                                //worksheet.Cell(rowNumber, cellColNumber + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                worksheet.Cell(rowNumber, cellColNumber + 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                                worksheet.Cell(rowNumber, cellColNumber + 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                            }

                        }
                        //if (item.Remain_Status == "1")
                        //{
                        //    worksheet.Row(rowNumber).Cells(1, 11).Style.Font.FontColor = XLColor.Red;
                        //}
                        //if (item.HdPrivilege == "KPO") worksheet.Row(rowNumber).Cells(1, 11).Style.Fill.BackgroundColor = XLColor.FromArgb(219, 228, 243);


                        //worksheet.Row(rowNumber).Cells(1, 9).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        //worksheet.Row(rowNumber).Cells(1, 9).Style.Border.SetOutsideBorderColor(XLColor.FromArgb(193, 193, 193));
                        rowNumber++;
                    }
                    //worksheet.Range(worksheet.Cell(rowNumber, 1), worksheet.Cell(rowNumber, 7)).Style.Border.TopBorder = XLBorderStyleValues.Thin;


                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
    }
}
