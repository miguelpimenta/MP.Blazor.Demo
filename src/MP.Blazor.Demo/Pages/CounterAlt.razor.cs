using System.Threading.Tasks;

namespace MP.Blazor.Demo.Pages
{
    public partial class CounterAlt
    {
        public int CurrentCount { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1)
                .ConfigureAwait(false);
        }

        private void IncreaseCount()
        {
            CurrentCount++;
        }

        private void ResetCount()
        {
            CurrentCount = 0;
        }

        private void DecreaseCount()
        {
            CurrentCount--;
        }
    }
}