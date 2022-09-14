using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class Program
{
    public static async System.Threading.Tasks.Task Main()
    {
        // Hint: change `DESKTOP-123ABC\SQLEXPRESS` to your server name
        //       alternatively use `localhost` or `localhost\SQLEXPRESS`

        string connectionString = @"Data Source=DESKTOP-IJAHE4J;Initial Catalog=blogdb;Integrated Security=True";

        using (DBContext db = new DBContext(connectionString))
        {
            Console.WriteLine($"Database ConnectionString: {db.ConnectionString}.");

            // Create
            Console.WriteLine("Making a new johnDoe");

            db.Add(new User { Name="John Doe" });
            await db.SaveChangesAsync();

            // Read
            Console.WriteLine("Querying for a blog");

            User user = await db.Users
                .OrderBy(b => b.Id)
                .FirstAsync();

            // Update
            Console.WriteLine("Updating johnDoe ");

            Console.WriteLine("Updating a role, and giving first assignment");

            db.Add(new Role { Title = "Chieftan" });
            db.Add(new Task { Title = "Job to do", Content = "Clean Your New Office" });

            user.Name = user.Name + "Junior";
            user.RoleId = user.RoleId + 1;
            user.TaskId = user.RoleId + 1;
            Console.WriteLine(user.RoleId +" "+ user.TaskId);
            

            await db.SaveChangesAsync();

            // Delete
            Console.WriteLine("Delete johnDoe");

            db.Remove(user);
            await db.SaveChangesAsync();

            Console.ReadLine();
        }
    }
}