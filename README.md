# csharp-maui-logging

Agent-generated MAUI-Beispiel fuer Logging mit minimalem Scope.

## Lernfokus

- MVVM mit `CommunityToolkit.Mvvm`
- Logging aus ViewModel und App-Lifecycle
- Unit Tests mit MSTest

## Projektstruktur

- `LoggingRecipe/` MAUI-App (UI, DI, Lifecycle)
- `LoggingRecipe.ViewModels/` ViewModel-Logik und Command-Handling
- `LoggingRecipe.Tests/` MSTest fuer ViewModel-Verhalten

## Verifikation

- `dotnet test LoggingRecipe.Tests/LoggingRecipe.Tests.csproj`
- `dotnet build LoggingRecipe/LoggingRecipe.csproj -f net10.0-maccatalyst -p:ValidateXcodeVersion=false`