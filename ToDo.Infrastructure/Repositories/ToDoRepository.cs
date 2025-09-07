using Microsoft.EntityFrameworkCore;
using ToDo.Application.DTOs.ToDoExtensions;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.Infrastructure.Repositories
{
    public class ToDoRepository(ApplicationDbContext context) : IToDoRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<ToDoItem>?> GetAllAsync(DateTime? dateFrom, DateTime? dateTo)
        {
            var query = await _context.ToDos.ToListAsync();
            if (dateFrom is not null)
            {
                query = /*(List<ToDoItem>)*/ query.Where(x => x.ExpiryDate >= dateFrom).ToList();
            }
            if (dateTo is not null)
            {
                query = /*(List<ToDoItem>)*/ query.Where(x =>x.ExpiryDate <= dateTo).ToList();
            }

            if (query.Count() >= 0)
                return query;

            return null;
        }

        public async Task<ToDoItem?> GetByIdAsync(int id) => await _context.ToDos.FindAsync(id);

        public async Task<List<ToDoItem>> GetIncommingAsync(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                return await _context.ToDos
                    .Where(t => t.ExpiryDate >= dateFrom && t.ExpiryDate <= dateTo)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        public async Task<bool> AddAsync(ToDoItem toDo)
        {
            try
            {
                await _context.ToDos.AddAsync(toDo);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo is null)
                return false;

            _context.ToDos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(ToDoItem toDo)
        {
            try
            {
                var toDoFromDb = await _context.ToDos.FindAsync(toDo.Id);
                if (toDoFromDb is null)
                    return false;

                toDoFromDb.Title = toDo.Title;
                toDoFromDb.Description = toDo.Description;
                toDoFromDb.ExpiryDate = toDo.ExpiryDate;
                toDoFromDb.CompletePercentage = toDo.CompletePercentage;

                _context.ToDos.Update(toDoFromDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //public async Task UpdatePercentageAsync(ToDoItem toDo)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
