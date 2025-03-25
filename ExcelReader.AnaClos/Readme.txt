# Excel Service

## Description
This program allows you to read an Excel File and save data to a Database.

## Database
Windows credentials were used.

## Configuration
The Excel file must be saved at the data directory. 
You can modify in appsetting.json:
- the Excel name file
- the ConnectionString and adapt it to your SQLServer configuration.
If the write variable is set to true, the excel file is deleted and then created. 

## Limitations
The Excel titles must have the same names as the Inventory atributes. 
The number of rows is fixed.