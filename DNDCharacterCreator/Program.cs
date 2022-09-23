using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Services;
using DNDCharacterCreator.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy",
        builder => builder.WithOrigins("http://localhost:4200/liste")
        .AllowAnyMethod().SetIsOriginAllowed(x => true)
        .AllowAnyHeader()
        .AllowCredentials());
});

builder.Services.AddScoped<ICharacterRepo, CharacterRepo>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddSingleton<CharHub>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("corsPolicy");
app.MapControllers();
app.MapHub<CharHub>("/charhub");

app.Run();
