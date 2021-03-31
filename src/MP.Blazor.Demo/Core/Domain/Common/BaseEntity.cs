using System;

namespace MP.Blazor.Demo.Core.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}