using KoshApp.Models;

namespace KoshApp.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(Int64 id);
        Task Create(Person _Person);
        Task Update(Person _Person);
        Task Delete(Int64 id);
    }
}
