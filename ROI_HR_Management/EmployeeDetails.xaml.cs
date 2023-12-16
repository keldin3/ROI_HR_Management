namespace ROI_HR_Management;

public partial class EmployeeDetails : ContentPage
{
    public EmployeeDetails(Employee employee)
    {
        InitializeComponent();
        BindingContext = employee;
    }
}