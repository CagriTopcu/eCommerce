using eCommerce.Categories;
using eCommerce.Discounts;
using eCommerce.Orders;
using eCommerce.Payments;
using eCommerce.Products;
using eCommerce.Stores;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace eCommerce.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class eCommerceDbContext :
    AbpDbContext<eCommerceDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Category> Categories { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Category>(b =>
        {
            b.ToTable(eCommerceConsts.DbTablePrefix + "Categories",
                eCommerceConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(CategoryConsts.MaxNameLength);
        });

        builder.Entity<Discount>(b =>
        {
            b.ToTable(eCommerceConsts.DbTablePrefix + "Discounts",
                eCommerceConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(DiscountConsts.MaxNameLength);

            b.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(DiscountConsts.MaxCodeLength);

            b.Property(x => x.DiscountType)
                .IsRequired();

            b.Property(x => x.DiscountPercentage)
                .IsRequired();

            b.Property(x => x.DiscountAmount)
                .IsRequired();

            b.Property(x => x.IsExpirable)
                .IsRequired();
        });

        builder.Entity<Order>(b =>
        {
            b.ToTable(eCommerceConsts.DbTablePrefix + "Orders",
                eCommerceConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(x => x.OrderNo)
                .IsRequired();

            b.Property(x => x.StoreId)
                .IsRequired();

            b.Property(x => x.CustomerId)
                .IsRequired();

            b.Property(x => x.BillingAddressId)
                .IsRequired();

            b.Property(x => x.ShippingAddressId)
                .IsRequired();

            b.Property(x => x.PaymentId)
                .IsRequired();

            b.Property(x => x.Subtotal)
                .IsRequired();

            b.Property(x => x.Tax)
                .IsRequired();

            b.Property(x => x.Total)
                .IsRequired();

            b.Property(x => x.Discount)
                .IsRequired();

            b.Property(x => x.PickupInStore)
                .IsRequired();

            b.Property(x => x.Status)
                .IsRequired();
        });
    }
}
