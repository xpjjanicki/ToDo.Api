using ToDo.Application.DTOs.ToDo;
using ToDo.Core.Entities;

namespace ToDo.Application.DTOs.ToDoExtensions
{
    public static class ToDoExtension
    {
        public static ToDoDto AsDto(this ToDoItem todo)
        {
            return new ToDoDto(
                todo.Id,
                todo.ExpiryDate,
                todo.Title,
                todo.Description,
                todo.CompletePercentage
            );
        }
    }
}
