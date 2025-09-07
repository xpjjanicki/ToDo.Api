using ToDo.Application.DTOs.ToDo;

namespace ToDo.Application.Interfaces
{
    public interface IToDoService
    {
        Task<ToDoDto?> GetByIdAsync(int id);
        Task<List<ToDoDto>?> GetAllAsync();
        Task<List<ToDoDto>?> GetIncommingAsync(DateTime? dateFrom, DateTime? dateTo);
        Task<bool> AddAsync(CreateToDoDto toDo);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(UpdateTodoDto toDo);
        //Task<bool> UpdatePercentageAsync(UpdatePercentageTodoDto toDo);
    }
}
