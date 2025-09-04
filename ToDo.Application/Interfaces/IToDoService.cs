using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Interfaces
{
    public interface IToDoService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task AddAsync(CreateProductDto product);
        Task DeleteAsync(int id);
        Task UpdateAsync(UpdateProducDto product);
    }
}
