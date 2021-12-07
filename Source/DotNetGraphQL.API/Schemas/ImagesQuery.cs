using System;
using System.Collections.Generic;
using System.Linq;
using DotNetGraphQL.Common.Models;
using GraphQL;
using GraphQL.Types;

namespace DotNetGraphQL.API.Schemas
{
    public class ImagesQuery : ObjectGraphType
    {
        public ImagesQuery()
        {
            Name = "Query";

            Field<ListGraphType<DogImagesGraphType>>("dogs", "Query for dogs",
                resolve: context => DogImagesData.DogImages);

            var queryArgument = new QueryArgument<NonNullGraphType<StringGraphType>>
            {
                Name = "name",
                Description = "Dog Name"
            };

            Field<DogImagesGraphType>("dog", "Query a specific dog",
                new QueryArguments(queryArgument),
                context =>
                {
                    DogImagesModel dogImagesModel = DogImagesData.DogImages.Single(x =>
                        x.Title.Equals(context.GetArgument<string>("name"), StringComparison.OrdinalIgnoreCase));
                    return dogImagesModel;
                });

            var queryArguments = new QueryArguments(
                new QueryArgument<StringGraphType>
                {
                    Name = "coatColor",
                    Description = "Dog Coat Color"
                },
                new QueryArgument<StringGraphType>
                {
                    Name = "breed",
                    Description = "Dog Breed"
                });

            Field<ListGraphType<DogImagesGraphType>>("dogsByCoatColorOrBreed", "Query dogs by coat color or breed",
                queryArguments,
                context => GetDogImagesByNameOrBreed(context.GetArgument<string>("coatColor"),
                    context.GetArgument<string>("breed")));
        }

        static IEnumerable<DogImagesModel> GetDogImagesByNameOrBreed(string? coatColor, string? breed)
        {
            switch (!string.IsNullOrWhiteSpace(coatColor), !string.IsNullOrWhiteSpace(breed))
            {
                case (true, true):
                    return DogImagesData.DogImages.Where(x =>
                        x.CoatColor.Equals(coatColor, StringComparison.OrdinalIgnoreCase) &&
                        x.Breed.Equals(breed, StringComparison.OrdinalIgnoreCase));
                case (true, false):
                    return DogImagesData.DogImages.Where(x =>
                        x.CoatColor.Equals(coatColor, StringComparison.OrdinalIgnoreCase));
                case (false, true):
                    return DogImagesData.DogImages.Where(x =>
                        x.Breed.Equals(breed, StringComparison.OrdinalIgnoreCase));
                case (false, false):
                    throw new ArgumentException(
                        $"{nameof(DogImagesModel.CoatColor)} and {nameof(DogImagesModel.Breed)} cannot both be null");
            }
        }
    }
}
