using System.Collections.Generic;

namespace DotNetGraphQL.Common.Models.MRCPackage
{
    public abstract class RateBookBaseModel
    {
        //id
        //lineOfBusiness
        //jurisdiction
        //effectiveDate
        //version
        //rateTables
        //releasedDate


        protected RateBookBaseModel(string id, string lineOfBusiness, string jurisdiction, string effectiveDate,
            string releasedDate, string version, IReadOnlyList<string> rateTables)
        {
            this.id = id;
            this.lineOfBusiness = lineOfBusiness;
            this.jurisdiction = jurisdiction;
            this.effectiveDate = effectiveDate;
            this.releasedDate = releasedDate;
            this.version = version;
            this.rateTables = rateTables;
        }

        public string id { get; }
        public string lineOfBusiness { get; }
        public string jurisdiction { get; }
        public string effectiveDate { get; }
        public string releasedDate { get; }

        public string version { get; }
        public IReadOnlyList<string> rateTables { get; }
    }
}