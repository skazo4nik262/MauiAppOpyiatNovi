using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            context.SaveChanges();
            var b =context.Students.ToList();
        }
        public static DB Instance { get { return instance ??= new DB(); } }

        //-----------------------------Студенты начались-----------------------------\\
        public async Task<bool> AddStudent(Student student)
        {
            var localStudent = new Student(student);
            localStudent.GroupId = 1;
            if (localStudent != null)
            {
                await context.Students.AddAsync(localStudent);
                await context.SaveChangesAsync();
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
                context.SaveChanges();
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
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        public async Task<List<Student>> GetAllStudents()
        {
            return await context.Students.ToListAsync();
        }
        //-----------------------------Студенты кончились-----------------------------\\



        //-----------------------------Группы начались-----------------------------\\
        public async Task<bool> AddGroup(Group group)
        {
            var localGroup = new Group(group);
            if (localGroup != null)
            {
                foreach (var student in localGroup.Students)
                    student.GroupId = group.Id;
                await context.Groups.AddAsync(localGroup);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        public async Task<bool> DeleteGroup(Group group)
        {
            var localGroup = await context.Groups.FirstOrDefaultAsync(s => s.Id == group.Id);
            if (localGroup != null)
            {
                context.Groups.Remove(localGroup);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        public async Task<bool> EditGroup(Group group)
        {
            var localGroup = await context.Groups.FirstOrDefaultAsync(s => s.Id == group.Id);
            if (localGroup != null)
            {
                foreach (var student in localGroup.Students)
                    student.GroupId = group.Id;
                context.Entry(localGroup).CurrentValues.SetValues(group);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        public async Task<List<Group>> GetAllGroups()
        {
            return await context.Groups.ToListAsync();
        }
        //-----------------------------Группы кончились-----------------------------\\



        //-----------------------------Пользователи начались-----------------------------\\
        public async Task<bool> AddUser(User user)
        {
            var localUser = new User(user);
            if (localUser != null)
            {
                await context.Users.AddAsync(localUser);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        public async Task<bool> DeleteUser(User user)
        {
            var localUser = await context.Users.FirstOrDefaultAsync(s => s.Id == user.Id);
            if (localUser != null)
            {
                context.Users.Remove(localUser);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        public async Task<bool> EditUser(User user)
        {
            var localUser = await context.Users.FirstOrDefaultAsync(s => s.Id == user.Id);
            if (localUser != null)
            {
                context.Entry(localUser).CurrentValues.SetValues(user);
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var a = await context.Users.ToListAsync();
            return a;
        }
        //-----------------------------Пользователи кончились-----------------------------\\
    }
}
