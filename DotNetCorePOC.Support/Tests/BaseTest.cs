using System;
using System.Linq;
using System.Reflection;
using Autofac;
using DotNetCorePOC.Support.IoC;

namespace DotNetCorePOC.Support.Tests
{
    public abstract class BaseTest
    {
        protected IContainer Container { get; private set; }

        protected BaseTest()
        {
            var builder = new ContainerBuilder();

            var dependencies = GetType().GetTypeInfo()
                                        .Assembly.GetTypes()
                                        .Where(x => x.GetTypeInfo().IsClass &&
                                               !x.GetTypeInfo().IsAbstract &&
                                               x.GetTypeInfo().GetCustomAttribute(typeof(DependencyAttribute)) != null);

            builder.RegisterTypes(dependencies.ToArray());

            Container = builder.Build(); 
        }
    }
}
