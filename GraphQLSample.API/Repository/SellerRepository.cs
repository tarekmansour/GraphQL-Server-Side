using GraphQLSample.API.Entities;
using GraphQLSample.API.Entities.Context;
using GraphQLSample.API.Interface;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.API.Repository;

public class SellerRepository : ISellerRepository
{
    private readonly ApplicationContext _context;

    public SellerRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Seller>> GetSellers()
        => await _context.Sellers
            .ToListAsync()
            .ConfigureAwait(false);
}
