using GraphQLSample.API.Entities;

namespace GraphQLSample.API.Interface;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAllVehiclesBySeller(int sellerId);
}
