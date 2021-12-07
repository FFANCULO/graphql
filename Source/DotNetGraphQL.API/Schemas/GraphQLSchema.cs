using GraphQL.Types;

namespace DotNetGraphQL.API.Schemas
{
    public class ImagesSchema : Schema
    {
        public ImagesSchema()
        {
            Query = new ImagesQuery();
        }
    }
}