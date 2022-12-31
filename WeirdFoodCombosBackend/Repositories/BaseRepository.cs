using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WeirdFoodCombosBackend.Databases;
using WeirdFoodCombosBackend.Dtos;
using WeirdFoodCombosBackend.Entities;
using WeirdFoodCombosBackend.Interfaces;

namespace WeirdFoodCombosBackend.Repositories
{
    public class BaseRepository<T, TDto> : IBaseRepository<T, TDto> where T : BaseEntity, new() where TDto : BaseDto
    {
        private readonly WeirdFoodCombosContext _dbContext;
        private readonly IMapper _mapper;

        public DbSet<T> table;

        public BaseRepository(WeirdFoodCombosContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

            table = dbContext.Set<T>();
        }

        public async Task<TDto> Create(TDto tDto)
        {
            //null entity exception
            if (tDto == null)
                throw new NotImplementedException();

            var entity = await table.FirstOrDefaultAsync(e => e.Id == tDto.Id);

            //entity exists exception
            if (entity != null)
                throw new NotImplementedException();

            var dbEntity = new T();

            _mapper.Map(tDto, dbEntity);
            await table.AddAsync(dbEntity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDto>(dbEntity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await table.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                table.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public virtual async Task<List<TDto>> GetAll()
        {
            return _mapper.Map<List<TDto>>(await table.ToListAsync());
        }

        public async Task<TDto> GetById(Guid id)
        {
            return _mapper.Map<TDto>(await table.FirstOrDefaultAsync(e => e.Id == id));
        }

        public async Task<TDto> Update(TDto tDto)
        {
            //null entity exception
            if (tDto == null)
                throw new NotImplementedException();

            var entity = await table.FirstOrDefaultAsync(e => e.Id == tDto.Id);

            //null entity exception
            if (entity == null)
                throw new NotImplementedException();

            _mapper.Map(tDto, entity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }
    }
}