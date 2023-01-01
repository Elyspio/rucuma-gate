using RucumaGate.Api.Abstractions.Assemblers;
using RucumaGate.Api.Abstractions.Extensions;
using RucumaGate.Api.Abstractions.Models;
using RucumaGate.Api.Abstractions.Transports;

namespace RucumaGate.Api.Core.Assemblers;

public class TodoAssembler : BaseAssembler<Todo, TodoEntity>
{
	public override Todo Convert(TodoEntity obj)
	{
		return new()
		{
			Checked = obj.Checked,
			Id = obj.Id.AsGuid(),
			Label = obj.Label,
			User = obj.User
		};
	}

	public override TodoEntity Convert(Todo obj)
	{
		return new()
		{
			Checked = obj.Checked,
			Id = obj.Id.AsObjectId(),
			Label = obj.Label,
			User = obj.User
		};
	}
}