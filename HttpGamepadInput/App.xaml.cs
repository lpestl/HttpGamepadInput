using System.Diagnostics;

namespace HttpGamepadInput;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
    
    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Exception? ex = e.ExceptionObject as Exception;
        Debug.WriteLine($"[UNHANDLED] {ex?.Message}");
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Application.Current?.MainPage?.DisplayAlert("Error", $"[UNHANDLED] {ex?.Message}", "OK");
        });
    }

    private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
    {
        Debug.WriteLine($"[TASK ERROR] {e.Exception.Message}");
        e.SetObserved();
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Application.Current?.MainPage?.DisplayAlert("Task error", $"[TASK ERROR] {e.Exception.Message}", "OK");
        });
    }
}