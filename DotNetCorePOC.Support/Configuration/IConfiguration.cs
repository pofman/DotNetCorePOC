using System;
using System.Reflection;

namespace DotNetCorePOC.Support.Configuration
{
    public interface IConfiguration
    {
        Assembly[] Assemblies { get; }
    }
}
