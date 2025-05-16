using HttpGamepadInput.ViewModels;

namespace HttpGamepadInput.Views;

public partial class MainPage : ContentPage
{
    public GamepadViewModel ViewModel => (GamepadViewModel)BindingContext;
    public MainPage()
    {
        InitializeComponent();
    }

    private void Button_OnSizeChanged(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            button.CornerRadius = (int)(button.Width / 2);
        }
    }
}