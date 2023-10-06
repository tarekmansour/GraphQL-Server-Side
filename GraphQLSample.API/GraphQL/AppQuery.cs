using GraphQL.Types;
using GraphQLSample.API.Interface;

namespace GraphQLSample.API.GraphQL;

public class AppQuery : ObjectGraphType
{
    public AppQuery()
    {
        // configure type
        Name = "Query";
        Description = "Queries on my app<Domain>";

        Field<ListGraphType<SellerType>>(name: "sellers")
            .Description("Get the list of sellers")
            .ResolveAsync(async context =>
            {
                var repository = context.RequestServices!.GetRequiredService<ISellerRepository>();
                return await repository.GetSellers();
            });
    }
}
