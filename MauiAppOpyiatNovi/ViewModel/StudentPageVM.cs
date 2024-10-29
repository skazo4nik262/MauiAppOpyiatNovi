using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppOpyiatNovi.Model;

namespace MauiAppOpyiatNovi.ViewModel
{
    public class StudentPageVM : BaseVM
    {
        private List<Student> students;

        public List<Student> Students { get => students; set { students = value; Signal(); } }
        public VmCommand AddStudent { get; set; }
        public VmCommand EditStudent { get; set; }
        public VmCommand DeleteStudent { get; set; }
        public Student SelectedStudent { get; set; }

        public StudentPageVM()
        {
            NewMethod();
            AddStudent = new VmCommand(async () => await AddStudentMethod());
            EditStudent = new VmCommand(async()=>await AddStudentMethod());
            DeleteStudent = new VmCommand(async () => DeleteStudentMethod());
        }
        public async Task AddStudentMethod()
        {
            ShellNavigationQueryParameters keyValuePairs = new ShellNavigationQueryParameters();
            keyValuePairs.Add("Student", SelectedStudent);
            await Shell.Current.GoToAsync("//StudentAddServices", keyValuePairs);
        }
        public async Task DeleteStudentMethod()
        {
            await DB.Instance.DeleteStudent(SelectedStudent);
            NewMethod();
        }

        private async Task NewMethod()
        {
            Students = await DB.Instance.GetAllStudents();
        }

    }
}
