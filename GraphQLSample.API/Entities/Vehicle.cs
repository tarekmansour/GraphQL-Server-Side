namespace GraphQLSample.API.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Vin { get; set; }
    public string TransimissionType { get; set; }
    public string ModelYear { get; set; }
    public DateTime FirstRegistrationDate { get; set; }
    public string MileAge { get; set; }
    public string? Color { get; set; }

    public int SellerId { get; set; }
    public Seller Seller { get; set; }
}
