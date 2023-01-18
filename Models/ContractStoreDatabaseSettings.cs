using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractStoreApi.Models
{
    public class ContractStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ContractsCollectionName { get; set; } = null!;
    }
}