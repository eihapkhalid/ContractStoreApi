using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContractStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace ContractStoreApi.Services
{
    public class ContractsService
    {
        private readonly IMongoCollection<Contracts> _contractsCollection;

        public ContractsService(
        IOptions<ContractStoreDatabaseSettings> contractStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                contractStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                contractStoreDatabaseSettings.Value.DatabaseName);

            _contractsCollection = mongoDatabase.GetCollection<Contracts>(
                contractStoreDatabaseSettings.Value.ContractsCollectionName);
        }
        public async Task<List<Contracts>> GetAsync() =>
        await _contractsCollection.Find(_ => true).ToListAsync();

        public async Task<Contracts?> GetAsync(string id) =>
            await _contractsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Contracts newContract) =>
            await _contractsCollection.InsertOneAsync(newContract);

        public async Task UpdateAsync(string id, Contracts updatedContract) =>
            await _contractsCollection.ReplaceOneAsync(x => x.Id == id, updatedContract);

        public async Task RemoveAsync(string id) =>
            await _contractsCollection.DeleteOneAsync(x => x.Id == id);
    }
}