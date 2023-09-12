using GraphQL.Types;

namespace GraphQLSample.API.GraphQL;

public class AppSchema: Schema
{
    public AppSchema(IServiceProvider provider)
        : base(provider)
    {
        Query = provider.GetRequiredService<AppQuery>();
    }
}
