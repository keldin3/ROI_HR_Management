using System.ComponentModel;

/// <summary>
/// The start of our global settings. This viewmodel will grab changes in realtime to our settings page.
/// Makes the save button either Redundant OR reduces the complexiet of the event
/// </summary>
public class SettingsViewModel : INotifyPropertyChanged //Doesn't Use Communicty Toolkit.
{
    private float _brightness;
    public float Brightness
    {
        get => _brightness;
        set
        {
            _brightness = value;
            OnPropertyChanged(nameof(Brightness));
        }
    }

    private int _fontSize;
    public int FontSize
    {
        get => _fontSize;
        set
        {
            _fontSize = value;
            OnPropertyChanged(nameof(FontSize));
        }
    }

    private List<string> _fontFamilies;
    public List<string> FontFamilies
    {
        get => _fontFamilies;
        set
        {
            _fontFamilies = value;
            OnPropertyChanged(nameof(FontFamilies));
        }
    }

    private string _selectedFontFamily;
    public string SelectedFontFamily
    {
        get => _selectedFontFamily;
        set
        {
            _selectedFontFamily = value;
            OnPropertyChanged(nameof(SelectedFontFamily));
        }
    }

    private List<string> _profile;
    public List<string> Profile
    {
        get => _profile;
        set
        {
            _profile = value;
            OnPropertyChanged(nameof(Profile));
        }
    }

    private string _selectedProfile;
    public string SelectedProfile
    {
        get => _selectedProfile;
        set
        {
            _selectedProfile = value;
            OnPropertyChanged(nameof(SelectedProfile));
        }
    }


    public SettingsViewModel()
    {
        // Initialize default values
        Brightness = 0.5f;
        FontSize = 16;
        FontFamilies = new List<string> { "Trebuchet", "Calibri", "Arial" };
        Profile = new List<string> { "Profile_1", "Profile_2", "Profile_3" };
        SelectedProfile = "Profile_1";
        SelectedFontFamily = "Trebuchet";
    }

    

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
