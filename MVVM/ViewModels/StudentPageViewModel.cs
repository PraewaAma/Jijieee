using System.Windows.Input;
using PropertyChanged;
using SQLiteDemo.MVVM.Models;

namespace SQLiteDemo.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class StudentPageViewModel
{
    public List<Student> Students { get; set; }
    public Student CurrentStudent { get; set; }
    public ICommand AddOrUpdateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }
    public StudentPageViewModel()
    {
        this.Refresh();
        AddOrUpdateCommand = new Command(async () =>
        {
            App._studentRepo.AddOrUpdate(CurrentStudent);
            Console.WriteLine(App._studentRepo.StatusMessage);
            this.Refresh();
        });

        DeleteCommand = new Command(async () => {
            App._studentRepo.Delete(CurrentStudent.ID);
            this.Refresh();
        });
    }
    private void Refresh()
    {
        CurrentStudent = new Student();

        this.Students = App._studentRepo.GetAll();
    }
}