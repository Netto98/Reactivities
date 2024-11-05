using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Things we use inside our application logic (code)

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configures the database context to use SQLite, setting the connection string from app settings.
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// This section sets up middleware, which processes requests and responses in the app.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Creates a scope for resolving scoped services, such as the DataContext, for database initialization.
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    // Retrieve the DataContext service and apply any pending migrations.
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync(); // Applies any pending migrations to the database on startup.
    // Seeds the database with initial data, if necessary.
    await Seed.SeedData(context);
}
catch (Exception ex)
{

    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An Error has occured during migration process.");
}

app.Run();
