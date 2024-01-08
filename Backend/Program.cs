using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Configure services
builder.Services.AddDbContext<FullStackContext>(options =>
    options.UseSqlite("Datasource=./data.db"));

builder.Services.AddCors(o =>
{
    // Enable CORS
    o.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Auto migration logic
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FullStackContext>();
    dbContext.Database.Migrate();
}


//Endpoint User for method Get all data, Get data use ID, Create or add data user, Update data User, Delete data user

// app.MapGet("/users", async (FullStackContext db) =>
app.MapGet("/users", async (FullStackContext db) => //Field in the name backend context with your name Context (FullStackContext)
    await db.Users.ToListAsync());

// Endpoint to get a single user by id
app.MapGet("/users/{id}", async (int id, FullStackContext db) =>
    await db.Users.FindAsync(id) is User user ? Results.Ok(user) : Results.NotFound());

// Endpoint to create a new user
app.MapPost("/users", async (User user, FullStackContext db) =>
{
 
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});

// Endpoint to update a user
app.MapPut("/users/{id}", async (int id, User updatedUser, FullStackContext db) =>
{
    var user = await db.Users.FindAsync(id);
    if (user is null) return Results.NotFound();

    user.Username = updatedUser.Username;
    user.Password = updatedUser.Password;
    user.Email = updatedUser.Email;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoint to delete a user
app.MapDelete("/users/{id}", async (int id, FullStackContext db) =>
{
    if (await db.Users.FindAsync(id) is User user)
    {
        db.Users.Remove(user);
        await db.SaveChangesAsync();
        return Results.Ok(user);
    }

    return Results.NotFound();
});
// Endpoint to get all reports
app.MapGet("/reports", async (FullStackContext db) =>
    await db.Reports.ToListAsync());

// Endpoint to get a single report by id
app.MapGet("/reports/{id}", async (int id, FullStackContext db) =>
    await db.Reports.FindAsync(id) is Report report ? Results.Ok(report) : Results.NotFound());

// Endpoint to create a new report
app.MapPost("/reports", async (Report report, FullStackContext db) =>
{
    db.Reports.Add(report);
    await db.SaveChangesAsync();
    return Results.Created($"/reports/{report.Id}", report);
});

// Endpoint to update a report
app.MapPut("/reports/{id}", async (int id, Report updatedReport, FullStackContext db) =>
{
    var report = await db.Reports.FindAsync(id);
    if (report is null) return Results.NotFound();

    report.Namerobot = updatedReport.Namerobot;
    report.Date = updatedReport.Date;
    report.Issue = updatedReport.Issue;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoint to delete a report
app.MapDelete("/reports/{id}", async (int id, FullStackContext db) =>
{
    if (await db.Reports.FindAsync(id) is Report report)
    {
        db.Reports.Remove(report);
        await db.SaveChangesAsync();
        return Results.Ok(report);
    }

    return Results.NotFound();
});

// Endpoint to get all robots
app.MapGet("/robots", async (FullStackContext db) =>
    await db.Robots.ToListAsync());

// Endpoint to get a single robot by id
app.MapGet("/robots/{id}", async (int id, FullStackContext db) =>
    await db.Robots.FindAsync(id) is Robot robot ? Results.Ok(robot) : Results.NotFound());

// Endpoint to create a new robot
app.MapPost("/robots", async (Robot robot, FullStackContext db) =>
{
      // Check model validation
 
    db.Robots.Add(robot);
    await db.SaveChangesAsync();
    return Results.Created($"/robots/{robot.Id}", robot);
});

// Endpoint to update a robot
app.MapPut("/robots/{id}", async (int id, Robot updatedRobot, FullStackContext db) =>
{
    var robot = await db.Robots.FindAsync(id);
    if (robot is null) return Results.NotFound();

    robot.RobotName = updatedRobot.RobotName;
    robot.Type = updatedRobot.Type;
    robot.SerialNumber = updatedRobot.SerialNumber;
   
    robot.Image = updatedRobot.Image;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoint to delete a robot
app.MapDelete("/robots/{id}", async (int id, FullStackContext db) =>
{
    if (await db.Robots.FindAsync(id) is Robot robot)
    {
        db.Robots.Remove(robot);
        await db.SaveChangesAsync();
        return Results.Ok(robot);
    }

    return Results.NotFound();
});

// Endpoint to get all robot fixes
app.MapGet("/robotfixes", async (FullStackContext db) =>
    await db.RobotFixes.ToListAsync());

// Endpoint to get a single robot fix by robot name
app.MapGet("/robotfixes/{robotName}", async (string robotName, FullStackContext db) =>
    await db.RobotFixes.FindAsync(robotName) is RobotFix robotFix ? Results.Ok(robotFix) : Results.NotFound());

// Endpoint to create a new robot fix
app.MapPost("/robotfixes", async (RobotFix robotFix, FullStackContext db) =>
{
    db.RobotFixes.Add(robotFix);
    await db.SaveChangesAsync();
    return Results.Created($"/robotfixes/{robotFix.Namerobot}", robotFix);
});

// Endpoint to update a robot fix
app.MapPut("/robotfixes/{robotName}", async (string robotName, RobotFix updatedRobotFix, FullStackContext db) =>
{
    var robotFix = await db.RobotFixes.FindAsync(robotName);
    if (robotFix is null) return Results.NotFound();

    robotFix.Date = updatedRobotFix.Date;
    robotFix.HandleBy = updatedRobotFix.HandleBy;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoint to delete a robot fix
app.MapDelete("/robotfixes/{robotName}", async (string robotName, FullStackContext db) =>
{
    if (await db.RobotFixes.FindAsync(robotName) is RobotFix robotFix)
    {
        db.RobotFixes.Remove(robotFix);
        await db.SaveChangesAsync();
        return Results.Ok(robotFix);
    }

    return Results.NotFound();
});

// Endpoint to get all targets
app.MapGet("/targets", async (FullStackContext db) =>
    await db.Targets.ToListAsync());

// Endpoint to get a single target by id
app.MapGet("/targets/{id}", async (int id, FullStackContext db) =>
    await db.Targets.FindAsync(id) is Target target ? Results.Ok(target) : Results.NotFound());

// Endpoint to create a new target
app.MapPost("/targets", async (Target target, FullStackContext db) =>
{
    db.Targets.Add(target);
    await db.SaveChangesAsync();
    return Results.Created($"/targets/{target.ID}", target);
});

// Endpoint to update a target
app.MapPut("/targets/{id}", async (int id, Target updatedTarget, FullStackContext db) =>
{
    var target = await db.Targets.FindAsync(id);
    if (target is null) return Results.NotFound();

    target.From = updatedTarget.From;
    target.To = updatedTarget.To;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoint to delete a target
app.MapDelete("/targets/{id}", async (int id, FullStackContext db) =>
{
    if (await db.Targets.FindAsync(id) is Target target)
    {
        db.Targets.Remove(target);
        await db.SaveChangesAsync();
        return Results.Ok(target);
    }

    return Results.NotFound();
});

// Endpoint to get all tasks
app.MapGet("/tasks", async (FullStackContext db) =>
    await db.Tasks.ToListAsync());

// Endpoint to get a single task by robot name
app.MapGet("/tasks/{robotName}", async (string robotName, FullStackContext db) =>
    await db.Tasks.FindAsync(robotName) is Task task ? Results.Ok(task) : Results.NotFound());

// Endpoint to create a new task
app.MapPost("/tasks", async (Task task, FullStackContext db) =>
{
    db.Tasks.Add(task);
    await db.SaveChangesAsync();
    return Results.Created($"/tasks/{task.Namerobot}", task);
});

// Endpoint to update a task
app.MapPut("/tasks/{robotName}", async (string robotName, Task updatedTask, FullStackContext db) =>
{
    var task = await db.Tasks.FindAsync(robotName);
    if (task is null) return Results.NotFound();

    task.Date = updatedTask.Date;
    task.TaskName = updatedTask.TaskName;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoint to delete a task
app.MapDelete("/tasks/{robotName}", async (string robotName, FullStackContext db) =>
{
    if (await db.Tasks.FindAsync(robotName) is Task task)
    {
        db.Tasks.Remove(task);
        await db.SaveChangesAsync();
        return Results.Ok(task);
    }

    return Results.NotFound();
});

// Endpoint to get all approvals
app.MapGet("/approvals", async (FullStackContext db) =>
    await db.Approval.ToListAsync());

// Endpoint to get a single approval by id
app.MapGet("/approvals/{id}", async (int id, FullStackContext db) =>
    await db.Approval.FindAsync(id) is Approval approval ? Results.Ok(approval) : Results.NotFound());

// Endpoint to create a new approval
app.MapPost("/approvals", async (Approval approval, FullStackContext db) =>
{
 
    db.Approval.Add(approval);
    await db.SaveChangesAsync();
    return Results.Created($"/approvals/{approval.Id}", approval);
});


// Endpoint to update an approval
app.MapPut("/approvals/{id}", async (int id, Approval updatedApproval, FullStackContext db) =>
{
    var approval = await db.Approval.FindAsync(id);
    if (approval is null) return Results.NotFound();

    approval.NameRobot = updatedApproval.NameRobot;
    approval.Info = updatedApproval.Info;
    approval.Serial_no = updatedApproval.Serial_no;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoint to delete an approval
app.MapDelete("/approvals/{id}", async (int id, FullStackContext db) =>
{
    if (await db.Approval.FindAsync(id) is Approval approval)
    {
        db.Approval.Remove(approval);
        await db.SaveChangesAsync();
        return Results.Ok(approval);
    }

    return Results.NotFound();
});


app.UseCors();
app.Run();

//Register Table
public class FullStackContext : DbContext
{
    public DbSet<User> Users { get; set; } //Table User
        public DbSet<Robot> Robots { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<RobotFix> RobotFixes { get; set; }
    public DbSet<Target> Targets { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Approval> Approval { get; set; }
    public FullStackContext(DbContextOptions<FullStackContext> options) : base(options) { }

}

//Table Name
public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }
}
public class Report 
{
    [Key]
    public int Id { get; set; }
    public string Issue { get; set; }
    public string Namerobot { get; set; }
    public DateTime Date { get; set; }
}


public class Robot
{
    public int Id { get; set; }
    public string RobotName { get; set; }
    public string Type { get; set; }
    public int SerialNumber { get; set; }
    public string Image { get; set; }
}

public class RobotFix 
{
  [Key]
    public string Namerobot { get; set; }
    public DateTime Date { get; set;}
    public string HandleBy { get; set; }
}

public class Target
{
    public string From { get; set; }
    public int ID { get; set;}
    public string To { get; set; }
}

public class Task
{
[Key]
    public string Namerobot { get; set; }
    public DateTime Date { get; set;}
    public string TaskName{ get; set; }
}
public class Approval
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Serial_no is required.")]
    public int Serial_no { get; set; }

    [Required(ErrorMessage = "NameRobot is required.")]
    public string? NameRobot { get; set; }

    [Required(ErrorMessage = "Info is required.")]
    public string Info { get; set; }
}
