using GraphQLSample.API.Entities;
using GraphQLSample.API.Entities.Context;
using GraphQLSample.API.Interface;

using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.API.Repository;

public class VehicleRepository: IVehicleRepository
{
    private readonly ApplicationContext _context;

    public VehicleRepository(ApplicationContext context)
	{
        _context = context;
    }

    public async Task<IEnumerable<Vehicle>> GetAllVehiclesBySeller(int sellerId)
    {
        return await _context.Vehicles
            .Where(v => v.SellerId == sellerId)
            .ToListAsync();
    }
}
