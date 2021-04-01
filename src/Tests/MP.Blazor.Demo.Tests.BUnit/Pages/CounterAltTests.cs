using System;
using System.Linq;
using Bunit;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using MP.Blazor.Demo.Pages;
using Serilog;
using Xunit;
using Xunit.Extensions.Ordering;

namespace MP.Blazor.Demo.Tests.BUnit.Pages
{
    [Trait("Category", "Counter Increase/Decrease")]
    public class CounterAltTests : TestContext
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly NavigationManager _navigationManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public CounterAltTests()
        {
            _jsRuntime = A.Fake<IJSRuntime>();
            _navigationManager = A.Fake<NavigationManager>();
            _configuration = A.Fake<IConfiguration>();
            _logger = A.Fake<ILogger>();
        }

        private TestContext GetTestContext()
        {
            var ctx = new TestContext();
            ctx.Services.AddSingleton(_navigationManager);
            ctx.Services.AddSingleton(_jsRuntime);
            ctx.Services.AddSingleton(_configuration);
            ctx.Services.AddSingleton(_logger);
            return ctx;
        }

        [Fact(DisplayName = "Increase Count"), Order(1),]
        public void IncrementCountExpectedBehavior()
        {
            var testContext = GetTestContext();

            var cut = testContext.RenderComponent<CounterAlt>();

            cut
               .Find("#CountResult p")
               .MarkupMatches("<p>Current count: 0</p>");

            cut
               .Find("#CountResult p")
               .MarkupMatches("<p>     Current count: 0     </p>");

            // Act
            var btnIncrease = cut
                .FindAll("button")
                .SingleOrDefault(b => b.Id.Equals("BtnIncreaseCount"));

            btnIncrease.Click();

            cut
                .Find("#CountResult p")
                .TextContent
                .Should()
                .Be("Current count: 1");
        }

        [Fact(DisplayName = "Decrease Count"), Order(2)]
        public void DecrementCountExpectedBehavior()
        {
            var testContext = GetTestContext();

            var cut = testContext.RenderComponent<CounterAlt>();

            cut.Markup.Contains("<p>Current count: 0</p>");

            // Act
            var btnDecrease = cut
                .FindAll("button")
                .SingleOrDefault(b => b.Id.Equals("BtnDecreaseCount"));

            btnDecrease.Click();

            // Assert
            cut
                .Find("#CountResult p")
                .TextContent
                .Should()
                .Be("Current count: -1");
        }

        [Theory(DisplayName = "Increase Count Multiple Times"), Order(3)]
        [InlineData(5, 5)]
        [InlineData(10, 10)]
        [InlineData(15, 15)]
        [InlineData(30, 30)]
        [InlineData(60, 60)]
        public void IncrementCountMultipleTimesExpectedBehavior(int clicks, int countResult)
        {
            var testContext = GetTestContext();

            var cut = testContext.RenderComponent<CounterAlt>();

            cut.Markup.Contains("<p>Current count: 0</p>");

            // Act
            var btnIncrease = cut
                .FindAll("button")
                .SingleOrDefault(b => b.Id.Equals("BtnIncreaseCount"));

            1.UpTo(clicks, (_) => btnIncrease.Click());

            // Assert
            cut
                .Find("#CountResult p")
                .TextContent
                .Should()
                .Be($"Current count: {countResult}");
        }

        [Theory(DisplayName = "Decrease Count Multiple Times"), Order(4)]
        [InlineData(5, -5)]
        [InlineData(10, -10)]
        [InlineData(15, -15)]
        [InlineData(30, -30)]
        [InlineData(60, -60)]
        public void DecrementCountMultipleTimesExpectedBehavior(int clicks, int countResult)
        {
            var testContext = GetTestContext();

            var cut = testContext.RenderComponent<CounterAlt>();

            cut.Markup.Contains("<p>Current count: 0</p>");

            // Act
            var btnDecrease = cut
                .FindAll("button")
                .SingleOrDefault(b => b.Id.Equals("BtnDecreaseCount"));

            1.UpTo(clicks, (_) => btnDecrease.Click());

            // Assert
            cut
                .Find("#CountResult p")
                .TextContent
                .Should()
                .Be($"Current count: {countResult}");
        }

        [Theory(DisplayName = "Increase/Decrease Count Multiple Times"), Order(5)]
        [InlineData(5, 15, -10)]
        [InlineData(10, 10, 0)]
        [InlineData(15, 5, 10)]
        [InlineData(0, 30, -30)]
        [InlineData(60, 30, 30)]
        public void IncrementDecrementCountMultipleTimesExpectedBehavior(
            int increaseClicks,
            int decreaseClicks,
            int countResult)
        {
            var testContext = GetTestContext();

            var cut = testContext.RenderComponent<CounterAlt>();

            cut.Markup.Contains("<p>Current count: 0</p>");

            // Act
            var btnIncrease = cut
                .FindAll("button")
                .SingleOrDefault(b => b.Id.Equals("BtnIncreaseCount"));

            1.UpTo(increaseClicks, (_) => btnIncrease.Click());

            var btnDecrease = cut
                .FindAll("button")
                .SingleOrDefault(b => b.Id.Equals("BtnDecreaseCount"));

            1.UpTo(decreaseClicks, (_) => btnDecrease.Click());

            // Assert
            cut
                .Find("#CountResult p")
                .TextContent
                .Should()
                .Be($"Current count: {countResult}");
        }
    }

    internal static class Extensions
    {
        public static void UpTo(this int start, int end, Action<int> proc)
        {
            for (int i = start; i <= end; i++)
            {
                proc(i);
            }
        }
    }
}