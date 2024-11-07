using SQLiteDemo.MVVM.ViewModels;

namespace SQLiteDemo;

public partial class StudentPage : ContentPage
{
	public StudentPage()
	{
		InitializeComponent();
		BindingContext = new StudentPageViewModel();
	}
}