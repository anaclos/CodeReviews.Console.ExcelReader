using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelReader.Models;
using ExcelReader.Data;

namespace ExcelReader.Services
{

    public class DataBaseService
    {
        ExcelDbContext _dbContext;
        public DataBaseService(ExcelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteAndCreate()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            //    context.Database.EnsureDeleted();

            //    // Crea la base de datos y las tablas
            //    context.Database.EnsureCreated();

        }
        public void WriteInventory(List<Inventory> inventoryList)
        {
            _dbContext.Inventories.AddRange(inventoryList);

            _dbContext.SaveChanges();
        }
    }
}
