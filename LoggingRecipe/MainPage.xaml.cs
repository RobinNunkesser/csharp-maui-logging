using LoggingRecipe.ViewModels;

namespace LoggingRecipe;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        viewModel.OnDisappearing();
        base.OnDisappearing();
    }
}


