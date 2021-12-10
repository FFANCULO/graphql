using DotNetGraphQL.Common.Models;
using GraphQL.Types;

namespace DotNetGraphQL.API.GraphTypes
{
    class RateBooksGraphType : ImagesGraphType<RateBookModel>
    {
        public RateBooksGraphType() : base("RateBookX")
        {
            Field(x => x.Title, false);
            Field<DateTimeGraphType>("lineOfBusiness2", resolve: x => x.Source?.LineOfBusiness);
         //   Field(x => x.Id, false);

        }
    }
}
