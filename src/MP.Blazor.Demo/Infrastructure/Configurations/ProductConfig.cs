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
                .ToTable(name: "Services", schema: "public");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                 .HasData(
                 new Product
                 {
                     Id = Guid.Parse("688A4BAB-15A2-4159-BDF8-83CD551995BA"),
                 },
                 new Product
                 {
                     Id = Guid.Parse("AADF65A8-D14D-4F87-B25A-CC0B7741DB60"),
                 },
                 new Product
                 {
                     Id = Guid.Parse("8BEFCB97-6CDF-4A40-9511-9197BA715379"),
                 },
                 new Product
                 {
                     Id = Guid.Parse("810A8C8B-6379-42A9-A223-5F41DFF28769"),
                 },
                 new Product
                 {
                     Id = Guid.Parse("11063071-7EBA-401E-83C7-F411776EADA5"),
                 });
        }
    }
}