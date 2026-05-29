namespace PhoneBookApp.Model;

public class Phone
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public required string Number { get; set; }
}