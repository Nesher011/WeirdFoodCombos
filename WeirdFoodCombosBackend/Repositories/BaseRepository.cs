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

        public async Task<TDto> Create(TDto entityDto)
        {
            var dbEntity = new T();

            _mapper.Map(entityDto, dbEntity);
            await table.AddAsync(dbEntity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TDto>(dbEntity);
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TDto>> GetAll()
        {
            return _mapper.Map<List<TDto>>(await table.ToListAsync());
        }

        public Task<TDto> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<TDto> Update(TDto tDto)
        {
            throw new NotImplementedException();
        }
    }
}
