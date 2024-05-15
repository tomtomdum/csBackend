using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("teachers")]
public class Teacher
{
    [Column("teacher_id")]
    public int TeacherId { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("date_of_birth")]
    public DateTime DateOfBirth { get; set; }
}
