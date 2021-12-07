using System;
using System.Collections.Generic;
using System.Linq;
using DotNetGraphQL.Common.Models;
using GraphQL;
using GraphQL.Types;

namespace DotNetGraphQL.API.Schemas
{
    public class MRCQuery : ObjectGraphType
    {
        public MRCQuery()
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

        private static IEnumerable<DogImagesModel> GetDogImagesByNameOrBreed(string? coatColor, string? breed)
        {
            return (string.IsNullOrWhiteSpace(coatColor), string.IsNullOrWhiteSpace(breed)) switch
            {
                (true, true) => DogImagesData.DogImages.Where(x =>
                    x.CoatColor.Equals(coatColor, StringComparison.OrdinalIgnoreCase) &&
                    x.Breed.Equals(breed, StringComparison.OrdinalIgnoreCase)),
                (true, false) => DogImagesData.DogImages.Where(x =>
                    x.CoatColor.Equals(coatColor, StringComparison.OrdinalIgnoreCase)),
                (false, true) => DogImagesData.DogImages.Where(x =>
                    x.Breed.Equals(breed, StringComparison.OrdinalIgnoreCase)),
                (false, false) => throw new ArgumentException(
                    $"{nameof(DogImagesModel.CoatColor)} and {nameof(DogImagesModel.Breed)} cannot both be null")
            };
        }
    }
}