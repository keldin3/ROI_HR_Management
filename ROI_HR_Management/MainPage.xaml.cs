using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ROI_HR_Management
{
    public partial class MainPage : ContentPage
    {
        //Database service to perform CRUD operations
        private DatabaseService _databaseServiceSQL;

        private List<Employee> _employees;

        public MainPage()
        {
            InitializeComponent();

            //Initialize the database service for SQLite
            _databaseServiceSQL = new DatabaseService();


            //Manual clear
            //_databaseServiceSQL.ClearDatabase();

            //Load Employees
            LoadEmployeesAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Load students from the database every time the page appears
            LoadEmployeesAsync();
        }

        private async void UpdateEmployee_Clicked(object sender, EventArgs e)
        {
            var selectedEmployee = (Employee)((Button)sender).BindingContext;
            //Added CSV -> sends both database services 
            await Navigation.PushAsync(new UpdateEmployee(selectedEmployee, _databaseServiceSQL));
        }

        private async void DeleteEmployee_Clicked(object sender, EventArgs e)
        {
            var selectedEmployee = (Employee)((Button)sender).BindingContext;
            bool result = await DisplayAlert("Delete Employee", "Are you sure you want to delete this Employee?", "Yes", "No");

            if (result)
            {
                //SQLiteVersion
                await _databaseServiceSQL.DeleteEmployeeAsync(selectedEmployee);

                //CSV Version
                //await _databaseServiceCSV.DeleteEmployeeAsync(selectedEmployee);

                //await DisplayAlert("Delete Student", "You Deleted a student", "Ok");
                // Reload the students list after deletion
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
                //SQLite Version
                _employees = await _databaseServiceSQL.GetEmployeesAsync();

                //await DisplayAlert("Loading Students", "Loading Check", "Ok");


                EmployeeListView.ItemsSource = _employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }


        //Visual bug, Consider moving to new Add Employee page.
        private async void AddEmployee_Clicked(object sender, EventArgs e)
        {
            var newEmployee = new Employee
            {
                Name = NameEntry.Text,
                Phone = PhoneEntry.Text,
                Department = DepartmentEntry.Text,
                AddressStreet = AddressStreetEntry.Text,
                AddressCity = AddressCityEntry.Text,
                AddressState = AddressStateEntry.Text,
                AddressZip = AddressZipEntry.Text,
                Country = CountryEntry.Text,
                
            };

            //SQLite Version
            await _databaseServiceSQL.AddEmployeeAsync(newEmployee);

            //CSV Version
            //await _databaseServiceCSV.AddEmployeeAsync(newStudent);

            //Un-comment for pop-ups/troubleshooting
            //await DisplayAlert("Add Employee","You Added a Employee","Ok");

            NameEntry.Text = PhoneEntry.Text = DepartmentEntry.Text = string.Empty;
            LoadEmployeesAsync();

            //Add UI refresh command here
        }
    }
}

