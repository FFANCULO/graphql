using System.Collections.Generic;
using System.Linq;

namespace DotNetGraphQL.Common.Models
{
    public abstract class ImagesModel
    {
        protected ImagesModel(string avatarUrl, string websiteUrl, string title, IEnumerable<string> imagesList) =>
            (AvatarUrl, WebsiteUrl, Title, ImagesList) = (avatarUrl, websiteUrl, title, imagesList.ToArray());

        public string AvatarUrl { get; }
        public string WebsiteUrl { get; }
        public string Title { get; }
        public IReadOnlyList<string> ImagesList { get; }
    }
}
