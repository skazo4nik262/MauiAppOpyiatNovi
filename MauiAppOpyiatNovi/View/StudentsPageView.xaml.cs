using MauiAppOpyiatNovi.ViewModel;

namespace MauiAppOpyiatNovi.View;

public partial class StudentsPageView : ContentPage
{
	public StudentsPageView()
	{
		InitializeComponent();
	}
    protected override void OnAppearing() => ((StudentPageVM)BindingContext).OnAppearing();
    protected override void OnDisappearing() => ((StudentPageVM)BindingContext).OnDisapperaing();
}