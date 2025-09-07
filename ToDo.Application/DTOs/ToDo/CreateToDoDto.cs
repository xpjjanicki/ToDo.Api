namespace ToDo.Application.DTOs.ToDo
{
    public record CreateToDoDto(DateTime ExpireDate, string Title, string Description, short CompletePercentage);
}
