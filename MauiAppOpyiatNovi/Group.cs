using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi
{
    public class Group
    {
        public Group() { }
        public Group(Group group)
        {
            Id = group.Id;
            Number = group.Number;
            Students = group.Students;
        }
        public int Id { get; set; }
        public string Number { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
