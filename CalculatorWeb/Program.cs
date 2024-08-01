using CalculatorApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICalculator, Calculator>();
builder.Services.AddSingleton<IDiagnostics>(provider =>
{
    var connectionString = "data source=WINDOWS-4QT2NDK;initial catalog=CalcLogDB;user id=sa;password=11Jan02*;trustservercertificate=True;MultipleActiveResultSets=True;";
    return new SPDiagnostics(connectionString);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
