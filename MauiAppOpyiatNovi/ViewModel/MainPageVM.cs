using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppOpyiatNovi.Model;

namespace MauiAppOpyiatNovi.ViewModel
{
    public class MainPageVM
    {
        private List<User> Users { get; set; } = new();
        public User User { get; set; } = new();

        public VmCommand SignIn { get; set; }
        public VmCommand OpenSignUp { get; set; }

        public MainPageVM()
        {
            SignIn = new VmCommand(async () => await SignInMethod());
            OpenSignUp = new VmCommand(async () =>
            {
                await Shell.Current.GoToAsync("//RegistrPage");
            });
        }

        private async Task SignInMethod()
        {
            Users = await DB.Instance.GetAllUsers();
            var user = Users.FirstOrDefault(s => s.Login == User.Login && s.Password == User.Password);
            if (user != null)
            {
                await Shell.Current.GoToAsync("//StudentsPage");
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            }
            else await Application.Current.MainPage.DisplayAlert("Unknow User", "Wrong Login or Password", "Ok");
        }

        public void OnAppearing()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }
    }
}
