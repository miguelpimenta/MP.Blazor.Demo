using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MP.Blazor.Demo.Core.Domain.Entities;
using MP.Blazor.Demo.Infrastructure.Contexts;

namespace MP.Blazor.Demo.Pages.Products
{
    public partial class Products
    {
        [Inject]
        private AppDbContext AppDbContext { get; set; }

        private DbSet<Product> _repository;

        protected DbSet<Product> Repository => _repository ??= AppDbContext.Set<Product>();

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1)
                .ConfigureAwait(false);

            Repository.Add(new Product { Id = Guid.NewGuid() });
            await AppDbContext.SaveChangesAsync();
        }
    }
}