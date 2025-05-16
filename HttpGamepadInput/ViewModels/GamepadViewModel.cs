using System.Windows.Input;
using System.Diagnostics;
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

    #region ~ Commands implementstions ~
    
    private void OnUpButtonPressed()
    {
        Debug.WriteLine("[INFO] UP pressed");
    }
    
    private void OnUpButtonReleased()
    {
        Debug.WriteLine("[INFO] UP released");
    }
    
    private void OnDownButtonPressed()
    {
        Debug.WriteLine("[INFO] DOWN pressed");
    }
    
    private void OnDownButtonReleased()
    {
        Debug.WriteLine("[INFO] DOWN released");
    }
    
    private void OnLeftButtonPressed()
    {
        Debug.WriteLine("[INFO] LEFT pressed");
    }
    
    private void OnLeftButtonReleased()
    {
        Debug.WriteLine("[INFO] LEFT released");
    }
    
    private void OnRightButtonPressed()
    {
        Debug.WriteLine("[INFO] RIGHT pressed");
    }
    
    private void OnRightButtonReleased()
    {
        Debug.WriteLine("[INFO] RIGHT released");
    }

    private void OnCenterButtonPressed()
    {
        Debug.WriteLine("[INFO] MIDDLE pressed");
    }

    private void OnCenterButtonReleased()
    {
        Debug.WriteLine("[INFO] MIDDLE released");
    }

    private void OnStartButtonPressed()
    {
        Debug.WriteLine("[INFO] START pressed");
    }

    private void OnStartButtonReleased()
    {
        Debug.WriteLine("[INFO] START released");
    }

    private void OnSelectButtonPressed()
    {
        Debug.WriteLine("[INFO] SELECT pressed");
    }

    private void OnSelectButtonReleased()
    {
        Debug.WriteLine("[INFO] SELECT released");
    }

    private void OnAButtonPressed()
    {
        Debug.WriteLine("[INFO] A pressed");
    }

    private void OnAButtonReleased()
    {
        Debug.WriteLine("[INFO] A released");
    }

    private void OnBButtonPressed()
    {
        Debug.WriteLine("[INFO] B pressed");
    }

    private void OnBButtonReleased()
    {
        Debug.WriteLine("[INFO] B released");
    }

    #endregion
}