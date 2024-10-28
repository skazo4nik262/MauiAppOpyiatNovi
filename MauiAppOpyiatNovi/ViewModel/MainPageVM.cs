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
        private List<User> Users { get; set; }
        public VmCommand SignIn { get; set; }
        public MainPageVM()
        {
            SignIn = new VmCommand(async () =>
            {
                Users = await DB.Instance.GetAllUsers();
            });
        }

        internal void OnAppearing()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }
    }
}
