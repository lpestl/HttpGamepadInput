using HttpGamepadInput.ViewModels;

namespace HttpGamepadInput.Views;

public partial class MainPage : ContentPage
{
    public GamepadViewModel ViewModel => (GamepadViewModel)BindingContext;
    public MainPage()
    {
        InitializeComponent();
    }
}