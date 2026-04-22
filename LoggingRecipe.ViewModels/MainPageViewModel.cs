using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace LoggingRecipe.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly ILogger<MainPageViewModel> logger;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(LogInfoCommand))]
    private string message = string.Empty;

    [ObservableProperty]
    private string lastLog = "Noch kein Logeintrag";

    [ObservableProperty]
    private string lifecycleState = "Lifecycle: nicht gestartet";

    public MainPageViewModel(ILogger<MainPageViewModel> logger)
    {
        this.logger = logger;
    }

    public void OnAppearing()
    {
        LifecycleState = "Lifecycle: OnAppearing";
        logger.LogDebug("MainPage appeared");
    }

    public void OnDisappearing()
    {
        LifecycleState = "Lifecycle: OnDisappearing";
        logger.LogDebug("MainPage disappearing");
    }

    [RelayCommand(CanExecute = nameof(CanLogInfo))]
    private void LogInfo()
    {
        var normalizedMessage = Message.Trim();
        logger.LogInformation("User message logged: {Message}", normalizedMessage);

        LastLog = $"INFO: {normalizedMessage}";
        Message = string.Empty;
    }

    private bool CanLogInfo() => !string.IsNullOrWhiteSpace(Message);
}
