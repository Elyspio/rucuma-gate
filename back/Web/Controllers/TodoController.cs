﻿using RucumaGate.Api.Abstractions.Interfaces.Services;
using RucumaGate.Api.Abstractions.Transports;
using RucumaGate.Api.Adapters.AuthenticationApi;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using RucumaGate.Api.Web.Filters;
using System.Net;

namespace RucumaGate.Api.Web.Controllers;

[Route("api/todo")]
[ApiController]
public class TodoController : ControllerBase
{
	private readonly ITodoService todoService;

	public TodoController(ITodoService todoService)
	{
		this.todoService = todoService;
	}

	[HttpGet]
	[SwaggerResponse(HttpStatusCode.OK, typeof(List<Todo>))]
	public async Task<IActionResult> GetAll()
	{
		return Ok(await todoService.GetAll());
	}

	[HttpPut("{id:guid}/toggle")]
	[SwaggerResponse(HttpStatusCode.OK, typeof(Todo))]
	public async Task<IActionResult> Check(Guid id)
	{
		return Ok(await todoService.Check(id));
	}


	[Authorize(AuthenticationRoles.Admin)]
	[HttpPost]
	[SwaggerResponse(HttpStatusCode.OK, typeof(Todo))]
	public async Task<IActionResult> Add([FromBody] string label)
	{
		return Ok(await todoService.Add(label));
	}

	[Authorize(AuthenticationRoles.User)]
	[HttpDelete("{id:guid}")]
	[SwaggerResponse(HttpStatusCode.NoContent, typeof(void))]
	public async Task<IActionResult> Delete(Guid id)
	{
		await todoService.Delete(id);
		return NoContent();
	}
}