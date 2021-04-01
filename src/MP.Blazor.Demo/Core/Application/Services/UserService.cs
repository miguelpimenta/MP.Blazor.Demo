using System;
using MP.Blazor.Demo.Core.Application.Contracts;

namespace MP.Blazor.Demo.Core.Application.Services
{
    public class UserService : IUserService
    {
        public Guid Id { get; set; } = Guid.Parse("C31953BD-8F3A-4A02-AB81-EC8C8323EA30");

        public string Name { get; set; } = "TestUser";

        public string Email { get; set; } = "user@test.com";
    }
}