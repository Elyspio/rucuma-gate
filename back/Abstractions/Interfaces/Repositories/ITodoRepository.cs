using RucumaGate.Api.Abstractions.Models;

namespace RucumaGate.Api.Abstractions.Interfaces.Repositories;

public interface ITodoRepository
{
	Task<TodoEntity> Add(string label, string user);
	Task<List<TodoEntity>> GetAll(string user);
	Task<TodoEntity> Check(Guid id, string user);
	Task Delete(Guid id, string user);
}