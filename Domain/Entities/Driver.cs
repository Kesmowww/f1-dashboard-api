namespace Domain.Entities;

public class Driver
{
    public string DriverId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public int Position { get; set; }
    public double Points { get; set; }
    public int Wins { get; set; }
    public string Team { get; set; } = string.Empty;
}