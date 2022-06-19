using Microsoft.AspNetCore.Components;

namespace Core.Components.Weather
{
    public partial class WeatherCards : ComponentBase
    {
        [Parameter]
        public IEnumerable<WeatherForecast> WeatherForecasts { get; set; } = new List<WeatherForecast>();
    }
}
