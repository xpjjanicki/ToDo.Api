namespace ToDo.Application.DTOs.ToDo
{
    public record UpdatePercentageTodoDto(int Id, DateTime ExpireDate, short CompletePercentage);
}
