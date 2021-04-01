using System.Linq;
using System.Reflection;
using Bunit;
using FakeItEasy;
using FluentAssertions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using MP.Blazor.Demo.Core.Application.Features.Counter.Actions;
using MP.Blazor.Demo.Core.Application.Features.Counter.States;
using MP.Blazor.Demo.Pages;
using Serilog;
using Xunit;
using Xunit.Extensions.Ordering;

namespace MP.Blazor.Demo.Tests.BUnit.Pages
{
    [Trait("Category", "Counter Increment/Decrement")]
    public class CounterTests : TestContext
    {
        private readonly IState<CounterState> _counterState;
        private readonly IDispatcher _dispatcher;
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigationManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public CounterTests()
        {
            _counterState = A.Fake<IState<CounterState>>();
            _dispatcher = A.Fake<IDispatcher>();
            _jsRuntime = A.Fake<IJSRuntime>();
            _navigationManager = A.Fake<NavigationManager>();
            _configuration = A.Fake<IConfiguration>();
            _logger = A.Fake<ILogger>();
        }

        private TestContext GetTestContext()
        {
            var ctx = new TestContext();
            ctx.Services.AddFluxor(options => options.ScanAssemblies(Assembly.Load("MP.Blazor.Demo")));
            ctx.Services.AddSingleton(_counterState);
            ctx.Services.AddSingleton(_dispatcher);
            ctx.Services.AddSingleton(_navigationManager);
            ctx.Services.AddSingleton(_jsRuntime);
            ctx.Services.AddSingleton(_configuration);
            ctx.Services.AddSingleton(_logger);
            return ctx;
        }

        [Fact(DisplayName = "IncreaseCount Must Be Called Once"), Order(2),]
        public void TestIncreaseCount()
        {
            var testContext = GetTestContext();
            var cut = testContext.RenderComponent<Counter>();

            // Act
            var btnIncrease = cut
                .FindAll("button")
                .SingleOrDefault(b => b.Id.Equals("BtnIncreaseCount"));

            btnIncrease.Click();

            // Assert
            A.CallTo(() => _dispatcher.Dispatch(new IncreaseCounter()))
                .MustHaveHappenedOnceExactly();

            cut
                .Find("#CountResult p")
                .TextContent
                .Should()
                .Be("Current count: 1");
        }

        [Fact(DisplayName = "DecreaseCount Must Be Called Once"), Order(2),]
        public void TestDecreaseCounbt()
        {
            var testContext = GetTestContext();
            var cut = testContext.RenderComponent<Counter>();

            // Act
            var btnDecrease = cut
                .FindAll("button")
                .SingleOrDefault(b => b.Id.Equals("BtnDecreaseCount"));

            btnDecrease.Click();

            // Assert
            A.CallTo(() => _dispatcher.Dispatch(new DecreaseCounter()))
                .MustHaveHappenedOnceExactly();

            cut
                .Find("#CountResult p")
                .TextContent
                .Should()
                .Be("Current count: -1");
        }
    }
}