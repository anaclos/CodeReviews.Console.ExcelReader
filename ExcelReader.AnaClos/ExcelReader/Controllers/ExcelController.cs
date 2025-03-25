using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelReader.Services;

namespace ExcelReader.Controllers
{
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
            if(write)
            {
                _excelService.WriteExcel(_excelFile);
            }
            
            var inventoryList = _excelService.ReadExcel(_excelFile);
            _dataBaseService.DeleteAndCreate();
            _dataBaseService.WriteInventory(inventoryList);
        }
    }
}
