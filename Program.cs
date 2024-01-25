using NLog;
using TodoList.Contracts;
using TodoList.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));

// Add services to the container.
builder.Services.ConfigureMysqlContext(builder.Configuration);
builder.Services.ConfigureTodoItemRepository();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureUserRepository();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Extract the logger service
var logger = app.Services.GetRequiredService<ILoggerManager>();
// Configure global exception handling
// Pass the logger service to the extension method
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
