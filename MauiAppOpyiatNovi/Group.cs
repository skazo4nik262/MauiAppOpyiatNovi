using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi
{
    public class Group
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
