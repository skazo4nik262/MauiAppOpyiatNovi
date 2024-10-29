using MauiAppOpyiatNovi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi.ViewModel
{
    public class StudentAddVM
    {
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
        public Student Student { get; set; } = new Student();
        public VmCommand Save { get; set; }

    }
}
