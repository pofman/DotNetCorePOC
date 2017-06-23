using System;
using DotNetCorePOC.Support.Tests;
using Xunit;

namespace DotNetCorePOC.Domain.Tests
{
    public class TestCoverageTests : BaseTest
    {
        [Fact]
        public void NewTestCoverage_ShouldHaveThePackagesCollectionNotNull()
        {
            //Action
            var coverage = new TestCoverage();

            //Assert
            Assert.NotNull(coverage.Packages);
        }

		[Fact]
		public void NewTestCoverage_ShouldHaveThePackagesCollectionEmpty()
		{
			//Action
			var coverage = new TestCoverage();

			//Assert
            Assert.Empty(coverage.Packages);
		}
    }
}
