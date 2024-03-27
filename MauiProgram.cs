﻿using Microsoft.Extensions.Logging;

namespace NeknajStudyManager
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
                    fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FontAwesome-Regular");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FontAwesome-Solid");

                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
