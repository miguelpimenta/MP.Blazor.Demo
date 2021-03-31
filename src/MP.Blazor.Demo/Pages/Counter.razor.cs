using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MP.Blazor.Demo.Core.Application.Features.Counter.Actions;
using MP.Blazor.Demo.Core.Application.Features.Counter.States;

namespace MP.Blazor.Demo.Pages
{
    public partial class Counter
    {
        [Inject]
        private IState<CounterState> CounterState { get; set; }

        [Inject]
        private IDispatcher Dispatcher { get; set; }

        public int CurrentCount => CounterState.Value.Count;

        protected override async Task OnInitializedAsync()
        {
        }

        private void IncreaseCount()
        {
            Dispatcher.Dispatch(new IncreaseCounter());
        }

        private void ResetCount()
        {
            Dispatcher.Dispatch(new ResetCounter());
        }

        private void DecreaseCount()
        {
            Dispatcher.Dispatch(new DecreaseCounter());
        }
    }
}