using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WebApp.Components
{
    public partial class SideBar : ComponentBase, IAsyncDisposable
    {
        // Load the module and keep a reference to it
        // You need to use .AsTask() to convert the ValueTask to Task as it may be awaited multiple times
        private Task<IJSObjectReference>? _module;
        private Task<IJSObjectReference> Module => _module ??= JS.InvokeAsync<IJSObjectReference>("import", "./Components/SideBar.razor.js").AsTask();

        public async Task ToggleSidebar()
        {
            var module = await Module;
            await module.InvokeVoidAsync("toggleSidebar");
        }

        public async ValueTask DisposeAsync()
        {
            if (_module != null)
            {
                var module = await _module;
                await module.DisposeAsync();
            }
        }
    }
}
