using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<Iservice,UserService>();
builder.Services.AddTransient<IRepository, UserRepository>();
builder.Services.AddTransient<ITamarStore,TamarStoreContext>();

//builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
