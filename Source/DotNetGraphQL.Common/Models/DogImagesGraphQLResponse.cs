﻿using System.Collections.Generic;
using System.Linq;

namespace DotNetGraphQL.Common
{
    public class DogImagesGraphQLResponse
    {
        public DogImagesGraphQLResponse(IEnumerable<DogImagesModel> dogs) => Dogs = dogs.ToList();

        public IReadOnlyList<DogImagesModel> Dogs { get; }
    }
}
