using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ROI_HR_Management;

public partial class EmployeeRecords : ContentPage
{

    private DatabaseService _databaseServiceSQL;

    private List<Employee> _employees;

    public EmployeeRecords()
	{
		InitializeComponent();

        //Initialize the database service for SQLite
        _databaseServiceSQL = new DatabaseService();


        //Load Employees
        LoadEmployeesAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Load Employees from the database 
        LoadEmployeesAsync();
    }

    private async void UpdateEmployee_Clicked(object sender, EventArgs e)
    {
        var selectedEmployee = (Employee)((Button)sender).BindingContext;

       
        await Navigation.PushAsync(new UpdateEmployee(selectedEmployee, _databaseServiceSQL));
    }

    private async void DeleteEmployee_Clicked(object sender, EventArgs e)
    {
        var selectedEmployee = (Employee)((Button)sender).BindingContext;
        bool result = await DisplayAlert("Delete Employee", "Are you sure you want to delete this Employee?", "Yes", "No");

        if (result)
        {
            
            await _databaseServiceSQL.DeleteEmployeeAsync(selectedEmployee);


            await DisplayAlert("Delete Employee", "You Deleted a Employee", "Ok");

            LoadEmployeesAsync();
        }
    }

    private async void ViewDetails_Clicked(object sender, EventArgs e)
    {
        var selectedEmployee = (Employee)((Button)sender).BindingContext;
        await Navigation.PushAsync(new EmployeeDetails(selectedEmployee));
    }

    private async void LoadEmployeesAsync()
    {
        try
        {
            
            _employees = await _databaseServiceSQL.GetEmployeesAsync();

    


            EmployeeListView.ItemsSource = _employees;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex}");
        }
    }

}