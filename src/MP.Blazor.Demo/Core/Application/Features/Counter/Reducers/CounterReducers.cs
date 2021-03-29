using Fluxor;
using MP.Blazor.Demo.Core.Application.Features.Counter.Actions;
using MP.Blazor.Demo.Core.Application.Features.Counter.States;

namespace MP.Blazor.Demo.Core.Application.Features.Counter.Reducers
{
    public static class CounterReducer
    {
        [ReducerMethod]
        public static CounterState OnIncreaseCounter(
            CounterState state,
            IncreaseCounter action) => state with
            {
                Count = state.Count + action.Step
            };

        [ReducerMethod]
        public static CounterState OnResetCounter(
            CounterState state,
            ResetCounter action) => state with
            {
                Count = action.Step
            };

        [ReducerMethod]
        public static CounterState OnDecreaseCounter(
            CounterState state,
            DecreaseCounter action) => state with
            {
                Count = state.Count - action.Step
            };
    }
}