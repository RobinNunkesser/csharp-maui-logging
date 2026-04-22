using LoggingRecipe.ViewModels;
using Microsoft.Extensions.Logging;

namespace LoggingRecipe.Tests;

[TestClass]
public sealed class MainPageViewModelTests
{
    private sealed class CapturingLogger<T> : ILogger<T>
    {
        public List<string> Messages { get; } = new();

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            Messages.Add($"{logLevel}: {formatter(state, exception)}");
        }
    }

    [TestMethod]
    public void LogInfoCommand_LogsMessageAndClearsInput()
    {
        var logger = new CapturingLogger<MainPageViewModel>();
        var vm = new MainPageViewModel(logger)
        {
            Message = "  Hallo Logging  "
        };

        vm.LogInfoCommand.Execute(null);

        Assert.AreEqual(string.Empty, vm.Message);
        Assert.AreEqual("INFO: Hallo Logging", vm.LastLog);
        Assert.IsTrue(logger.Messages.Any(m => m.Contains("Information") && m.Contains("Hallo Logging")));
    }

    [TestMethod]
    public void LogInfoCommand_CannotExecuteForWhitespace()
    {
        var logger = new CapturingLogger<MainPageViewModel>();
        var vm = new MainPageViewModel(logger)
        {
            Message = "   "
        };

        var canExecute = vm.LogInfoCommand.CanExecute(null);

        Assert.IsFalse(canExecute);
    }

    [TestMethod]
    public void LifecycleMethods_UpdateStateAndWriteDebugLogs()
    {
        var logger = new CapturingLogger<MainPageViewModel>();
        var vm = new MainPageViewModel(logger);

        vm.OnAppearing();
        Assert.AreEqual("Lifecycle: OnAppearing", vm.LifecycleState);

        vm.OnDisappearing();
        Assert.AreEqual("Lifecycle: OnDisappearing", vm.LifecycleState);

        Assert.IsTrue(logger.Messages.Any(m => m.Contains("Debug") && m.Contains("appeared")));
        Assert.IsTrue(logger.Messages.Any(m => m.Contains("Debug") && m.Contains("disappearing")));
    }
}
