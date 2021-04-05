using System.Threading.Tasks;

namespace MP.Blazor.Demo.Pages
{
    public partial class Index
    {
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1)
                .ConfigureAwait(false);
        }
    }
}