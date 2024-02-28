using SQLite;

namespace ROI_HR_Management;


public partial class Settings : ContentPage
{
    //Data that you don't want exposed.
    private SQLiteAsyncConnection _database;
    public SettingsViewModel ViewModel { get; set; }

    public Settings()
    {
        InitializeComponent();
        ViewModel = new SettingsViewModel();
        BindingContext = ViewModel;

        
        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "settings.db");
        _database = new SQLiteAsyncConnection(databasePath);
        _database.CreateTableAsync<UserSet>().Wait();
        

        // Load the user settings
        LoadUserSettings();
    }

    private async void SaveSettings_Clicked(object sender, EventArgs e)
    {
        
        bool theme = togTheme.IsToggled;


        var userSettings = new UserSet
        {

            lightOrDark = theme,

            SavedFontSize = ViewModel.FontSize,
            SavedBrightness = ViewModel.Brightness,
            SavedFontFamily = ViewModel.SelectedFontFamily,
            SavedProfile = ViewModel.SelectedProfile,
        };

        await _database.InsertOrReplaceAsync(userSettings);

        // Show a confirmation message
        await DisplayAlert("Success", "User settings saved", "OK");
    } 

    //PART of the database services
    //Onloading OR onAppearing for settings adjustments.
    private async void LoadUserSettings() 
    {
        // Check if the user settings already exist in the database
        var existingSettings = await _database.Table<UserSet>().FirstOrDefaultAsync();
        if (existingSettings != null)
        {




            fontSizeSlider.Value = (double)existingSettings.SavedFontSize;
            brightnessSlider.Value = (double)existingSettings.SavedBrightness;
            fontFamilyPicker.SelectedItem = existingSettings.SavedFontFamily;
            profilePicker.SelectedItem = existingSettings.SavedProfile;


            if (existingSettings.lightOrDark)
            {
                togTheme.IsToggled = true;
            }
            else
            {
                togTheme.IsToggled = false;
            }

            var currentTheme = existingSettings.lightOrDark;
            if (currentTheme)
                Application.Current.UserAppTheme = AppTheme.Dark;
            else
                Application.Current.UserAppTheme = AppTheme.Light;
        }
    }



    //PREFERENCES
    //SWITCH: https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/switch
    private void OnThemeSwitchToggled(object sender, ToggledEventArgs e)
    {
        bool isDarkTheme = e.Value;
        Preferences.Set("DarkThemeOn", isDarkTheme ? "Dark" : "Light");

        // Apply the theme
        if (isDarkTheme)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }
}