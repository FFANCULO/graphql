using DotNetGraphQL.Common.Models;
using GraphQL.Types;

namespace DotNetGraphQL.API.GraphTypes
{
    abstract class ImagesGraphType<T> : ObjectGraphType<T> where T : ImagesModel
    {
        protected ImagesGraphType(string name)
        {
            Name = name;

            Field(x => x.Id, false);
            Field<ListGraphType<NonNullGraphType<StringGraphType>>>("imagesList", resolve: x => x.Source?.RateTables);
            Field(x => x.Jurisdiction, false);
            Field(x => x.LineOfBusiness, false);
            Field(x => x.RateTables, false);
        }
    }
}
