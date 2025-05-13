using AutoMapper;
using Promptito.Application;
using Promptito.Persistence;
using Promptito.Application.Interfaces;
using Promptito.Application.Perfiles;
using Promptito.Application.Servicios;


var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IPromptitoDbContext>();
}

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseExcepciones();
//app.UseAuthorization();

app.MapControllers();

app.Run();