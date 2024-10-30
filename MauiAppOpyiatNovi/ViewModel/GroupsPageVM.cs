using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppOpyiatNovi.Model;

namespace MauiAppOpyiatNovi.ViewModel
{
    public class GroupsPageVM : BaseVM
    {
        private List<Group> groups = new List<Group>();

        public List<Group> Groups { get => groups; set { groups = value; Signal(); } }
        public VmCommand AddEditGroup { get; set; }
        public VmCommand DeleteGroup { get; set; }
        public Group SelectedGroup { get; set; } = new();

        public GroupsPageVM()
        {
            NewMethod();
            AddEditGroup = new VmCommand(async () => await AddStudentMethod());
            DeleteGroup = new VmCommand(async () => DeleteStudentMethod());
        }
        public async Task AddStudentMethod()
        {
            ShellNavigationQueryParameters keyValuePairs = new ShellNavigationQueryParameters();
            if (SelectedGroup == null)
                keyValuePairs.Add("Student", new Student());
            else
                keyValuePairs.Add("Student", SelectedGroup);
            await Shell.Current.GoToAsync("//StudentAddServices", keyValuePairs);
        }
        public async Task DeleteStudentMethod()
        {
            await DB.Instance.DeleteGroup(SelectedGroup);
            NewMethod();
        }

        private async Task NewMethod()
        {
            Groups = await DB.Instance.GetAllGroups();
        }
        public void OnAppearing()
        {
            NewMethod();
        }

        internal void OnDisapperaing()
        {
            SelectedStudent = null;
        }
    }
}
