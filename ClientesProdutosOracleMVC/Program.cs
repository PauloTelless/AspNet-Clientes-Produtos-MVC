using ClientesProdutosOracleMVC.Context;
using ClientesProdutosOracleMVC.Repositories.ClienteRepository;
using ClientesProdutosOracleMVC.Repositories.Interfaces;
using ClientesProdutosOracleMVC.Repositories.ProdutoRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var oracleConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseOracle(oracleConnection));

builder.Services.AddScoped<ICliente, ClienteRepository>();

builder.Services.AddScoped<IProduto, ProdutoRepository>();

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
