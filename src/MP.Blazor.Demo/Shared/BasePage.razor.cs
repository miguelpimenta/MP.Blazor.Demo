using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace MP.Blazor.Demo.Shared
{
    public partial class BasePage
    {
        #region Injects

        [Inject]
        protected IConfiguration Configuration { get; set; }

        [Inject]
        protected ILogger Logger { get; set; }

        #endregion Injects
    }
}