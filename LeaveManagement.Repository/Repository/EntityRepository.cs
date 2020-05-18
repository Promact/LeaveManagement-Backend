using AutoMapper;
using LeaveManagement.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Repository.Repository
{
    public class EntityRepository<TEntity, TDto>:IEntityRepository<TEntity,TDto> where TEntity:class
    {
        private readonly LeaveManagementDbContext _context;
        private readonly IMapper _mapper;
        public EntityRepository(LeaveManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IEnumerable<TDto>> GetEntityAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();

            var entityDTOs = _mapper.Map<List<TDto>>(entities);

            return entityDTOs;
        }


        public async Task<TDto> GetEntityAsync(int id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            var entityDto = _mapper.Map<TDto>(entity);

            return entityDto;
        }


        public async Task PutEntityAsync(int id, TDto entityDto, string propertyToUpdate=null)
        {
            if (string.IsNullOrEmpty(propertyToUpdate))
            {
                var entity = _mapper.Map<TEntity>(entityDto);
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => (int)x.GetType().GetProperty("Id").GetValue(x) == id);
                if (entity == null)
                {
                    new NullReferenceException();
                }
                else
                {
                    entity.GetType().GetProperty(propertyToUpdate).SetValue(entity,entityDto.GetType().GetProperty(propertyToUpdate).GetValue(entityDto));
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    throw new MissingFieldException();
                }
                else
                {
                    throw;
                }
            }

            
        }

        public async Task<TDto> PostEntityAsync(TDto entityDTO)
        {
            var entity = _mapper.Map<TEntity>(entityDTO);

            _context.Add<TEntity>(entity);

            await _context.SaveChangesAsync();

            entityDTO.GetType().GetProperty("Id").SetValue(entityDTO, entity.GetType().GetProperty("Id").GetValue(entity));

            return entityDTO;
        }

        public async Task<TDto> DeleteEntityAsync(int id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            _context.Remove<TEntity>(entity);
            await _context.SaveChangesAsync();

            var entityDTO = _mapper.Map<TDto>(entity);

            return entityDTO;
        }

        private bool EntityExists(int id)
        {
            return _context.Set<TEntity>().Any(e =>(int)e.GetType().GetProperty("Id").GetValue(e) == id);
        }

    }
}
