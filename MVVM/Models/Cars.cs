using System;
using SQLite;

namespace SQLiteDemo.MVVM.Models;

public class Cars
{
    [PrimaryKey , AutoIncrement]
    public int ID { get ; set ;}
    
    [Column("Models")]
    public string Model { get; set; }
    
    [Column("Colors")]
    public string Color { get; set; }

}
internal class AutoIncrementAttribute : Attribute
{
}

internal class PrimaryKeyAttribute : Attribute
{
}