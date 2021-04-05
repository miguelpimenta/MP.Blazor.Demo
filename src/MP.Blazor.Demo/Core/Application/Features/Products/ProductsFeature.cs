using System;
using System.Collections.Generic;
using Fluxor;
using MP.Blazor.Demo.Core.Domain.Entities;

namespace MP.Blazor.Demo.Core.Application.Features.Products
{
    //! Feature
    public class ProductsFeature : Feature<ProductsState>
    {
        public override string GetName() => nameof(ProductsState);

        protected override ProductsState GetInitialState() =>
            new(Array.Empty<Product>(), null);
    }

    //! Actions
    public class ProductsActions
    {
    }

    //! Effects
    public class ProductsEffects
    {
    }

    //! Reducers
    public class ProductsReducers
    {
    }

    //! State

    public record ProductsState
    {
#nullable enable
        public IEnumerable<Product>? Products { get; init; }

        public Product? CurrentProduct { get; init; }

        public ProductsState(
            IEnumerable<Product>? products,
            Product? currentProduct)
        {
            Products = products;
            CurrentProduct = currentProduct;
        }
#nullable disable
    }
}