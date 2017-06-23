using System;
using DotNetCorePOC.Support.Domain;
using DotNetCorePOC.Support.Tests;
using Xunit;

namespace DotNetCorePOC.Domain.Tests.Support
{
    public class EntityTests : BaseTest
    {
        [Fact]
        public void CreatingANewEntity_ShouldHaveAValidGuid()
        {
            //Setup
            //Action
            var entity = new MockEntity();

            //Assert
            Assert.NotNull(entity.Id);
            Assert.NotEqual(Guid.Empty, entity.Id);
        }

        private class MockEntity : Entity
        {
            
        }
    }
}
