using Fluxor;
using MP.Blazor.Demo.Core.Application.Features.Counter.States;

namespace MP.Blazor.Demo.Core.Application.Features.Counter
{
    public class CounterFeature : Feature<CounterState>
    {
        public override string GetName() => nameof(CounterState);

        protected override CounterState GetInitialState() => new CounterState
        {
            Count = 0,
        };
    }
}