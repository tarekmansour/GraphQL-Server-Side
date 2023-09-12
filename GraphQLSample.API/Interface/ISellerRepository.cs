using GraphQLSample.API.Entities;

namespace GraphQLSample.API.Interface;

public interface ISellerRepository
{
    IEnumerable<Seller> GetAll();
}
