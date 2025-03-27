using ExcelReader.Data;
using ExcelReader.Models;

namespace ExcelReader.Services;


public class DataBaseService
{
    ExcelDbContext _dbContext;
    public DataBaseService(ExcelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void DeleteDatabase()
    {
        _dbContext.Database.EnsureDeleted();
    }

    public void CreateDatabase()
    {
        _dbContext.Database.EnsureCreated();
    }

    public void SaveInventory(List<Inventory> inventoryList)
    {
        _dbContext.Inventories.AddRange(inventoryList);
        _dbContext.SaveChanges();
    }
    public List<Inventory> GetInventories()
    {
        List<Inventory> listInventory = _dbContext.Inventories.ToList();
        return listInventory;
    }
}