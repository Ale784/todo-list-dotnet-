using Microsoft.EntityFrameworkCore;
using TodoList.Contracts;
using TodoList.LoggerService;
using TodoList.models.context;

namespace TodoList.Extensions;

public static class ExtensionMethods 
{

    public static void ConfigureMysqlContext(this IServiceCollection services, IConfiguration configuration)
    {  
        services.AddDbContext<TodoDbContext>(opt => opt.UseMySQL(configuration.GetConnectionString("mysqlConnection")));
    }

     public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
                                                                                                                            
                                                                                                                            
    

}