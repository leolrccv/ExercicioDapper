using Dapper.Contrib.Extensions;
using DapperEx.Domain.Entities;
using DapperEx.Infra.Contracts;
using System.Threading.Tasks;
using System;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace DapperEx.Infra.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public PetRepository(ISqlConnectionFactory connection)
        {
            _connectionFactory = connection;
        }

        //Add
        public async Task AddAsync(Pet pet)
        {
            using var connection = _connectionFactory.Connection();
            connection.Open();
            await connection.InsertAsync(pet);
        }

        //GetAll
        public async Task<IEnumerable<Pet>> GetAllPets()
        {
            const string sql = "SELECT * FROM Pet";
            
            using var connection = _connectionFactory.Connection();
            var pets = connection.QueryAsync<Pet>(sql).Result.ToList();

            return pets;
        }

        //GetById
        public async Task<Pet> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM Pet WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using var connection = _connectionFactory.Connection();
            return await connection.QuerySingleOrDefaultAsync<Pet>(sql, parameters, commandType: CommandType.Text);
        }   

        //Update
        public async Task<Pet> Update(Pet pet)
        {
            using var connection = _connectionFactory.Connection();
            await connection.UpdateAsync(pet);

            return pet;
        }

        //Delete
        public async Task<Pet> Delete(Guid id)
        {
            const string sql = "DELETE FROM Pet WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using var connection = _connectionFactory.Connection();
            return await connection.QuerySingleOrDefaultAsync<Pet>(sql, parameters, commandType: CommandType.Text);

        }
    }
}
