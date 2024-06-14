using M3Connect.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace M3Connect.Db
{
    public class DatabaseContext : DbContext
    {
        //доступ к таблицам в данном случае таблице контракт
        public DbSet<Contract> Contracts { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated(); //создаем бд при первом обращении 
        }

    }
}
