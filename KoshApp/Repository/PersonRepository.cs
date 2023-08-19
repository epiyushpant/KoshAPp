using Dapper;
using KoshApp.Data;
using KoshApp.Models;
using System.Data;
using static Dapper.SqlMapper;

namespace KoshApp.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDapperContext _context;
        public PersonRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var query = "SELECT * FROM " + typeof(Person).Name;
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Person>(query);
                return result.ToList();
            }
        }
        public async Task<Person> GetByIdAsync(Int64 id)
        {
            var query = "SELECT * FROM " + typeof(Person).Name + " WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Person>(query, new { id });
                return result;
            }
        }
        public async Task Create(Person _Person)
        {
            var query = "INSERT INTO " + typeof(Person).Name + " (Name, Address, Age, PhoneNumber, Gender, Email,  DateOfJoin, CreatedDate, UpdatedDate ) VALUES (@Name, @Address,  @Age, @PhoneNumber, @Gender, @Email, @DateOfJoin, @CreatedDate, @UpdatedDate)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", _Person.Name, DbType.String);
            parameters.Add("Address", _Person.Address, DbType.String);
            parameters.Add("Age", _Person.Age, DbType.Int16);
            parameters.Add("PhoneNumber", _Person.PhoneNumber, DbType.String);
            parameters.Add("Gender", _Person.Gender, DbType.Int16);
            parameters.Add("Email", _Person.Email, DbType.String);
            parameters.Add("DateOfJoin", _Person.DateOfJoin, DbType.DateTime);
            parameters.Add("CreatedDate", _Person.CreatedDate, DbType.DateTime);
            parameters.Add("UpdatedDate", _Person.UpdatedDate, DbType.DateTime);
            parameters.Add("Photo", _Person.Photo, DbType.Binary);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task Update(Person _Person)
        {
            var query = "UPDATE " + typeof(Person).Name + " SET Name = @Name, Address = @Address, Age = @Age, PhoneNumber = @PhoneNumber, Gender = @Gender, Email = @Email, DateOfJoin = @DateOfJoin, UpdatedDate = @UpdatedDate WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", _Person.Id, DbType.Int64);
            parameters.Add("Name", _Person.Name, DbType.String);
            parameters.Add("Address", _Person.Address, DbType.String);
            parameters.Add("Age", _Person.Age, DbType.Int16);
            parameters.Add("PhoneNumber", _Person.PhoneNumber, DbType.String);
            parameters.Add("Gender", _Person.Gender, DbType.Int16);
            parameters.Add("Email", _Person.Email, DbType.String);
            parameters.Add("DateOfJoin", _Person.DateOfJoin, DbType.DateTime);
            parameters.Add("UpdatedDate", _Person.UpdatedDate, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
        public async Task Delete(Int64 id)
        {
            var query = "DELETE FROM " + typeof(Person).Name + " WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
