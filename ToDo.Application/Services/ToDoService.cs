using ToDo.Application.DTOs.ToDo;
using ToDo.Application.DTOs.ToDoExtensions;
using ToDo.Application.Interfaces;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;

namespace ToDo.Application.Services
{
    public class ToDoService(IToDoRepository toDoRepository) : IToDoService
    {
        private readonly IToDoRepository _toDoRepository = toDoRepository;

        public async Task<List<ToDoDto>?> GetAllAsync()
        {
            List<ToDoItem>? todos = await _toDoRepository.GetAllAsync(null, null);
            
            if (todos is not null) // && todos.Count > 0)
                return [.. todos.Select(t => t.AsDto())];

            return null;
        }

        public async Task<ToDoDto?> GetByIdAsync(int id)
        {
            var todo = await _toDoRepository.GetByIdAsync(id);

            if (todo is not null)
            {
                ToDoDto dto = new(todo.Id, todo.ExpiryDate, todo.Title, todo.Description, todo.CompletePercentage);
                return dto;
            }

            return null;
        }

        public async Task<List<ToDoDto>?> GetIncommingAsync(DateTime? dateFrom, DateTime? dateTo)
        {
            try
            {
                if (dateFrom > dateTo)
                    return null;

                var todos = await _toDoRepository.GetAllAsync(dateFrom, dateTo);
                List<ToDoDto>? todoDtos = todos.Select(t => t.AsDto()).ToList();

                return todoDtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddAsync(CreateToDoDto toDo)
        {
            try
            {
                ToDoItem item = new()
                {
                    Title = toDo.Title,
                    Description = toDo.Description,
                    CompletePercentage = 0,
                    ExpiryDate = toDo.ExpireDate
                };

                await _toDoRepository.AddAsync(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var todo = await _toDoRepository.GetByIdAsync(id);
                if (todo is null)
                    return false;

                await _toDoRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(UpdateTodoDto dto)
        {
            try
            {
                ToDoItem todo = new()
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    Description = dto.Description,
                    CompletePercentage = dto.CompletePercentage,
                    ExpiryDate = dto.ExpireDate
                };

                return await _toDoRepository.UpdateAsync(todo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
