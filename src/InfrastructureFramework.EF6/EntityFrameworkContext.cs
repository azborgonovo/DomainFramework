using CommonUnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureFramework.EF6
{
    public abstract class EntityFrameworkContext : DbContext, IUnitOfWorkFactory, IDbSetFactory
    {
        ITenant tenant;

        public EntityFrameworkContext() : this(null)
        {
        }

        public EntityFrameworkContext(ITenant tenant) : base(tenant == null ? "DefaultConnection" : tenant.ConnectionString)
        {
            this.tenant = tenant;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (tenant != null && !string.IsNullOrEmpty(tenant.Schema))
            {
                // Configure default schema
                modelBuilder.HasDefaultSchema(tenant.Schema);
            }
        }

        public IDbSet<T> CreateDbSet<T>() where T : class
        {
            return Set<T>();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return CreateUnitOfWork(false);
        }
        
        public IUnitOfWork CreateUnitOfWork(bool beginDatabaseTransaction)
        {
            return new EntityFrameworkUnitOfWork(this, beginDatabaseTransaction);
        }
    }
}
