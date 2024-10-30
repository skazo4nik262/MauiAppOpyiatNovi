using MauiAppOpyiatNovi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi.ViewModel
{
    [QueryProperty(nameof(Student), "Student")]
    public class StudentAddVM : BaseVM
    {
        private Student student;

        public Student Student
        {
            get => student;
            set
            {
                student = value;
                Signal();
            }
        }
        public VmCommand Save { get; set; }

        public StudentAddVM()
        {
            Save = new VmCommand(async () =>
            {
                await NewMethod();
            });
        }

        private async Task NewMethod()
        {
            if (Student.Id != 0)
                await DB.Instance.EditStudent(Student);
            else
            {
                if (Student.Birthday != null)
                {
                    await DB.Instance.AddStudent(Student);
                }
                else Application.Current.MainPage.DisplayAlert("e", "e", "e");
            }

            Shell.Current.GoToAsync("//StudentsPage");
        }
    }
}
