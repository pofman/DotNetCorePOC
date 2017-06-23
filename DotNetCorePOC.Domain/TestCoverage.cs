using System.Collections.Generic;
using DotNetCorePOC.Support.Domain;

namespace DotNetCorePOC.Domain
{
    public class TestCoverage : Entity
    {
        public IEnumerable<PackageCoverage> Packages { get; protected set; }

        public TestCoverage()
            : base()
        {
            Packages = new List<PackageCoverage>();
        }
    }
}
    