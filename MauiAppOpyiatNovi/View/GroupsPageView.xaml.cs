using MauiAppOpyiatNovi.ViewModel;

namespace MauiAppOpyiatNovi.View;

public partial class GroupsPageView : ContentPage
{
	public GroupsPageView()
	{
		InitializeComponent();
	}
    protected override void OnAppearing() => ((GroupsPageVM)BindingContext).OnAppearing();
    protected override void OnDisappearing() => ((GroupsPageVM)BindingContext).OnDisapperaing();
}