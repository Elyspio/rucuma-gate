using RucumaGate.Api.Abstractions.Extensions;
using RucumaGate.Api.Abstractions.Interfaces.Repositories;
using RucumaGate.Api.Abstractions.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using RucumaGate.Api.Db.Repositories.Internal;

namespace RucumaGate.Api.Db.Repositories;

internal class TodoRepository : BaseRepository<TodoEntity>, ITodoRepository
{
	public TodoRepository(IConfiguration configuration, ILogger<BaseRepository<TodoEntity>> logger) : base(configuration, logger)
	{
	}


	public async Task<TodoEntity> Add(string label, string user)
	{
		var entity = new TodoEntity
		{
			Checked = false,
			Label = label,
			User = user
		};
		await EntityCollection.InsertOneAsync(entity);
		return entity;
	}

	public async Task<List<TodoEntity>> GetAll(string user)
	{
		return await EntityCollection.AsQueryable().Where(x => x.User == user).ToListAsync();
	}

	public async Task<TodoEntity> Check(Guid id, string user)
	{
		var entity = await EntityCollection.AsQueryable().FirstAsync(todo => todo.Id == id.AsObjectId());

		entity.Checked = !entity.Checked;

		await EntityCollection.FindOneAndReplaceAsync(e => e.Id == id.AsObjectId(), entity);

		return entity;
	}

	public async Task Delete(Guid id, string user)
	{
		await EntityCollection.FindOneAndDeleteAsync(todo => todo.User == user && todo.Id == id.AsObjectId());
	}
}