namespace MauiAppOpyiatNovi.View;

public partial class MainPage : ContentPage
{
	public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private int errorCount = 0;
        private bool disableSignUpButton = false;

        public 

        protected override void OnAppearing() => Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;

        public bool DisableSignUpButton { get => disableSignUpButton; set { disableSignUpButton = value; OnPropertyChanged(nameof(DisableSignUpButton)); } }
        private async void SignInClick(object sender, EventArgs e)
        {
            if (errorCount > 1)
            {
                DisableSignUpButton = true;
            }
            Users = await DbNoEntity.Instance.GetUsers();
            var user = Users.FirstOrDefault(s => s.Login == User.Login && s.Password == User.Password);
            if (user != null)
            {
                await Shell.Current.GoToAsync("//StudentsPage");
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                errorCount = 0;
            }
            else
            {
                await DisplayAlert("Unknow User", "Wrong Login or Password", "Ok");
                errorCount++;
            }
        }

        private void SignUpClick(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//RegistrPage");
        }
    }