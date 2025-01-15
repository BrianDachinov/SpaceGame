global using DrawnUi.Maui.Draw;
using Microsoft.Extensions.Logging;


namespace SpaceShooter
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("OpenSans-Regular.ttf", "FontText");

                    fonts.AddFont("Orbitron-Regular.ttf", "FontGame"); 
                    fonts.AddFont("Orbitron-Medium.ttf", "FontGameMedium"); 
                    fonts.AddFont("Orbitron-SemiBold.ttf", "FontGameSemiBold"); 
                    fonts.AddFont("Orbitron-Bold.ttf", "FontGameBold"); 
                    fonts.AddFont("Orbitron-ExtraBold.ttf", "FontGameExtraBold"); 
                });

            builder.UseDrawnUi(new()
            {
                UseDesktopKeyboard = true, 
                DesktopWindow = new()
                {
                    Width = 550,
                    Height = 750,
                    IsFixedSize = true 
                    
                }
            });

            
            SkiaImageManager.ReuseBitmaps = true;

#if WINDOWS
            
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static bool IsDebug
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }
}