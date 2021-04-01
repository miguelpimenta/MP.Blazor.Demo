using System;
using MediatR;

namespace MP.Blazor.Demo.Core.Domain.Common
{
    public abstract class DomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;

        public string Event { get; set; }
    }
}