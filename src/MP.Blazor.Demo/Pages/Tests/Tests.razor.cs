using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MP.Blazor.Demo.Pages.Tests
{
    public partial class Tests
    {
        [Inject]
        private IDialogService DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1)
                .ConfigureAwait(false);
        }

        private void OpenDialog()
        {
            DialogService.Show<TestDialog>("Simple Dialog");
        }
    }
}