using GraphQL.Types;
using GraphQLSample.API.Entities;

namespace GraphQLSample.API.GraphQL;

public class SellerType: ObjectGraphType<Seller>
{
    public SellerType()
    {
        Field(x => x.Id, type: typeof(IdGraphType)).Description("Seller Id");
        Field(x => x.Name).Description("Seller Name");
        Field(x => x.Address).Description("Seller Address");
        Field(x => x.Country).Description("Seller Country");
        Field(x => x.Contact).Description("Seller Contact");
    }
}
