using System.Windows.Input;

namespace HttpGamepadInput.BaseClasses;

public class ButtonPressBehavior : Behavior<Button>
{
    public static readonly BindableProperty PressedCommandProperty =
        BindableProperty.Create(nameof(PressedCommand), typeof(ICommand), typeof(ButtonPressBehavior));

    public static readonly BindableProperty ReleasedCommandProperty =
        BindableProperty.Create(nameof(ReleasedCommand), typeof(ICommand), typeof(ButtonPressBehavior));

    public ICommand PressedCommand
    {
        get => (ICommand)GetValue(PressedCommandProperty);
        set => SetValue(PressedCommandProperty, value);
    }

    public ICommand ReleasedCommand
    {
        get => (ICommand)GetValue(ReleasedCommandProperty);
        set => SetValue(ReleasedCommandProperty, value);
    }

    protected override void OnAttachedTo(Button bindable)
    {
        base.OnAttachedTo(bindable);
        bindable.BindingContextChanged += OnBindingContextChanged;
        bindable.Pressed += OnPressed;
        bindable.Released += OnReleased;
    }

    protected override void OnDetachingFrom(Button bindable)
    {
        base.OnDetachingFrom(bindable);
        bindable.BindingContextChanged -= OnBindingContextChanged;
        bindable.Pressed -= OnPressed;
        bindable.Released -= OnReleased;
    }
    
    private void OnBindingContextChanged(object? sender, EventArgs e)
    {
        if (sender is Button button)
        {
            BindingContext = button.BindingContext;
        }
    }

    private void OnPressed(object? sender, EventArgs e)
    {
        if (PressedCommand?.CanExecute(null) == true)
            PressedCommand.Execute(null);
    }

    private void OnReleased(object? sender, EventArgs e)
    {
        if (ReleasedCommand?.CanExecute(null) == true)
            ReleasedCommand.Execute(null);
    }
}