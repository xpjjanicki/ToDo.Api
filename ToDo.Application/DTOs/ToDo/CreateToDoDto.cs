namespace ToDo.Application.DTOs.ToDo
{
    public record CreateToDoDto(DateOnly expireDate, string title, string description, short completePercentage);
}
