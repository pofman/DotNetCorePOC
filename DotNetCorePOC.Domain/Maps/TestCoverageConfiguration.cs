using System;
using DotNetCorePOC.Support.Storage;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCorePOC.Domain.Maps
{
    public class TestCoverageConfiguration : BaseEntityConfiguration<TestCoverage>
    {
        public TestCoverageConfiguration()
        {
        }

        public override void Map(EntityTypeBuilder<TestCoverage> entity)
        {
            entity.HasMany(x => x.Packages).WithOne(x => x.Coverage)
                  .IsRequired();
        }
    }
}
