using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpGamepadInput.ViewModels;

namespace HttpGamepadInput.Views;

public partial class SettingsPage : ContentPage
{
    public SettingsViewModel ViewModel => (SettingsViewModel) BindingContext; 
        
    public SettingsPage()
    {
        InitializeComponent();
    }
    
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (Preferences.ContainsKey("ServerUrl"))
        {
            ServerUrlEntry.Text = Preferences.Get("ServerUrl", string.Empty);
        }
    }
}