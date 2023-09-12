using GraphQLSample.API.Entities.Context;
using GraphQLSample.API.Interface;

namespace GraphQLSample.API.Repository;

public class VehicleRepository: IVehicleRepository
{
    private readonly ApplicationContext _context;

    public VehicleRepository(ApplicationContext context)
	{
        _context = context;
    }
}
