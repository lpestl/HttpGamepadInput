using System.Windows.Input;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using HttpGamepadInput.BaseClasses;

namespace HttpGamepadInput.ViewModels;

public class GamepadViewModel : BindableBase
{
    #region ~ Commands Properties ~
    // D-Pad commands
    public ICommand UpButtonPressedCommand { get; }
    public ICommand UpButtonReleasedCommand { get; }
    
    public ICommand DownButtonPressedCommand { get; }
    public ICommand DownButtonReleasedCommand { get; }
    
    public ICommand LeftButtonPressedCommand { get; }
    public ICommand LeftButtonReleasedCommand { get; }
    
    public ICommand RightButtonPressedCommand { get; }
    public ICommand RightButtonReleasedCommand { get; }
    
    public ICommand CenterButtonPressedCommand { get; }
    public ICommand CenterButtonReleasedCommand { get; }
    
    // Start/Select commands
    public ICommand StartButtonPressedCommand { get; }
    public ICommand StartButtonReleasedCommand { get; }
    
    public ICommand SelectButtonPressedCommand { get; }
    public ICommand SelectButtonReleasedCommand { get; }
    
    // A / B commands
    public ICommand AButtonPressedCommand { get; }
    public ICommand AButtonReleasedCommand { get; }
    
    public ICommand BButtonPressedCommand { get; }
    public ICommand BButtonReleasedCommand { get; }

    #endregion

    private HttpClient _client = new HttpClient();
    
    private string _serverUrl = "http://127.0.0.1:8080/";
    public string ServerUrl
    {
        get => _serverUrl;
        set
        {
            if (SetProperty(ref _serverUrl, value))
            {
                UpdateHttpClient();
            }
        }
    }

    #region ~ Constructor ~
    public GamepadViewModel()
    {
        UpButtonPressedCommand = new Command(OnUpButtonPressed);
        UpButtonReleasedCommand = new Command(OnUpButtonReleased);
    
        DownButtonPressedCommand = new Command(OnDownButtonPressed);
        DownButtonReleasedCommand = new Command(OnDownButtonReleased);
    
        LeftButtonPressedCommand = new Command(OnLeftButtonPressed);
        LeftButtonReleasedCommand = new Command(OnLeftButtonReleased);
    
        RightButtonPressedCommand = new Command(OnRightButtonPressed);
        RightButtonReleasedCommand = new Command(OnRightButtonReleased);
    
        CenterButtonPressedCommand = new Command(OnCenterButtonPressed);
        CenterButtonReleasedCommand = new Command(OnCenterButtonReleased);
    
        StartButtonPressedCommand = new Command(OnStartButtonPressed);
        StartButtonReleasedCommand = new Command(OnStartButtonReleased);
    
        SelectButtonPressedCommand = new Command(OnSelectButtonPressed);
        SelectButtonReleasedCommand = new Command(OnSelectButtonReleased);
    
        AButtonPressedCommand = new Command(OnAButtonPressed);
        AButtonReleasedCommand = new Command(OnAButtonReleased);
    
        BButtonPressedCommand = new Command(OnBButtonPressed);
        BButtonReleasedCommand = new Command(OnBButtonReleased);
    }
    #endregion

    private void UpdateHttpClient()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(ServerUrl)
        };
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task PostButtonStatus(string relativeUrl)
    {
        var content = new StringContent("{}", Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _client.PostAsync(relativeUrl, content);
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"Response from {relativeUrl}: {responseBody}");
        }
        else
        {
            Debug.WriteLine($"Error posting to {relativeUrl}: {response.StatusCode}");
        }
    }
    
    #region ~ Commands implementstions ~
    
    private async void OnUpButtonPressed()
    {
        Debug.WriteLine("[INFO] UP pressed");
        await PostButtonStatus("up/pressed");
    }
    
    private async void OnUpButtonReleased()
    {
        Debug.WriteLine("[INFO] UP released");
        await PostButtonStatus("up/released");
    }
    
    private async void OnDownButtonPressed()
    {
        Debug.WriteLine("[INFO] DOWN pressed");
        await PostButtonStatus("down/pressed");
    }
    
    private async void OnDownButtonReleased()
    {
        Debug.WriteLine("[INFO] DOWN released");
        await PostButtonStatus("down/released");
    }
    
    private async void OnLeftButtonPressed()
    {
        Debug.WriteLine("[INFO] LEFT pressed");
        await PostButtonStatus("left/pressed");
    }
    
    private async void OnLeftButtonReleased()
    {
        Debug.WriteLine("[INFO] LEFT released");
        await PostButtonStatus("left/released");
    }
    
    private async void OnRightButtonPressed()
    {
        Debug.WriteLine("[INFO] RIGHT pressed");
        await PostButtonStatus("right/pressed");
    }
    
    private async void OnRightButtonReleased()
    {
        Debug.WriteLine("[INFO] RIGHT released");
        await PostButtonStatus("right/released");
    }

    private async void OnCenterButtonPressed()
    {
        Debug.WriteLine("[INFO] MIDDLE pressed");
        await PostButtonStatus("center/pressed");
    }

    private async void OnCenterButtonReleased()
    {
        Debug.WriteLine("[INFO] MIDDLE released");
        await PostButtonStatus("center/released");
    }

    private async void OnStartButtonPressed()
    {
        Debug.WriteLine("[INFO] START pressed");
        await PostButtonStatus("start/pressed");
    }

    private async void OnStartButtonReleased()
    {
        Debug.WriteLine("[INFO] START released");
        await PostButtonStatus("start/released");
    }

    private async void OnSelectButtonPressed()
    {
        Debug.WriteLine("[INFO] SELECT pressed");
        await PostButtonStatus("select/pressed");
    }

    private async void OnSelectButtonReleased()
    {
        Debug.WriteLine("[INFO] SELECT released");
        await PostButtonStatus("select/released");
    }

    private async void OnAButtonPressed()
    {
        Debug.WriteLine("[INFO] A pressed");
        await PostButtonStatus("a-button/pressed");
    }

    private async void OnAButtonReleased()
    {
        Debug.WriteLine("[INFO] A released");
        await PostButtonStatus("a-button/released");
    }

    private async void OnBButtonPressed()
    {
        Debug.WriteLine("[INFO] B pressed");
        await PostButtonStatus("b-button/pressed");
    }

    private async void OnBButtonReleased()
    {
        Debug.WriteLine("[INFO] B released");
        await PostButtonStatus("b-button/released");
    }

    #endregion
}