using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SQLiteDemo;

namespace SQLiteDemo.MVVM.Models;

public class Student
{
    [PrimaryKey , AutoIncrement]
    public int ID { get ; set ;}
    
    [Column("student_id")]
    public string StudentId { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("group_no")]
    public int GroupNo { get; set; }

    [Column("avatar") , MaxLength(200)]
    public string Avatar { get; set; }

}

internal class AutoIncrementAttribute : Attribute
{
}

internal class PrimaryKeyAttribute : Attribute
{
}