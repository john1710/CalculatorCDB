using API.Core.DI;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var modules = new List<IModule>()
{
    new ValidatorRegister(),
    new ServiceRegister()
};

builder.Host.ConfigureContainer<ContainerBuilder>(builder => { modules.ForEach(p => builder.RegisterModule(p)); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
