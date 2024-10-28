namespace MauiAppOpyiatNovi.View;
using MauiAppOpyiatNovi.Model;
using MauiAppOpyiatNovi.ViewModel;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing() => ((MainPageVM)BindingContext).OnAppearing();
}