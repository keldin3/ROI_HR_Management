using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ROI_HR_Management
{
 


    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AddEmployeeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEmployee());
        }

        private async void EmployeeRecordsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeeRecords());
        }
    }




}

