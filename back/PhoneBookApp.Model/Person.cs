namespace PhoneBookApp.Model;

public class Person
{
    public int Id {get; set;}
    public required string LastName {get; set;}
    public required string FirstName {get; set;}
    public bool IsDeleted { get; set; } = false;
}