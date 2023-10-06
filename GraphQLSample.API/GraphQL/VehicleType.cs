using GraphQL.Types;

using GraphQLSample.API.Entities;

namespace GraphQLSample.API.GraphQL
{
    public class VehicleType: ObjectGraphType<Vehicle>
    {
        public VehicleType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The vehicle Id");
            Field(x => x.Make).Description("The vehicle make");
            Field(x => x.Model).Description("The vehicle model");
            Field(x => x.Vin).Description("The vehicle vin number");
            Field(x => x.TransimissionType).Description("The vehicle transmission type");
            Field(x => x.ModelYear).Description("The vehicle model year");
            Field(x => x.FirstRegistrationDate).Description("The vehicle first registration date");
            Field(x => x.MileAge).Description("The vehicle mileage");
            Field(x => x.Color).Description("The vehicle color");
            Field(x => x.SellerId, type: typeof(IdGraphType)).Description("The sellerId property from seller object ");
        }
    }
}
