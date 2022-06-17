using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using WebApp.Components.Weather;

namespace WebApp.Pages
{
    public partial class FetchData : ComponentBase, IDisposable
    {
        private WeatherForecast[]? _forecasts;

        // We can also capture the browser's width / height if needed. We hold the value here.
        private BrowserWindowSize _browser = new();

        private bool _isSmallMedia;

        protected override async Task OnInitializedAsync()
        {
            _forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                // Subscribe to the OnResized event. This will do work when the browser is resized.
                ResizeListener.OnResized += WindowResized;
            }
        }

        // Always use IDisposable in your component to unsubscribe from the event.
        // Be a good citizen and leave things how you found them.
        // This way event handlers aren't called when nobody is listening.
        void IDisposable.Dispose() => ResizeListener.OnResized -= WindowResized;

        // This method will be called when the window resizes.
        // It is ONLY called when the user stops dragging the window's edge. (It is already throttled to protect your app from perf. nightmares)
        private async void WindowResized(object? _, BrowserWindowSize window)
        {
            // Get the browser's width / height
            _browser = window;

            // Check a media query to see if it was matched. We can do this at any time, but it's best to check on each resize
            _isSmallMedia = await ResizeListener.MatchMedia(Breakpoints.SmallDown);

            // We're outside of the component's lifecycle, be sure to let it know it has to re-render.
            StateHasChanged();
        }
    }
}
