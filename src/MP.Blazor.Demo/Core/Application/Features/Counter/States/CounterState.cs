using Fluxor;

namespace MP.Blazor.Demo.Core.Application.Features.Counter.States
{
    public record CounterState
    {
        public int Count { get; init; }
    }

    public class CounterFeatureState : Feature<CounterState>
    {
        public override string GetName() => nameof(CounterState);

        protected override CounterState GetInitialState() => new CounterState
        {
            Count = 0,
        };
    }
}