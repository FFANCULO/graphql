using System;
using System.Collections.Generic;
using System.Linq;
using DotNetGraphQL.API.Data;
using DotNetGraphQL.API.GraphTypes;
using DotNetGraphQL.Common.Models;
using GraphQL;
using GraphQL.Types;

namespace DotNetGraphQL.API.Schemas
{
    public class MRCMainQuery : ObjectGraphType
    {
        public MRCMainQuery()
        {
            Name = "Query";

            Field<ListGraphType<RateBooksGraphType>>("RateBooks", "Query for RateBooks",
                resolve: context => RateBookData.Data);

            var queryArgument = new QueryArgument<NonNullGraphType<StringGraphType>>
            {
                Name = "name",
                Description = "Name of Book"
            };

            Field<RateBooksGraphType>("RateBook", "Query a specific RateBook",
                new QueryArguments(queryArgument),
                context =>
                {
                    RateBookModel rateBookModel = RateBookData.Data.Single(x =>
                    {
                        return Compare();

                        bool Compare()
                        {
                            return x.Title.Equals(context.GetArgument<string>("name"), 
                                StringComparison.OrdinalIgnoreCase);
                        }
                    });
                    return rateBookModel;
                });
/*
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

            Field<ListGraphType<RateBooksGraphType>>("dogsByCoatColorOrBreed", "Query dogs by coat color or breed",
                queryArguments,
                context => GetDogImagesByNameOrBreed(context.GetArgument<string>("coatColor"),
                    context.GetArgument<string>("breed")));
*/
        }

        private static IEnumerable<RateBookModel> GetDogImagesByNameOrBreed(string? coatColor, string? breed)
        {
            switch (!string.IsNullOrWhiteSpace(coatColor), !string.IsNullOrWhiteSpace(breed))
            {
                case (true, true):
                    return RateBookData.Data.Where(x =>
                        x.Id.Equals(coatColor, StringComparison.OrdinalIgnoreCase) &&
                        x.LineOfBusiness.Equals(breed, StringComparison.OrdinalIgnoreCase));
                case (true, false):
                    return RateBookData.Data.Where(x =>
                        x.Id.Equals(coatColor, StringComparison.OrdinalIgnoreCase));
                case (false, true):
                    return RateBookData.Data.Where(x =>
                        x.LineOfBusiness.Equals(breed, StringComparison.OrdinalIgnoreCase));
                case (false, false):
                    throw new ArgumentException(
                        $"{nameof(RateBookModel.Id)} and {nameof(RateBookModel.LineOfBusiness)} cannot both be null");
            }
        }
    }
}