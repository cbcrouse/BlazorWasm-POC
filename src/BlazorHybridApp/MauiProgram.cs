﻿using BlazorPro.BlazorSize;
using Core.Services;
using MudBlazor.Services;

namespace BlazorHybridApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddScoped(_ => new HttpClient());
            // For some reason, I cannot navigate to other pages without having HttpClient registered.
            builder.Services.AddSingleton<SideBarService>();
            builder.Services.AddMediaQueryService();
            builder.Services.AddResizeListener();
            builder.Services.AddMudServices();

            return builder.Build();
        }
    }
}