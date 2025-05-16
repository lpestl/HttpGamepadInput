using HttpGamepadInput.ViewModels;

namespace HttpGamepadInput.Views;

public partial class MainPage : ContentPage
{
    private GamepadViewModel ViewModel => (GamepadViewModel) BindingContext;
    public MainPage()
    {
        InitializeComponent();
    }

    private void AButton_OnSizeChanged(object? sender, EventArgs e)
    {
        var command = ViewModel.UpButtonPressedCommand;
        if (sender is Button button)
        {
            button.CornerRadius = (int)(button.Width / 2);
            ALabel.FontSize = (int)(button.Width / 3);
        }
    }
    
    private void BButton_OnSizeChanged(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            button.CornerRadius = (int)(button.Width / 2);
            BLabel.FontSize = (int)(button.Width / 3);
        }
    }

    private void SelectButton_OnSizeChanged(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            button.CornerRadius = (int)(button.Height / 2);
            SelectLabel.FontSize = (int)(button.Width / 3);
        }
    }

    private void StartButton_OnSizeChanged(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            button.CornerRadius = (int)(button.Height / 2);
            StartLabel.FontSize = (int)(button.Width / 3);
        }
    }
}