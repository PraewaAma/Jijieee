using SQLiteDemo.Repositories;

namespace SQLiteDemo;

public partial class App : Application
{
    internal static object _studentRepo;

    //public static StudentRepository _studentRepo {get ; set;}
    public static StudentRepository _carRepo {get ; set;}
	//public App.App(StudentRepository studentRepo);
	public App(CarRepository carRepo)
	
	{
		InitializeComponent();

		//_studentRepo = studentRepo;
		_carRepo = carRepo;

		//MainPage = new AppShell();
		//MainPage = new StudentPage();
		MainPage = new CarPage();
	}
}