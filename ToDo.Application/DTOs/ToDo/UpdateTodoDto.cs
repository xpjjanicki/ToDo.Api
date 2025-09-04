namespace ToDo.Application.DTOs.ToDo
{
    public record UpdateTodoDto(int id, DateOnly expireDate, string title, string description, short completePercentage);
}
