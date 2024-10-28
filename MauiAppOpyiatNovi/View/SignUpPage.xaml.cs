using MauiAppOpyiatNovi.ViewModel;

namespace MauiAppOpyiatNovi.View;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing() => ((SignUpVM)BindingContext).OnAppearing();
}