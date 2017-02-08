using System.Data.Entity;

namespace InfrastructureFramework.EF6
{
    public class EntityFrameworkMultiTenantUnitOfWork : EntityFrameworkUnitOfWork
    {
        protected Tenant tenant;

        public EntityFrameworkMultiTenantUnitOfWork(Tenant tenant)
            : this(tenant, false)
        {
        }

        public EntityFrameworkMultiTenantUnitOfWork(Tenant tenant, bool beginTransaction)
            : base(tenant?.ConnectionNameOrConnectionString, beginTransaction)
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
    }
}
