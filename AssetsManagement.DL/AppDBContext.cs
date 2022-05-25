﻿using AssetsManagement.DL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AssetsManagement.DL
{
    public class AppDBContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppDBContext(DbContextOptions<AppDBContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetCategory> AssetCategories { get; set; }
        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ///set autogenerated IDs
            builder.Entity<Employee>()
               .Property(x => x.Id)
               .HasDefaultValueSql("NEWID()");

            builder.Entity<Asset>()
               .Property(x => x.Id)
               .HasDefaultValueSql("NEWID()");

            builder.Entity<AssetCategory>()
               .Property(x => x.Id)
               .HasDefaultValueSql("NEWID()");

            builder.Entity<Department>()
               .Property(x => x.Id)
               .HasDefaultValueSql("NEWID()");

            builder.Entity<Invoice>()
               .Property(x => x.Id)
               .HasDefaultValueSql("NEWID()");

            builder.Entity<Supplier>()
               .Property(x => x.Id)
               .HasDefaultValueSql("NEWID()");

            builder.Entity<Stock>()
               .Property(x => x.Id)
               .HasDefaultValueSql("NEWID()");

            //set primary keys
            builder.Entity<Asset>()
                .HasKey(a => a.Id);

            builder.Entity<Asset>()
                .HasIndex(a => a.Name)
                .IsUnique();
            builder.Entity<AssetCategory>()
                .HasKey(x => x.Id);

            builder.Entity<AuditEntry>()
                .HasKey(x => x.Id);

            builder.Entity<Department>()
                .HasKey(x => x.Id);

            builder.Entity<Employee>()
                .HasKey(e => e.Id);
            
            builder.Entity<Invoice>()
               .HasKey(e => e.Id);

            builder.Entity<Stock>()
                .HasKey(x => x.Id);

            builder.Entity<Supplier>()
                .HasKey(x => x.Id);

            //set table names where needed
            builder.Entity<Employee>(x => x
                .ToTable("Employees"));

            //relations
            builder.Entity<Asset>()
                .HasOne(c => c.AssetCategory)
                .WithMany(a => a.Assets)
                .HasForeignKey(a => a.AssetCategoryId);

            builder.Entity<Asset>()
                .HasOne(e => e.Owner)
                .WithMany(u => u.Assets)
                .HasForeignKey(a => a.OwnerId);

            builder.Entity<Asset>()
                .HasOne(s => s.Stock)
                .WithMany(a => a.Assets)
                .HasForeignKey(a => a.StockId);

            builder.Entity<Asset>()
                .HasOne(i => i.Invoice)
                .WithMany(a => a.Assets)
                .HasForeignKey(a => a.InvoiceId);

            builder.Entity<Invoice>()
                .HasOne(s => s.Supplier)
                .WithMany(i => i.Invoices)
                .HasForeignKey(i => i.SupplierId);
            builder.Entity<Employee>()
                .HasOne(m => m.Manager)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            EntityState[] trackedStates = new EntityState[] { EntityState.Added, EntityState.Modified, EntityState.Deleted };
            var httpContext = _httpContextAccessor.HttpContext;
            //  If we will have any kind of user registration - entity changes in this case won't need to be tracked
            if (!(httpContext.Request.Path == "/Account/Register"))
            {
                var user = Regex.Replace(httpContext.User.Identity.Name, ".*\\\\(.*)", "$1", RegexOptions.None);
                if (httpContext != null && user != null)
                {
                    ChangeTracker.Entries().Where(p => trackedStates.Contains(p.State))
                        .ToList().ForEach(entry =>
                        {
                            Audit(entry, user);
                        });
                }
            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void Audit(EntityEntry entry, string CurrentUser)
        {
            // var key = entry.Property("Id").CurrentValue.ToString();
            var entityName = entry.Metadata.ClrType.Name;
            var pKey = entry.Metadata.FindPrimaryKey()
                .Properties.Select(p => entry.Property(p.Name).CurrentValue).ToArray()[0].ToString();
            foreach (var property in entry.Properties)
            {
                //if ((property.OriginalValue.Equals(property.CurrentValue) && property.CurrentValue != null)
                //    && property.Metadata.Name == "Modified"
                //    )
                if (Equals(property.OriginalValue, property.CurrentValue) || property.Metadata.Name == "Modified")
                {
                    continue;
                }
                else
                {
                    var auditEntry = new AuditEntry
                    {
                        EntityName = entityName,//entry.Metadata.Name.Replace("it_stock_manager.Data.", ""),   //entry.Entity.GetType().Name,
                        PropertyName = property.Metadata.Name,
                        PrimaryKeyValue = pKey,
                        OldValue = property.OriginalValue == null ? null : property.OriginalValue.ToString(),
                        NewValue = property.CurrentValue.ToString(),
                        DateChanged = DateTime.Now,
                        Author = CurrentUser
                    };
                    this.AuditEntries.Add(auditEntry);
                }
            }
        }
    }
}
