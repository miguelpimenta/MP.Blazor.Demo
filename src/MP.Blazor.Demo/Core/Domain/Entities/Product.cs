using MP.Blazor.Demo.Core.Domain.Common;

namespace MP.Blazor.Demo.Core.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string Observations { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; } = true;
    }
}