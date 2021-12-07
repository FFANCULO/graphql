using DotNetGraphQL.API.GraphTypes;
using DotNetGraphQL.Common;
using DotNetGraphQL.Common.Models;
using GraphQL.Types;

namespace DotNetGraphQL.API
{
    class DogImagesGraphType : ImagesGraphType<DogImagesModel>
    {
        public DogImagesGraphType() : base("Dog")
        {
            Field(x => x.Breed, false);
            Field<DateTimeGraphType>("birthDate", resolve: x => x.Source?.BirthDate);
            Field(x => x.CoatColor, false);

        }
    }
}
