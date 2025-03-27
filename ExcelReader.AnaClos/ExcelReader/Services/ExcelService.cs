using ExcelReader.Models;
using OfficeOpenXml;

namespace ExcelReader.Services;
public class ExcelService
{
    string _fileName;
    public ExcelService(string fileName)
    {
        _fileName = fileName;
    }

    public string GetExcelFile()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
        string excelFile = $@"{projectDirectory}\Data\{_fileName}";
        return excelFile;
    }

    public List<Inventory> ReadExcel(string excelFile)
    {
        List<Inventory> inventories = new List<Inventory>();
        FileInfo existingFile = new FileInfo(excelFile);
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (ExcelPackage package = new ExcelPackage(existingFile))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

            for (int row = 2; row < 5; row++)
            {
                var inventoryRow = new Inventory
                {
                    Id = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                    Product = (string)worksheet.Cells[row, 2].Value,
                    Quantity = Convert.ToInt32(worksheet.Cells[row, 3].Value),
                    Price = Convert.ToDouble(worksheet.Cells[row, 4].Value)
                };

                inventories.Add(inventoryRow);
            }
        }
        return inventories;
    }

    public void WriteExcel(string excelFile)
    {
        FileInfo newFile = new FileInfo(excelFile);
        if (File.Exists(newFile.FullName))
        {
            newFile.Delete();
            newFile = new FileInfo(excelFile);
        }

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(newFile))
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Inventory");
            workSheet.Cells[1, 1].Value = nameof(Inventory.Id);
            workSheet.Cells[1, 2].Value = nameof(Inventory.Product);
            workSheet.Cells[1, 3].Value = nameof(Inventory.Quantity);
            workSheet.Cells[1, 4].Value = nameof(Inventory.Price);

            workSheet.Cells[2, 1].Value = 12001;
            workSheet.Cells[2, 2].Value = "Nails";
            workSheet.Cells[2, 3].Value = 37;
            workSheet.Cells[2, 4].Style.Numberformat.Format = "0.00";
            workSheet.Cells[2, 4].Value = 3.99;

            workSheet.Cells[3, 1].Value = 12002;
            workSheet.Cells[3, 2].Value = "Hammer";
            workSheet.Cells[3, 3].Value = 5;
            workSheet.Cells[3, 4].Style.Numberformat.Format = "0.00";
            workSheet.Cells[3, 4].Value = 12.10;

            workSheet.Cells[4, 1].Value = 12003;
            workSheet.Cells[4, 2].Value = "Saw";
            workSheet.Cells[4, 3].Value = 12;
            workSheet.Cells[4, 4].Style.Numberformat.Format = "0.00";
            workSheet.Cells[4, 4].Value = 15.37;

            package.Save();
        }
    }
}
