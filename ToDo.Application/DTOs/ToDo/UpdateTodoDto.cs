namespace ToDo.Application.DTOs.ToDo
{
    public record UpdateTodoDto(int Id, DateTime ExpireDate, string Title, string Description, short CompletePercentage);
}
