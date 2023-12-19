using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ROI_HR_Management
{

    public partial class AddEmployee : ContentPage
    {
        //Database service to perform CRUD operations
        private DatabaseService _databaseServiceSQL;

        private List<Employee> _employees;

        public AddEmployee()
        {
            InitializeComponent();

            //Initialize the database service for SQLite
            _databaseServiceSQL = new DatabaseService();


        }

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

            

            bool result = await DisplayAlert("Add Employee", "Are you sure you want to add this Employee?", "Yes", "No");

            if (result)
            {
                //SQLite Version
                await _databaseServiceSQL.AddEmployeeAsync(newEmployee);


                await DisplayAlert("Add Employee", "Employee Added", "Ok");

               
            }

            //Resets input fields and clears user input
            NameEntry.Text = PhoneEntry.Text = DepartmentEntry.Text = AddressStreetEntry.Text = AddressCityEntry.Text = AddressStateEntry.Text = AddressZipEntry.Text = CountryEntry.Text = string.Empty;
           
            


        }

    }

}