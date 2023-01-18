using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ContractStoreApi.Models
{
    public class Contracts
    {
        [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string ContractName { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime FirstVisit { get; set; }
    public DateTime SecondVisit { get; set; }
    public DateTime ThirdVisit { get; set; }
    public DateTime FourthVisit { get; set; }

    }
}