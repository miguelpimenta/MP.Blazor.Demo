using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.Blazor.Demo.Core.Domain.Entities;

namespace MP.Blazor.Demo.Infrastructure.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable(name: "Products", schema: "dbo");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Version)
                .IsConcurrencyToken();

            builder
                 .HasData(
                 new Product
                 {
                     Id = Guid.Parse("688A4BAB-15A2-4159-BDF8-83CD551995BA"),
                     Code = "A123XYZ",
                     Description = "Something Good",
                     Observations = "...",
                     Price = 10m,
                     CreatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     UpdatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     Version = 1
                 },
                 new Product
                 {
                     Id = Guid.Parse("AADF65A8-D14D-4F87-B25A-CC0B7741DB60"),
                     Code = "A456XYZ",
                     Description = "Something Expensive",
                     Observations = "...",
                     Price = 155.5m,
                     CreatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     UpdatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     Version = 1
                 },
                 new Product
                 {
                     Id = Guid.Parse("8BEFCB97-6CDF-4A40-9511-9197BA715379"),
                     Code = "A789XYZ",
                     Description = "Something Cheap",
                     Observations = "...",
                     Price = 1m,
                     CreatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     UpdatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     Version = 1
                 },
                 new Product
                 {
                     Id = Guid.Parse("810A8C8B-6379-42A9-A223-5F41DFF28769"),
                     Code = "B159XYZ",
                     Description = "...",
                     Observations = "...",
                     Price = 1m,
                     CreatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     UpdatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     Version = 1
                 },
                 new Product
                 {
                     Id = Guid.Parse("11063071-7EBA-401E-83C7-F411776EADA5"),
                     Code = "B159XYZ",
                     Description = "...",
                     Observations = "...",
                     Price = 1m,
                     CreatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     CreatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     UpdatedBy = Guid.Parse("95514EB0-50F1-4E13-A7C2-36C7B4984DD8"),
                     UpdatedAt = new DateTime(2021, 3, 1, 12, 0, 0),
                     Version = 1
                 });
        }
    }
}