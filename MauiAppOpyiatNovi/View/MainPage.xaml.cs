namespace MauiAppOpyiatNovi.View;
using MauiAppOpyiatNovi.Model;
using MauiAppOpyiatNovi.ViewModel;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    protected override void OnAppearing() => ((MainPageVM)BindingContext).OnAppearing();

    private async void SignInClick(object sender, EventArgs e)
    {
        
        Users = await DB.Instance.GetUsers();
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