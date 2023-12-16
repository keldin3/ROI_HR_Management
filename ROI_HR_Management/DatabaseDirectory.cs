﻿// DatabaseService.cs
using SQLite;
using System.IO;

public class DatabaseService
{
    SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Employee.db");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Employee>().Wait();
    }

    // Clear or truncate the SQLite database
    public void ClearDatabase()
    {
        try
        {
            _database.DropTableAsync<Employee>();
            _database.CreateTableAsync<Employee>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error clearing database: {ex.Message}");
        }
    }

    #region C R U D Operations
    //C
    public async Task AddEmployeeAsync(Employee employee)
    {
        await _database.InsertAsync(employee);
    }

    //R
    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _database.Table<Employee>().ToListAsync(); 
    }

    //U
    public async Task UpdateEmployeeAsync(Employee employee)
    {
        await _database.UpdateAsync(employee);
    }

    //D
    public async Task DeleteEmployeeAsync(Employee employee)
    {
        await _database.DeleteAsync(employee);
    }
    #endregion

}
