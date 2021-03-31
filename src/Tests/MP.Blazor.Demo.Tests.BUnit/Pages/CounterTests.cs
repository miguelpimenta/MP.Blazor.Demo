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
        private readonly IState<CounterState> CounterState;
        private readonly IDispatcher Dispatcher;
        private readonly IJSRuntime IJSRuntime;
        private readonly NavigationManager NavigationManager;
        private readonly IConfiguration Configuration;
        private readonly ILogger Logger;

        public CounterTests()
        {
            CounterState = A.Fake<IState<CounterState>>();
            Dispatcher = A.Fake<IDispatcher>();
            IJSRuntime = A.Fake<IJSRuntime>();
            NavigationManager = A.Fake<NavigationManager>();
            Configuration = A.Fake<IConfiguration>();
            Logger = A.Fake<ILogger>();
        }

        private TestContext GetTestContext()
        {
            var ctx = new TestContext();
            ctx.Services.AddFluxor(options => options.ScanAssemblies(Assembly.Load("MP.Blazor.Demo")));
            ctx.Services.AddSingleton(CounterState);
            ctx.Services.AddSingleton(Dispatcher);
            ctx.Services.AddSingleton(NavigationManager);
            ctx.Services.AddSingleton(IJSRuntime);
            ctx.Services.AddSingleton(Configuration);
            ctx.Services.AddSingleton(Logger);
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
            A.CallTo(() => Dispatcher.Dispatch(new IncreaseCounter()))
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
            A.CallTo(() => Dispatcher.Dispatch(new DecreaseCounter()))
                .MustHaveHappenedOnceExactly();

            cut
                .Find("#CountResult p")
                .TextContent
                .Should()
                .Be("Current count: -1");
        }
    }
}