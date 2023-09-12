namespace GraphQLSample.API.Entities;

public class Seller
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string? Country { get; set; }
    public string? Contact { get; set; }

    public IEnumerable<Vehicle> Vehicles { get; set; } = Enumerable.Empty<Vehicle>();
}
