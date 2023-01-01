using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RucumaGate.Api.Abstractions.Transports;

namespace RucumaGate.Api.Abstractions.Models;

public class TodoEntity : TodoBase
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public ObjectId Id { get; init; }
}