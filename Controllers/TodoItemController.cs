using Microsoft.AspNetCore.Mvc;
using TodoList.Contracts;
using TodoList.LoggerService;
using TodoList.models;
using TodoList.Repositoy;

namespace TodoList.Controllers;


[Route("item/")]
[ApiController]

public class TodoItemController : ControllerBase {

    readonly TodoItemRepository todoItemRepository;

    private readonly ILoggerManager _logger; 

    public TodoItemController(TodoItemRepository todoItemRepository, ILoggerManager logger) 
    {
        _logger = logger;

        this.todoItemRepository = todoItemRepository;
    }

    [HttpGet("list")]
    public async Task<IResult> FindAll([FromQuery] ItemParameter itemParameter)
    {
        _logger.LogInfo("In findAll method");

        var items = todoItemRepository.FindAll(false);
        int skipAmount = itemParameter.PageSize * (itemParameter.PageNumber - 1);
        var result = items.Skip(skipAmount).Take(itemParameter.PageSize).ToList();
        
        _logger.LogInfo($"Found {result.Count} items.");

        return TypedResults.Ok(new
        {
            success = true,
            data = result,
        });

    }
}