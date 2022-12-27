namespace WeirdFoodCombosBackend.Interfaces
{
    public interface IBaseRepository<T,TDto> where T : class
    {
        Task<List<TDto>> GetAll();
        Task<TDto> Create(TDto tDto);
        Task<TDto> Update(TDto tDto);
        Task<TDto> GetById(Guid guid);
        Task Delete(Guid guid);
    }
}
