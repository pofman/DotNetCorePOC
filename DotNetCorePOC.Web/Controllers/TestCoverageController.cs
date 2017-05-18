using System;
using System.Collections.Generic;
using DotNetCorePOC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DotNetCorePOC.Support.Web;

namespace DotNetCorePOC.Web.Controllers
{
    [Route("api/test/coverage")]
    public class TestCoverageController : BaseAPIController
    {
        [HttpGet]
        public IEnumerable<TestCoverage> GetCoverages()
        {
            return new List<TestCoverage>();
        }

        [HttpGet("id")]
        public TestCoverage GetCoverage(Guid id)
        {
            return new TestCoverage();
        }
    }
}