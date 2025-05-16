using System.Windows.Input;
using HttpGamepadInput.BaseClasses;

namespace HttpGamepadInput.ViewModels;

public class SettingsViewModel : BindableBase
{
    public ICommand SaveCommand { get; }
    public ICommand TestConnectionCommand { get; }
    
    private string _serverUrl = "http://localhost:8080";
    public string ServerUrl
    {
        get => _serverUrl; 
        set => SetProperty(ref _serverUrl, value);
    }

    private bool _isNotError = true;
    public bool IsNotError
    {
        get => _isNotError;
        set => SetProperty(ref _isNotError, value);
    }

    private string _validationMessage;
    public string ValidationMessage
    {
        get => _validationMessage;
        set
        {
            if (_validationMessage != value)
            {
                _validationMessage = value;
                OnPropertyChanged();
            }
        }
    }
    
    public SettingsViewModel()
    {
        SaveCommand = new Command(OnSaveClicked);
        TestConnectionCommand = new Command(OnTestConnectionClicked);
    }

    private bool IsValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(ServerUrl))
        {
            ValidationMessage = "URL can't be empty.";
            IsNotError = false;
            return false;
        }
        else if (!Uri.TryCreate(ServerUrl, UriKind.Absolute, out var uri) ||
                 !(uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
        {
            ValidationMessage = "Enter valid url address (http or https).";
            IsNotError = false;
            return false;
        }
        else
        {
            ValidationMessage = string.Empty; // All Ok
            IsNotError = true;
        }
        return true;
    }
    
    private void OnSaveClicked()
    {
        string url = ServerUrl.Trim();

        if (!IsValidUrl(url))
        {
            return;
        }

        Preferences.Set("ServerUrl", url);
    }

    private async void OnTestConnectionClicked()
    {
        string url = ServerUrl.Trim();

        if (!IsValidUrl(url))
        {
            return;
        }

        if (!Uri.TryCreate(url, UriKind.Absolute, out var baseUri))
        {
            ValidationMessage = "Error: Filed creating Uri.";
            IsNotError = false;
            return;
        }

        try
        {
            var versionUri = new Uri(baseUri, "/version/");
            
            using HttpClient client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5)
            };

            HttpResponseMessage response = await client.GetAsync(versionUri);
            if (response.IsSuccessStatusCode)
            {
                ValidationMessage = "Success! Connection to the server established.";
                IsNotError = true;
            }
            else
            {
                ValidationMessage = $"Error. Server response: {(int)response.StatusCode} {response.ReasonPhrase}";
                IsNotError = false;
            }
        }
        catch (Exception ex)
        {
            ValidationMessage = $"Error. Failed to connect: {ex.Message}";
            IsNotError = false;
        }
    }
}