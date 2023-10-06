using GraphQLSample.API.Entities;

namespace GraphQLSample.API.Interface;

public interface ISellerRepository
{
    Task<IEnumerable<Seller>> GetSellers();
}
