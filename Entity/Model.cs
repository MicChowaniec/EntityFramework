using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class DBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public string ConnectionString { get; }
    public object Blog { get; internal set; }

    public DBContext(string connectionString)
    {
        this.ConnectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(this.ConnectionString);
    }
}

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }

   // [ForeignKey("RoleId")]
    public long? RoleId { get; set; }

    //[ForeignKey("TaskId")]
    public long? TaskId { get; set; }
}

public class Role
{
   // [ForeignKey("RoleId")]
    public long RoleId { get; set; }
    public string? Title { get; set; }


}


public class Task
{
   // [ForeignKey("TaskId")]
    public long TaskId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
}
