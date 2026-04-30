using Microsoft.Extensions.Logging;

namespace LoggingRecipe;

public partial class App : Application
{
    private readonly ILogger<App> _logger;
    private readonly AppShell appShell;

    public App(ILogger<App> logger, AppShell appShell)
    {
        InitializeComponent();
        _logger = logger;
        this.appShell = appShell;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        _logger.LogDebug("Creating window at: {CreatedAt}", DateTimeOffset.Now);
        return new Window(appShell);
    }

    protected override void OnStart()
    {
        base.OnStart();
        _logger.LogDebug("Started at: {StartedAt}", DateTimeOffset.Now);
    }

}
