
using EFCoreCosmosSample.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EFCoreCosmosSample.Infrastructure.Contexts
{
    public class FamilyContext: DbContext
    {
        public FamilyContext()
        { 
        }

        public FamilyContext(DbContextOptions<FamilyContext> options): base(options)
        {
           this.Database.EnsureCreated();
        }

        public DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var familyEntity = modelBuilder.Entity<Family>();
            familyEntity
                .ToContainer("Families");

            familyEntity.HasPartitionKey(x => x.Id);
            familyEntity.HasKey(u => u.Id);

            familyEntity
                .Property(f => f.Id)
                .HasConversion<string>()
                .HasValueGenerator<SequentialGuidValueGenerator>();

            familyEntity
                .OwnsMany(f => f.Children)
                .WithOwner()
                .HasForeignKey(x => x.FamilyId);

        }
    }
}
