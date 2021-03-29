using System.Threading.Tasks;
using Fluxor;
using MP.Blazor.Demo.Core.Application.Features.Counter.Actions;
using MP.Blazor.Demo.Core.Application.Features.Counter.States;
using Serilog;

namespace MP.Blazor.Demo.Core.Application.Features.Counter.Effects
{
    public class CounterEffects
    {
        private readonly IState<CounterState> _counterState;
        private readonly ILogger _logger;

        public CounterEffects(
            IState<CounterState> counterState,
            ILogger logger)
        {
            _counterState = counterState;
            _logger = logger;
        }

        [EffectMethod]
        public Task LogIncreaseCounter(
            IncreaseCounter action,
            IDispatcher dispatcher)
        {
            _logger.Information($"Current Count: {_counterState.Value.Count}.\nCounter increased with step {action.Step}");

            return Task.CompletedTask;
        }

        [EffectMethod]
        public Task LogResetCounter(
            ResetCounter action,
            IDispatcher dispatcher)
        {
            _logger.Information($"Reset Count to {_counterState.Value.Count}.");

            return Task.CompletedTask;
        }

        [EffectMethod]
        public Task LogDecreaseCounter(
            DecreaseCounter action,
            IDispatcher dispatcher)
        {
            _logger.Information($"Current Count: {_counterState.Value.Count}.\nCounter decreased with step {action.Step}");

            return Task.CompletedTask;
        }
    }
}