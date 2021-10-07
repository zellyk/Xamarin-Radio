using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assign1
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private Employee _employee;
        public Employee employee { get => _employee; set
            {
                _employee = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(employee)));
            } }
        public MainPage()
        {
            employee = new Employee();
            InitializeComponent();
            BindingContext = this;
        }

        async private void AddClicked(object sender, EventArgs e)
        {
            var errorMessage = employee.IsValid();

            if(errorMessage != null)
            {
                await DisplayAlert("Alert", errorMessage, "OK");
                return;
            }

            await App.Database.SaveEmployeeAsync(employee);
            employee = new Employee();
        }

        async private void DisplayClicked(object sender, EventArgs e)
        {
            var list = await App.Database.GetEmployeeAsync();
            if (list.Count == 0)
            {
                await DisplayAlert("Alert", "Nothing to show", "Ok");
                return;
            }
            collectionView.ItemsSource = list;
        }
    }
}
