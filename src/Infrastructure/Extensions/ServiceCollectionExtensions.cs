using BlazorPro.BlazorSize;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register all required services for Blazor UI components and services.
        /// </summary>
        /// <param name="serviceCollection">Specifies the contract for a collection of service descriptors.</param>
        /// <returns>An instance of <see cref="IServiceCollection"/> with registered Blazor UI Services.</returns>
        public static IServiceCollection AddBlazorServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddMudBlazorServices()
                .AddMediaQueryService()
                .AddResizeListener()
                .AddSingleton<SideBarService>();
        }

        private static IServiceCollection AddMudBlazorServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 4000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
        }
    }
}
