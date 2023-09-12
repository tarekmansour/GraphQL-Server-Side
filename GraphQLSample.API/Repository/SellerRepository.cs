using GraphQLSample.API.Entities.Context;
using GraphQLSample.API.Interface;

namespace GraphQLSample.API.Repository;

public class SellerRepository: ISellerRepository
{
    private readonly ApplicationContext _context;

    public SellerRepository(ApplicationContext context)
    {
        _context = context;
    }
}
