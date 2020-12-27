namespace PMStudio.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using PMStudio.Data.Common.Models;
    using PMStudio.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<PropertyVendor> PropertyVendors { get; set; }

        public DbSet<MaintenanceService> MaintenanceServices { get; set; }



        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
               new ApplicationUser
               {
                   PasswordHash = passwordHasher.HashPassword(null, "123456"),
                   CreatedOn = DateTime.Now,
                   Email = "pepibasket@yahoo.com",
                   UserName = "pepibasket@yahoo.com",
                   Id = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
               });

            builder.Entity<Property>().HasData(
                new Property
                {
                    Id = 1,
                    Name = "Newport Condo",
                    Address = "100 Marguerite Ave, Unit 2, Newport Beach, CA 92660",
                    Owner = "WestCoast Investments",
                    Type = 0,
                    ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                });

            builder.Entity<Image>().HasData(
                new Image
                {
                    Id = new Guid("d43e3dd4-4f55-4c84-92b2-94c4b84b924a").ToString(),
                    AddedByUserId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                    PropertyId = 1,
                    Extension = "jpg",
                    CreatedOn = DateTime.UtcNow,
                });

            builder.Entity<Property>().HasData(
           new Property
           {
               Id = 2,
               Name = "Irvine Warehouse",
               Address = "1822 Redhill, Irvine, Ca 92112",
               Owner = "Logistics Solutions LLC",
               Type = 0,
               ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
           });

            builder.Entity<Vendor>().HasData(
               new Vendor
               {
                   Id = 12,
                   Name = "Cox",
                   Trade = "Telephones",
                   Address = "2020 Von Karman Ave, Irvine, CA 92660",
                   Phone = "714-122-1338",
                   Email = "help@cox.com",
                   ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
               });

            builder.Entity<Vendor>().HasData(
                new Vendor
                {
                    Id = 13,
                    Name = "AT&T",
                    Trade = "Internet",
                    Address = "2020 Von Karman Ave, Irvine, CA 92660",
                    Phone = "714-511-5878",
                    Email = "help@at&t.com",
                    ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                });

            builder.Entity<Vendor>().HasData(
                new Vendor
                {
                    Id = 3,
                    Name = "Best Plumbing Specialists",
                    Trade = "Plumbing",
                    Address = "1414 Von Karman Ave, Irvine, CA 92660",
                    Phone = "714-111-4147",
                    Email = "service@bestplumbing.com",
                    ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                });

            builder.Entity<Vendor>().HasData(
               new Vendor
               {
                   Id = 4,
                   Name = "Cleaning Crew",
                   Trade = "Cleaning",
                   Address = "218 Michelson Ave, Irvine, CA 92660",
                   Phone = "714-111-5151",
                   Email = "info@cleaningcrew.com",
                   ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
               });

            builder.Entity<Vendor>().HasData(
               new Vendor
               {
                   Id = 5,
                   Name = "Five Star Elevator",
                   Trade = "Elevator Repairs",
                   Address = "100 12th Str, Costa Mesa, CA 92414",
                   Phone = "914-747-1100",
                   Email = "nick@fivestar.com",
                   ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
               });

            builder.Entity<Vendor>().HasData(
              new Vendor
              {
                  Id = 6,
                  Name = "Moving For Fun",
                  Trade = "Moving Services",
                  Address = "PO Box 104, Los Angeles, CA 95114",
                  Phone = "949-555-5511",
                  Email = "moving@movingforfun.com",
                  ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
              });

            builder.Entity<Vendor>().HasData(
             new Vendor
             {
                 Id = 7,
                 Name = "PestExterminators",
                 Trade = "Pest Control",
                 Address = "110 Newport Dr, Newport Beach, CA 92418",
                 Phone = "949-142-2284",
                 Email = "help@pestexterminator.com",
                 ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
             });

            builder.Entity<Vendor>().HasData(
            new Vendor
            {
                Id = 8,
                Name = "Westex",
                Trade = "HVAC",
                Address = "22 6th Ave, Los Angeles, CA 94422",
                Phone = "818-521-4840",
                Email = "john@westex.com",
                ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
            });

            builder.Entity<Vendor>().HasData(
           new Vendor
           {
               Id = 9,
               Name = "Modern",
               Trade = "Interior Design",
               Address = "22th Ave, Los Angeles, CA 94422",
               Phone = "818-111-9951",
               Email = "sara@modern.com",
               ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
           });

            builder.Entity<Vendor>().HasData(
          new Vendor
          {
              Id = 10,
              Name = "Security Control LLC",
              Trade = "Alarm",
              Address = "2151 Baranca, Santa Ana, CA 92650",
              Phone = "949-013-0103",
              Email = "info@securitycontrol.com",
              ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
          });

            builder.Entity<Vendor>().HasData(
            new Vendor
            {
                Id = 11,
                Name = "John&John Co.",
                Trade = "Painting",
                Address = "333 Marguerite, Long Beach, CA 92650",
                Phone = "714-214-3510",
                Email = "johnjohnson@gmail.com",
                ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
            });
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
