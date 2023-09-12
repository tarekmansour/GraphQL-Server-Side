using GraphQL.Types;
using GraphQLSample.API.Interface;

namespace GraphQLSample.API.GraphQL;

public class AppQuery : ObjectGraphType
{
    public AppQuery(ISellerRepository sellerRepository)
    {
        Field<ListGraphType<SellerType>>(name: "sellers")
            .Resolve(resolve: _ => sellerRepository.GetAll());
    }
}
