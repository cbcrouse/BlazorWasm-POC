using BlazorPro.BlazorSize;
using Core.Components.Weather;
using Microsoft.AspNetCore.Components;

namespace Core.Pages
{
    public partial class Dashboard : ComponentBase, IDisposable
    {
        private IEnumerable<WeatherForecast>? _forecasts;

        // We can also capture the browser's width / height if needed. We hold the value here.
        private BrowserWindowSize _browser = new();

        private bool _isSmallMedia;

        protected override async Task OnInitializedAsync()
        {
            _forecasts = new List<WeatherForecast>
            {
                new() {Date = new DateTime(2018, 5, 6), Summary = "Freezing", TemperatureC = 1},
                new() {Date = new DateTime(2018, 5, 7), Summary = "Bracing", TemperatureC = 14},
                new() {Date = new DateTime(2018, 5, 8), Summary = "Freezing", TemperatureC = -13},
                new() {Date = new DateTime(2018, 5, 9), Summary = "Balmy", TemperatureC = -16},
                new() {Date = new DateTime(2018, 5, 10), Summary = "Chilly", TemperatureC = -2}
            };
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
