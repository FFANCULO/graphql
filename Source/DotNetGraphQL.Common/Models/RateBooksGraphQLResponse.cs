using System.Collections.Generic;
using System.Linq;

namespace DotNetGraphQL.Common.Models
{
    public class RateBooksGraphQLResponse
    {
        public RateBooksGraphQLResponse(IEnumerable<RateBookModel> rateBookModels)
        {
            RateBooks = rateBookModels.ToList();
        }

        public IReadOnlyList<RateBookModel> RateBooks { get; }
    }
}
