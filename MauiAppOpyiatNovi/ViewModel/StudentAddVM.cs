using MauiAppOpyiatNovi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi.ViewModel
{
    [QueryProperty(nameof(Student), "Student")]
    public class StudentAddVM:BaseVM
    {
        private Student student = new Student();

        public Student Student { get => student; set { student = value; Signal(); } }
        public VmCommand Save { get; set; }

        public StudentAddVM()
        {
            Save = new VmCommand(async () =>
            {
                if (Student.Id == 0)
                    await DB.Instance.AddStudent(Student);
                else
                    await DB.Instance.EditStudent(Student);
                Shell.Current.GoToAsync("//StudentsPage");
            });
        }

        
    }
}
