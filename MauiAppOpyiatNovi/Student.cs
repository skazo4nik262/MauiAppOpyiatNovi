using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi
{
    public class Student
    {
        public Student() { }
        public Student(Student student)
        {
            Id = student.Id;
            FIO = student.FIO;
            Birthday = student.Birthday;
            IsBoy = student.IsBoy;
            Address = student.Address;
            GroupId = student.GroupId;
        }
        public int Id { get; set; }//
        public string FIO { get; set; }//
        public string Birthday { get; set; }//
        public bool IsBoy { get; set; }//
        public string Address { get; set; }//
        public int GroupId { get; set; }
        //public Group Group { get;  set; }

        [NotMapped]
        public string Gender { get => IsBoy ? "Мужской" : "Женский"; }
        
    }
}
