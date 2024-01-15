using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Contracts;
using TodoList.DTO;
using TodoList.LoggerService;
using TodoList.models;
using TodoList.models.context;
using TodoList.Repository;

namespace TodoList.Controllers;


[Route("item/")]
[ApiController]

public class TodoItemController : ControllerBase
{

    private readonly TodoItemRepository _todoItemRepository;
    private readonly UserRepository _userRepository;

    private readonly ILoggerManager _logger;

    public TodoItemController(TodoItemRepository todoItemRepository, ILoggerManager logger, UserRepository userRepository)
    {
        _logger = logger;
        _todoItemRepository = todoItemRepository;
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IResult> CreateItem([FromBody] TodoItemDTO data)
    {

        _logger.LogDebug($"Attempting to retrieve data from body {data.Name} {data.Description}");

        if (!ModelState.IsValid)
        {
            _logger.LogError("Model state is not valid. Validation errors:");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                _logger.LogError($"- {error.ErrorMessage}");
            }
            return TypedResults.BadRequest(ModelState);
        }


        var item = new TodoItem()
        {
            Description = data.Description,
            IsCompleted = data.IsCompleted,
            Name = data.Name
        };

        _logger.LogDebug("Attempting to retrieve current user from the repository");

        var current = _userRepository.FindByCondition(x => x.Id == Guid.Parse("596767dc-c295-4dc9-ae79-4e80796f51db"), true).FirstOrDefault();

        if (current is null)
        {
            _logger.LogWarn("Current user not found in the repository");
            return TypedResults.NotFound();
        }

        item.Id = Guid.NewGuid();
        item.CreatedOn = DateTime.UtcNow;
        item.LastModified = DateTime.UtcNow;
        item.UserId = current.Id;
        item.User = current;
        await _todoItemRepository.Create(item);

        _logger.LogDebug($"TodoItemDTO created - Name: {item.Name}, Description: {item.Description}, IsCompleted: {item.IsCompleted}");
        return TypedResults.Created($"/item/{item.Id}");
    }

    [HttpGet("list")]
    public async Task<IResult> FindAll([FromQuery] ItemParameter itemParameter)
    {
        _logger.LogInfo("In findAll method");

        var items = _todoItemRepository.FindAll(false);
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