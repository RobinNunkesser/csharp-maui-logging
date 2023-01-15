using Microsoft.Extensions.Logging;

namespace LoggingRecipe;

public partial class App : Application
{
    private readonly ILogger<App> _logger;

    public App(ILogger<App> logger)
    {
        InitializeComponent();
        MainPage = new AppShell();
        _logger = logger;
    }

    protected override void OnStart()
    {
        base.OnStart();
        _logger.LogDebug($"Started at: {DateTimeOffset.Now}");
    }

}

