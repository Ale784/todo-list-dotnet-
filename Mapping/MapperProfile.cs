using AutoMapper;
using TodoList.DTO;
using TodoList.models;

namespace TodoList.Extensions;

public class AutoMapperProfile : Profile {

    public AutoMapperProfile(){
        
        CreateMap<TodoItem, TodoItemDTO>();

    }

}