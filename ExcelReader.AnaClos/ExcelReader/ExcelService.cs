using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OfficeOpenXml.ExcelErrorValue;

namespace ExcelReader;
    class ExcelService
    {
        
    public ExcelService()
    {
        

    }
    public void ReadExcel()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
        FileInfo newFile = new FileInfo($@"{projectDirectory}\data\Datos.xlsx");
        if (newFile.Exists)
        {
            newFile.Delete();
            newFile = new FileInfo($@"{projectDirectory}\data\Datos.xlsx");
        }
        //string path =Path.Combine(projectDirectory, "data\texto.txt");
        //string fileText = File.ReadAllText(path);
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(newFile))
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Inventory");
            workSheet.Cells[1, 1].Value = "ID";
            workSheet.Cells[1, 2].Value = "Product";
            workSheet.Cells[1, 3].Value = "Quantity";
            workSheet.Cells[1, 4].Value = "Price";
            //workSheet.Cells[1, 5].Value = "Value";

            workSheet.Cells[2, 1].Value = 12001;
            workSheet.Cells[2, 2].Value = "Nails"; 
            workSheet.Cells[2, 3].Value = 37;
            workSheet.Cells[2, 4].Value = 3.99;


            //worksheet.Cells[&quot; A3 & quot;].Value = &quot; 12002 & quot; ;
            //worksheet.Cells[&quot; B3 & quot;].Value = &quot; Hammer & quot; ;
            //worksheet.Cells[&quot; C3 & quot;].Value = 5;
            //worksheet.Cells[&quot; D3 & quot;].Value = 12.10;

            //worksheet.Cells[&quot; A4 & quot;].Value = &quot; 12003 & quot; ;
            //worksheet.Cells[&quot; B4 & quot;].Value = &quot; Saw & quot; ;
            //worksheet.Cells[&quot; C4 & quot;].Value = 12;
            //worksheet.Cells[&quot; D4 & quot;].Value = 15.37;
            package.Save();
        }
    }    
}
