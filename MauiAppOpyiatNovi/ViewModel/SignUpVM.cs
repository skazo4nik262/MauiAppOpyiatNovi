using MauiAppOpyiatNovi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi.ViewModel
{
    public class SignUpVM
    {
        private List<User> Users { get; set; } = new();
        public User User { get; set; } = new();

        public VmCommand SignUp { get; set; }
        public VmCommand Back { get; set; }

        public SignUpVM()
        {

            SignUp = new VmCommand(async () => await SignUpMethod());
            Back = new VmCommand(async () => await Shell.Current.GoToAsync("//LoginPage"));
        }

        private async Task SignUpMethod()
        {
            if (User != null)
            {
                await DB.Instance.AddUser(User);
                await Shell.Current.GoToAsync("//LoginPage");
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            }
            else await Application.Current.MainPage.DisplayAlert("User is empty", "No Login or Password", "Ok");
        }

        public void OnAppearing()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }
    }
}