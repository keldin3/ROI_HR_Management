using SQLite;

namespace ROI_HR_Management;
/// <summary>
/// This is the user setting data model
/// </summary>
public class UserSet
{

    public bool lightOrDark { get; set; } //Toggle theme

    

    //These viewmodel settings
    public int SavedFontSize { get; set; }
    public float SavedBrightness { get; set; }
    public string SavedFontFamily { get; set; }
    public string SavedProfile { get; set; }

}
