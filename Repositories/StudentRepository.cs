using System;
using SQLite;
using SQLiteDemo.MVVM.Models;

namespace SQLiteDemo.Repositories;
public class StudentRepository
{
    SQLiteConnection connection;
    public string StatusMessage;
    public StudentRepository()
    {
        connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        connection.CreateTable<Student>();
    }

    public void AddOrUpdate(Student student)
    {
        int result = 0;
        try
        {
            if (student.ID != 0)
            {
                result = connection.Update(student);
                StatusMessage = $"{result} row(s) updated";
            }
            else
            {
                result = connection.Insert(student);
                StatusMessage = $"{result} row(s) added";
            }

        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public List<Student> GetAll()
    {
        try
        {
            return connection.Table<Student>().ToList();
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public Student Get(int id)
    {
        try
        {
            return connection.Table<Student>().FirstOrDefault(x => x.ID == id);
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
           var student = Get(id);
           connection.Delete(student);
        }
        catch (Exception ex)
        {
            while (ex.InnerException != null) ex = ex.InnerException;
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    internal void AddOrUpdate(Cars? currentCar)
    {
        throw new NotImplementedException();
    }

    public static implicit operator StudentRepository(CarRepository v)
    {
        throw new NotImplementedException();
    }
}