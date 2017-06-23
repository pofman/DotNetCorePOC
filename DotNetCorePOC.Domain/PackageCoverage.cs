using DotNetCorePOC.Support.Domain;

namespace DotNetCorePOC.Domain
{
    public class PackageCoverage : Entity
    {
        public TestCoverage Coverage { get; set; }
    }
}