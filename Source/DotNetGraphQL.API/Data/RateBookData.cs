using System;
using System.Collections.Generic;
using DotNetGraphQL.Common.Models;

namespace DotNetGraphQL.API.Data
{
    public static class RateBookData
    {
        private static readonly Lazy<IEnumerable<RateBookModel>> RateBookHolder = new(CreateRateBookList);

        public static IEnumerable<RateBookModel> Data => RateBookHolder.Value;

        private static IEnumerable<RateBookModel> CreateRateBookList()
        {
            yield return GenerateRB1Model();
            yield return GenerateRB2Model();
            yield return GenerateRB3Model();
            yield return GenerateRB4Model();
            yield return GenerateRB5Model();
            yield return GenerateRB6Model();
            yield return GenerateRB7Model();
            yield return GenerateRB8Model();
            yield return GenerateRB9Model();
        }

        private static RateBookModel GenerateRB1Model()
        {
            return new RateBookModel(Guid.NewGuid().ToString(), "LOB1", "AZ", new[] { "one" }, "unknown");
        }

        private static RateBookModel GenerateRB2Model()
        {
            return new RateBookModel(Guid.NewGuid().ToString(), "LOB2", "AZ", new[] { "one" }, "unknown");
        }

        private static RateBookModel GenerateRB3Model()
        {
            return new RateBookModel(Guid.NewGuid().ToString(), "LOB3", "AZ", new[] { "one" }, "unknown");
        }

        private static RateBookModel GenerateRB4Model()
        {
            return new RateBookModel(Guid.NewGuid().ToString(), "LOB4", "AZ", new[] { "one" }, "unknown");
        }

        private static RateBookModel GenerateRB5Model()
        {
            return new RateBookModel(Guid.NewGuid().ToString(), "LOB5", "AZ", new[] { "one" }, "unknown");
        }

        private static RateBookModel GenerateRB7Model()
        {
            return new RateBookModel(Guid.NewGuid().ToString(), "LOB6", "AZ", new[] { "one" }, "unknown");
        }

        private static RateBookModel GenerateRB6Model()
        {
            return new RateBookModel(Guid.NewGuid().ToString(), "LOB7", "AZ", new[] { "one" }, "unknown");
        }

        private static RateBookModel GenerateRB8Model()
        {
            return new RateBookModel(Guid.NewGuid().ToString(), "LOB8", "AZ", new[] { "one" }, "unknown");
        }

        private static RateBookModel GenerateRB9Model()
        {
            return new RateBookModel(Guid.NewGuid().ToString(), "LOB9", "AZ", new[] { "one" }, "unknown");
        }
    }
}