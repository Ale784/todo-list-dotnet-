using AutoMapper;
using TodoList.DTO;
using TodoList.models;

namespace TodoList.Extensions;

public class AutoMapperProfile : Profile {

    public AutoMapperProfile(){
        
        CreateMap<TodoItem, TodoItemDTO>();

        CreateMap<TodoItemForCreatingDTO, TodoItem>()
        .ForMember(todo => todo.CreatedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
        .ForMember(todo => todo.LastModified, opt => opt.MapFrom(src => DateTime.UtcNow));

    }

}