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

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = "B8A39BD0-1C75-4660-9749-0B47328E0720",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                });

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = "5F2A7EDB-703F-479D-BFF9-F19164A66E3A",
                    Name = "User",
                    NormalizedName = "USER",
                });

            builder.Entity<ApplicationUser>().HasData(
               new ApplicationUser
               {
                   PasswordHash = passwordHasher.HashPassword(null, "123456"),
                   CreatedOn = DateTime.Now,
                   Email = "pepibasket@yahoo.com",
                   NormalizedEmail = "PEPIBASKET@YAHOO.COM",
                   UserName = "pepibasket@yahoo.com",
                   NormalizedUserName = "PEPIBASKET@YAHOO.COM",
                   Id = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
               });

            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "B8A39BD0-1C75-4660-9749-0B47328E0720",
                   UserId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
               });

            builder.Entity<ApplicationUser>().HasData(
               new ApplicationUser
               {
                   PasswordHash = passwordHasher.HashPassword(null, "123123"),
                   CreatedOn = DateTime.Now,
                   Email = "vasa@gmail.com",
                   NormalizedEmail = "VASA@GMAIL.COM",
                   UserName = "vasa@gmail.com",
                   NormalizedUserName = "VASA@GMAIL.COM",
                   Id = "B20F8CEE-4341-46CC-84F7-FB75D269A2E4",
               });

            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "5F2A7EDB-703F-479D-BFF9-F19164A66E3A",
                   UserId = "B20F8CEE-4341-46CC-84F7-FB75D269A2E4",
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
               Type = Models.Enum.PropertyType.Commercial,
               ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
           });

            builder.Entity<Image>().HasData(
               new Image
               {
                   Id = new Guid("8eda1d0e-0496-41b2-83bf-c9e26049f569").ToString(),
                   AddedByUserId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                   PropertyId = 2,
                   Extension = "jpg",
                   CreatedOn = DateTime.UtcNow,
               });

            builder.Entity<Property>().HasData(
         new Property
         {
             Id = 3,
             Name = "Aliso Viejo House",
             Address = "12252 Wood Canyon Dr., CA 92229",
             Owner = "Home Properties LLC",
             Type = 0,
             ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
         });

            builder.Entity<Image>().HasData(
            new Image
            {
                Id = new Guid("1db364b0-cae7-4ba2-b5c9-19e88dc91347").ToString(),
                AddedByUserId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                PropertyId = 3,
                Extension = "jpg",
                CreatedOn = DateTime.UtcNow,
            });

            builder.Entity<Property>().HasData(
             new Property
             {
                 Id = 4,
                 Name = "Irvine Valley Home",
                 Address = "37 Baranca, Irvine, CA 92229",
                 Owner = "Home Properties LLC",
                 Type = 0,
                 ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
             });

            builder.Entity<Image>().HasData(
            new Image
            {
                Id = new Guid("C04A661F-96BE-4B9F-AB37-66A7B9E4BD2A").ToString(),
                AddedByUserId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                PropertyId = 4,
                Extension = "jpg",
                CreatedOn = DateTime.UtcNow,
            });

            builder.Entity<Property>().HasData(
             new Property
             {
                 Id = 5,
                 Name = "Newport Mansion",
                 Address = "37 Newport Dr, Newport Beach, CA 92879",
                 Owner = "Home Properties LLC",
                 Type = 0,
                 ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
             });

            builder.Entity<Image>().HasData(
            new Image
            {
                Id = new Guid("31A41705-EC71-4839-8E83-A52D07574C5B").ToString(),
                AddedByUserId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                PropertyId = 5,
                Extension = "jpg",
                CreatedOn = DateTime.UtcNow,
            });

            builder.Entity<Property>().HasData(
                new Property
                {
                    Id = 6,
                    Name = "Storage Place",
                    Address = "818 Johson Str, Long Beach, CA 81447",
                    Owner = "Rental Assets LLC",
                    Type = 0,
                    ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                });

            builder.Entity<Image>().HasData(
            new Image
            {
                Id = new Guid("9FF1E3AC-4AF2-4FE6-9BDC-063121F86E82").ToString(),
                AddedByUserId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                PropertyId = 6,
                Extension = "jpg",
                CreatedOn = DateTime.UtcNow,
            });

            builder.Entity<Property>().HasData(
            new Property
            {
                Id = 7,
                Name = "Grandview Boston",
                Address = "2 Avery, Boston, NA 40115",
                Owner = "Rental Assets LLC",
                Type = 0,
                ManagerId = "B20F8CEE-4341-46CC-84F7-FB75D269A2E4",
            });

            builder.Entity<Image>().HasData(
            new Image
            {
                Id = new Guid("70383C88-03D2-477C-8F93-91611158F251").ToString(),
                AddedByUserId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                PropertyId = 7,
                Extension = "jpg",
                CreatedOn = DateTime.UtcNow,
            });

            builder.Entity<Property>().HasData(
            new Property
            {
                Id = 8,
                Name = "San Clemente Warehouse",
                Address = "101 Cliff Dr, San Clemente, CA 90512",
                Owner = "Logistic Solutics LLC",
                Type = 0,
                ManagerId = "B20F8CEE-4341-46CC-84F7-FB75D269A2E4",
            });

            builder.Entity<Image>().HasData(
            new Image
            {
                Id = new Guid("21DAD2A8-499B-479F-85A9-F0344EAA31DC").ToString(),
                AddedByUserId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                PropertyId = 8,
                Extension = "jpg",
                CreatedOn = DateTime.UtcNow,
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

            builder.Entity<MaintenanceService>().HasData(
                new MaintenanceService
                {
                    Id = 1,
                    PropertyId = 1,
                    VendorId = 3,
                    Name = "Bathroom repair",
                    ServiceDate = DateTime.Parse("11-06-21 10:00:00 AM"),
                });

            builder.Entity<Tenant>().HasData(
                new Tenant
                {
                    Id = 1,
                    Name = "John Smith",
                    PropertyId = 1,
                    Rate = 3500,
                    LeasePeriod = 12,
                    ManagerId = "088bbcf3-2259-4570-93b8-cffbf7a064e5",
                });
            builder.Entity<Tenant>().HasData(
                new Tenant
                {
                    Id = 2,
                    Name = "Kristina Ivanova",
                    PropertyId = 3,
                    Rate = 1500,
                    LeasePeriod = 16,
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
