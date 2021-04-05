using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MP.Blazor.Demo.Pages.Tests
{
    public partial class TestDialog
    {
        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }

        private void Submit() => MudDialog.Close(DialogResult.Ok(true));

        private void Cancel() => MudDialog.Cancel();
    }
}