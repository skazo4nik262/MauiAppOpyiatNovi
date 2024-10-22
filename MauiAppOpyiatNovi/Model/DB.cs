using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi.Model
{
    public class DB
    {
        DBCont context = new DBCont("MyFistingDB");
        private static DB instance;

        public DB()
        {
            var a = new Student() { FIO = "123", Birthday = "123", IsBoy = true, Address = "123", GroupId = 1 };
            context.Database.EnsureDeletedAsync();
            context.Database.EnsureCreatedAsync();
            context.Users.Add(new User() { Login = "123", Password = "123" });
            context.Students.Add(new Student(a));
            context.Groups.Add(new Group() { Number = "1135", Students = new List<Student>() { new Student(a) } });
        }
        public static DB Instance { get { return instance ??= new DB(); } }
        public async Task<bool> AddStudent(Student student)
        {
            var localStudent = new Student(student);
            if (localStudent != null)
            {
                await context.Students.AddAsync(localStudent);
                context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
        public async Task<bool> DeleteStudent(Student student)
        {
            var localStudent = await context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
            if (localStudent != null)
            {
                context.Students.Remove(localStudent);
                await context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
        public async Task<bool> EditStudent(Student student)
        {
            var localStudent = await context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
            if (localStudent != null)
            {
                context.Entry(localStudent).CurrentValues.SetValues(student);
                await context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
