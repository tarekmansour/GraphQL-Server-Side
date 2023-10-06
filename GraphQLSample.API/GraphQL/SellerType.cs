using GraphQL.Types;
using GraphQLSample.API.Entities;
using GraphQLSample.API.Interface;

namespace GraphQLSample.API.GraphQL;

public class SellerType: ObjectGraphType<Seller>
{
    public SellerType()
    {
        Field(x => x.Id, type: typeof(IdGraphType)).Description("The seller Id");
        Field(x => x.Name).Description("The seller name");
        Field(x => x.Address).Description("The seller address");
        Field(x => x.Country).Description("The seller country");
        Field(x => x.Contact).Description("The seller contact");
        Field<ListGraphType<VehicleType>>(name: "vehicles")
            .Description("Get the list of seller's vehicles")
            .ResolveAsync(async context =>
            {
                var repository = context.RequestServices!.GetRequiredService<IVehicleRepository>();
                return await repository.GetAllVehiclesBySeller(context.Source.Id);
            });
    }
}
