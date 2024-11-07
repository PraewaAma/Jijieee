using SQLiteDemo.MVVM.ViewModels;

namespace SQLiteDemo;

public partial class CarPage : ContentPage
{
	public CarPage()
	{
		InitializeComponent();
		BindingContext = new CarPageViewModel();
	}
}