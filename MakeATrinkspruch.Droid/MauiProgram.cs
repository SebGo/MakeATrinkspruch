using MakeATrinkspruch.Services;

namespace MakeATrinkspruch.Droid;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseSharedMauiApp();
        var app = builder.Build();

        ServiceHelper.Initialize(app.Services);

        return app;
    }
}
