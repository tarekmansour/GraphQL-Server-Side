using GraphQL.Types;
using GraphQLSample.API.Interface;

namespace GraphQLSample.API.GraphQL;

public class AppQuery : ObjectGraphType
{
    public AppQuery()
    {
        Field<ListGraphType<SellerType>>(name: "sellers")
            .Description("Get the list of selelrs")
            .ResolveAsync(async context =>
            {
                var repository = context.RequestServices!.GetRequiredService<ISellerRepository>();
                return await repository.GetSellers();
            });
    }
}
