using System;

namespace MP.Blazor.Demo.Core.Application.Contracts
{
    public interface IUserService
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
    }
}