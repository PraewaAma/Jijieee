using System;
using SQLite;
using SQLiteDemo.MVVM.Models;

namespace SQLiteDemo.Repositories;

public class CarRepository
{
    SQLiteConnection connection;
    public string StatusMessage;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public CarRepository()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        connection.CreateTable<Cars>();
    }
    public void AddOrUpdate(Cars car)
    {
        int result = 0;
        try
        {
            if (car.ID != 0)
            {
                result = connection.Update(car);
                StatusMessage = $"{result} row(s) updated";
            }
            else
            {
                result = connection.Insert(car);
                StatusMessage = $"{result} row(s) added";
            }

        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public List<Cars> GetAll()
    {
        try
        {
            return connection.Table<Cars>().ToList();
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public Cars Get(int id)
    {
        try
        {
            return connection.Table<Cars>().FirstOrDefault(x => x.ID == id);
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public void Delete (int id)
    {
        try
        {
           var car = Get(id);
           connection.Delete(car);
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
    }
}