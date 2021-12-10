using System;
using System.Collections.Generic;

namespace DotNetGraphQL.Common.Models
{
    public class RateBookModel : ImagesModel
    {
        //public DogImagesModel(string avatarUrl, string websiteUrl, string title, IEnumerable<string> imagesList,
        //    string breed, string coatColor, DateTime? birthDate = null)
        //    : base(avatarUrl, websiteUrl, title, imagesList)
        //{
        //    (Breed, BirthDate, CoatColor) = (breed, birthDate, coatColor);
        //}


        public RateBookModel(string id, string lineOfBusiness, string jurisdiction, IReadOnlyList<string> rateTables, string title) : base(id, lineOfBusiness, jurisdiction, rateTables)
        {
            Title = title;
        }

        public String Title { get; set; }
    }
}