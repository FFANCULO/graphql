using System.Collections.Generic;

namespace DotNetGraphQL.Common.Models
{
    public abstract class ImagesModel
    {
        //protected ImagesModel(string avatarUrl, string websiteUrl, string title, IEnumerable<string> imagesList) =>
        //    (AvatarUrl, WebsiteUrl, Title, ImagesList) = (avatarUrl, websiteUrl, title, imagesList.ToArray());


        //id 
        //lineOfBusiness 
        //jurisdiction
        //effectiveDate
        //releasedDateversion 
        //rateTables[RateTables]


        protected ImagesModel(string id, string lineOfBusiness, string jurisdiction, IReadOnlyList<string> rateTables)
        {
            Id = id;
            LineOfBusiness = lineOfBusiness;
            Jurisdiction = jurisdiction;
            RateTables = rateTables;
        }

        public string Id { get; }
        public string LineOfBusiness { get; }
        public string Jurisdiction { get; }
        public IReadOnlyList<string> RateTables { get; }
    }
}
