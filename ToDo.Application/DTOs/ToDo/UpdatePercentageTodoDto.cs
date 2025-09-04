namespace ToDo.Application.DTOs.ToDo
{
    public record UpdatePercentageTodoDto(int id, DateOnly expireDate, short completePercentage);
}
