using Microsoft.AspNetCore.Mvc;
using ToDo.Application.DTOs.ToDo;
using ToDo.Application.Interfaces;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(IToDoService toDoService) : ControllerBase
    {
        private readonly IToDoService _toDoService = toDoService;

        /// <summary>
        /// Returns all todo items. If doesn't exist any, it returns empty list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ToDoDto>>> GetAll()
        {
            var items = await _toDoService.GetAllAsync();
            if (items is not null)
                return Ok(items);
            else
                return BadRequest();
        }

        /// <summary>
        /// Returns todo item with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoDto>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var item = await _toDoService.GetByIdAsync(id);
            if (item is not null)
                return Ok(item);
            else
                return BadRequest();
        }

        /// <summary>
        /// Returns todo items between two dates. If doesn't exist any, it returns empty list.
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("(api/[controller]/{dateFrom?}/{dateTo?}")]
        public async Task<ActionResult<List<ToDoDto>>> GetIncomming(DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            var items = await _toDoService.GetIncommingAsync(dateFrom, dateTo);
            if (items is not null)
                return Ok(items);
            else
                return BadRequest();
        }

        /// <summary>
        /// Creates and saves todo item in DB.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<bool>> Add(CreateToDoDto dto)
        {
            if (dto == null)
                return BadRequest();

            if (await _toDoService.AddAsync(dto))
                return Ok();
            else
                return BadRequest();
        }

        /// <summary>
        /// Deletes if exist todo item with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (await _toDoService.DeleteAsync(id))
                return Ok();
            else
                return BadRequest();
        }

        /// <summary>
        /// Updates todo item.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] UpdateTodoDto dto)
        {
            if (id == 0)
                return BadRequest();

            if (await _toDoService.UpdateAsync(dto))
                return Ok();
            else
                return BadRequest();
        }
    }
}
