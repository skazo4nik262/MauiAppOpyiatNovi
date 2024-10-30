using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi.ViewModel
{
    public class GroupsPageVM : BaseVM
    {
        private List<Group> groups = new List<Group>();

        public List<Group> Groups { get => groups; set { groups = value; Signal(); } }
        public VmCommand AddEditGroup { get; set; }
        public VmCommand DeleteGroup { get; set; }
        public Group SelectedGroup { get; set; } = new();
        public Student SelectedStudent { get; set; } = new();
    }
}
