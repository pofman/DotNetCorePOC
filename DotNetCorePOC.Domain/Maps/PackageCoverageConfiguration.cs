using System;
using DotNetCorePOC.Support.Storage;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCorePOC.Domain.Maps
{
	public class PackageCoverageConfiguration : BaseEntityConfiguration<PackageCoverage>
	{
		public PackageCoverageConfiguration()
		{
		}

		public override void Map(EntityTypeBuilder<PackageCoverage> entity)
		{

		}
    }
}
