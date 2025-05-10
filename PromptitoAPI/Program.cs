using AutoMapper;
using Cartas.Persistence;
using Promptito.Application.Interfaces;
using Promptito.Application.Perfiles;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var mapperConfig = new MapperConfiguration(cfg => {
    cfg.AddProfile(new AutoMapperProfile());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddAutoMapper(typeof(Program).Assembly);
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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();