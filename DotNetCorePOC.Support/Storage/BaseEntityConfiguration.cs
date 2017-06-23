using System;
using DotNetCorePOC.Support.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetCorePOC.Support.Storage
{
	public static class ModelBuilderExtensions
	{
		public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder,
		  EntityTypeConfiguration<TEntity> entityConfiguration) where TEntity : class
		{
			modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
		}
	}

	public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
	{
        internal abstract void Configure(EntityTypeBuilder<TEntity> entity);
		public abstract void Map(EntityTypeBuilder<TEntity> entity);
	}

    public abstract class BaseEntityConfiguration<T> : EntityTypeConfiguration<T> where T : Entity
    {
        public BaseEntityConfiguration()
        {
        }


        internal override void Configure(EntityTypeBuilder<T> entity)
        {
			entity.Property(x => x.Id).IsRequired();
			entity.HasKey(x => x.Id);
            Map(entity);
        }
    }
}
