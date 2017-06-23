using System;
using System.Linq;
using System.Reflection;
using DotNetCorePOC.Support.Configuration;
using DotNetCorePOC.Support.Extensions;
using DotNetCorePOC.Support.IoC;
using Microsoft.EntityFrameworkCore;

namespace DotNetCorePOC.Support.Storage
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        [Dependency]
        public IConfiguration Configuration{ private get; set; }

        public DbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var baseMapType = typeof(EntityTypeConfiguration<>);

            Configuration.Assemblies.Foreach(x => {
                x.GetTypes().Where(t => 
                        t.GetTypeInfo().BaseType != null && !t.GetTypeInfo().IsAbstract &&
                        t.GetTypeInfo().BaseType.GetGenericTypeDefinition().Equals(baseMapType))
                 .Foreach(t =>
                 {
                     dynamic instance = Activator.CreateInstance(t);
                     ModelBuilderExtensions.AddConfiguration(modelBuilder, instance);
                     //extension method signature does not support dynamic object!
                     //modelBuilder.AddConfiguration(instance);
                 });
            });
        }
    }
}
