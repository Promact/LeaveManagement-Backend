using LeaveManagement.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Repository.Repository
{
    public interface IEntityRepository<TEntity,TDto> where TEntity:class
    {
        Task<IEnumerable<TDto>> GetEntityAsync();

        Task<TDto> GetEntityAsync(int id);

        Task PutEntityAsync(int id, TDto entityDTO, string propertyToUpdate = null);

        Task<TDto> PostEntityAsync(TDto entityDTO);

        Task<TDto> DeleteEntityAsync(int id);

    }
}
