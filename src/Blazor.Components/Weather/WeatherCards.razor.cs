using Microsoft.AspNetCore.Components;

namespace Blazor.Components.Weather
{
    public partial class WeatherCards : ComponentBase
    {
        [Parameter]
        public IEnumerable<WeatherForecast> WeatherForecasts { get; set; } = new List<WeatherForecast>();
    }
}
