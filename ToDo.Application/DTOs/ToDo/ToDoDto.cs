namespace ToDo.Application.DTOs.ToDo
{
    public record ToDoDto(int Id, DateTime ExpireDate, string Title, string Description, short CompletePercentage);
}
