namespace ROI_HR_Management;

public partial class UpdateEmployee : ContentPage
{
    private Employee _selectedEmployee;
    private DatabaseService _databaseServiceSQL;


    public UpdateEmployee(Employee selectedEmployee, DatabaseService databaseService) //DatabaseService databaseService
    {
        InitializeComponent();
        //Pass Employee
        _selectedEmployee = selectedEmployee;

        //Pass database servicer
        //SQLite Passed
        _databaseServiceSQL = databaseService;

        // Populate the input fields with the existing Employee details
        NameEntry.Text = _selectedEmployee.Name;
        PhoneEntry.Text = _selectedEmployee.Phone;
        DepartmentEntry.Text = _selectedEmployee.Department;
        AddressStreetEntry.Text = _selectedEmployee.AddressStreet;
        AddressCityEntry.Text = _selectedEmployee.AddressCity; 
        AddressStateEntry.Text = _selectedEmployee.AddressState;    
        AddressZipEntry.Text = _selectedEmployee.AddressZip;    
        CountryEntry.Text = _selectedEmployee.Country;  

    }

    private async void Update_Clicked(object sender, EventArgs e)
    {
        // Update the selected student's information
        _selectedEmployee.Name = NameEntry.Text;
        _selectedEmployee.Phone = PhoneEntry.Text;
        _selectedEmployee.Department = DepartmentEntry.Text;
        _selectedEmployee.AddressStreet = AddressStreetEntry.Text;
        _selectedEmployee.AddressCity = AddressCityEntry.Text;
        _selectedEmployee.AddressState = AddressStateEntry.Text;
        _selectedEmployee.AddressZip = AddressZipEntry.Text;
        _selectedEmployee.Country = CountryEntry.Text;
        

        //SQLite Version
        // Call the database service to update the student
        await _databaseServiceSQL.UpdateEmployeeAsync(_selectedEmployee);

        // Navigate back to the previous page
        await Navigation.PopAsync();
    }
}
