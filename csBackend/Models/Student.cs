using System;
using System.ComponentModel.DataAnnotations.Schema;
[Table("students")]
public class Student
{
    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("first_name")] 
    public string FirstName { get; set; }

    [Column("last_name")] 
    public string LastName { get; set; }

    [Column("date_of_birth")] 
    public DateTime DateOfBirth { get; set; }
}