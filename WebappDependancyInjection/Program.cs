

using WebappDependancyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IStudents ,PhysicsStudent>();
//builder.Services.AddSingleton<IStudents, MathStudent>();
builder.Services.AddScoped<GetClassFactory>();

builder.Services.AddScoped<MathStudent>()
            .AddScoped<IStudents, MathStudent>(s => s.GetService<MathStudent>());

builder.Services.AddScoped<PhysicsStudent>()
            .AddScoped<IStudents, PhysicsStudent>(s => s.GetService<PhysicsStudent>());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
