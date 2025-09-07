using ToDo.Core.Entities;

namespace ToDo.Core.Interfaces
{
    public interface IToDoRepository
    {
        Task<ToDoItem?> GetByIdAsync(int id);
        Task<List<ToDoItem>?> GetAllAsync(DateTime? dateFrom, DateTime? dateTo);
        Task<List<ToDoItem>?> GetIncommingAsync(DateTime dateFrom, DateTime dateTo);
        Task<bool> AddAsync(ToDoItem toDo);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(ToDoItem toDo);



        //Task UpdatePercentageAsync(ToDoItem toDo);
    }
}
