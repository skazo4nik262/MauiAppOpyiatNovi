using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppOpyiatNovi.Model;

namespace MauiAppOpyiatNovi.ViewModel
{
    [QueryProperty(nameof(Group), "Group")]
    public class GroupAddVM : BaseVM
    {
        private Group group = new Group();

        public Group Group { get => group; set { group = value; Signal(); } }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Student> SelectedStudents { get; set; } = new List<Student>();
        public VmCommand Save { get; set; }
        public GroupAddVM()
        {
            NewMethod1();
            Save = new VmCommand(async () =>
            {
                await NewMethod();
            });
        }

        private async Task NewMethod1()
        {
            Students = await DB.Instance.GetAllStudents();
        }

        private async Task NewMethod()
        {
            Group.Students.AddRange(SelectedStudents);
            if (Group.Id != 0)
                await DB.Instance.EditGroup(Group);
            else
            {
                if (Group.Students != null) await DB.Instance.AddGroup(Group);
                else
                {
                    Group.Students = new List<Student>();
                    await DB.Instance.AddGroup(Group);
                }
            }

            Shell.Current.GoToAsync("//StudentsPage");
        }
    }
}
