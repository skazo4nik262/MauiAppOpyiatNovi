using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace MauiAppOpyiatNovi.Model
{
    public class DBCont : DbContext
    {
        private readonly string filename;

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DBCont(string filename)
        {
            this.filename = filename;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Database");
            Directory.CreateDirectory(sqlitePath);
            var fileName = $"{sqlitePath}\f{filename}";
            if (!File.Exists(fileName))
                File.Create(fileName);
            optionsBuilder.UseSqlite($"Data Source={fileName}");
        }
    }
}
