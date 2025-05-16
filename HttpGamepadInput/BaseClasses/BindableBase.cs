using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace HttpGamepadInput.BaseClasses;

public class BindableBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Call event PropertyChanged.
    /// </summary>
    /// <param name="propertyName">Property name.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Updateing field and call OnPropertyChanged, if it changed.
    /// </summary>
    /// <typeparam name="T">Property type.</typeparam>
    /// <param name="storage">Field reference.</param>
    /// <param name="value">New value.</param>
    /// <param name="propertyName">Property name (auto compiler setup).</param>
    /// <returns>true, if field value changed, else false.</returns>
    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(storage, value))
            return false;

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}