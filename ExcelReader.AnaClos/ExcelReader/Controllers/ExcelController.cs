using ExcelReader.Services;
using ExcelReader.Models;

namespace ExcelReader.Controllers;

public class ExcelController
{
    ExcelService _excelService;
    DataBaseService _dataBaseService;
    string _excelFile;

    public ExcelController(ExcelService excelService, DataBaseService dataBaseService)
    {
        _excelService = excelService;
        _dataBaseService = dataBaseService;
    }

    public void WriteDatabaseFromExcel(bool write)
    {
        _excelFile = _excelService.GetExcelFile();
        Console.WriteLine("Reading file name.");

        if (write)
        {
            _excelService.WriteExcel(_excelFile);
            Console.WriteLine($"Creating new excel file: {_excelFile}");
        }

        var inventoryList = _excelService.ReadExcel(_excelFile);
        Console.WriteLine($"Reading Inventory from excel.");

        _dataBaseService.DeleteDatabase();
        Console.WriteLine($"Deleting database.");

        _dataBaseService.CreateDatabase();
        Console.WriteLine($"Creating database.");

        _dataBaseService.SaveInventory(inventoryList);
        Console.WriteLine($"Saving inventory to database.");

        inventoryList = _dataBaseService.GetInventories();
        Console.WriteLine($"Geting inventory from database.");
        ShowInventory(inventoryList);
    }

    private void ShowInventory(List<Inventory> listInventory)
    {
        foreach(var inventory in listInventory)
        {
            Console.WriteLine($"{inventory.Id}\t {inventory.Product}\t {inventory.Quantity}\t {inventory.Price}");
        }
    }
}