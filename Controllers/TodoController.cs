using Microsoft.AspNetCore.Mvc;
using _net.Models;
using _net.Data;
using Microsoft.EntityFrameworkCore;

namespace _net.Controllers;

[ApiController]
[Route("V1")]
public class TodoController : ControllerBase
{

    [HttpGet]
    [Route("Todos")]
    public async Task<IActionResult> GetAsync(ApiDbContext context)
    {
        var Todos = await context.Todos.AsNoTracking().ToListAsync();
        return Ok(Todos);
    }

    [HttpGet]
    [Route("Todos/{id}")]
    public async Task<IActionResult> GetByIdAsync(ApiDbContext context, int id)
    {
        var todo = await context.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return todo == null ? NotFound() : Ok(todo);
    }


    [HttpPost]
    [Route("Todos")]
    public async Task<IActionResult> PostAsync(ApiDbContext context, Todo todo)
    {

        try
        {
            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();
            return Created($"v1/todos/{todo.Id}", todo);
        }
        catch (Exception e)
        {
            return BadRequest();

        }

    }

    [HttpPut]
    [Route("Todos/{id}")]
    public async Task<IActionResult> PutAsync(ApiDbContext context, int id, [FromBody] Todo todo)
    {
        var updateTodo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        if (updateTodo == null)
            return NotFound();

        try
        {
            updateTodo.Titulo = todo.Titulo;
            updateTodo.Done = todo.Done;
            await context.SaveChangesAsync();
            return Ok(updateTodo);
        }
        catch (Exception e)
        {
            return BadRequest();

        }

        

    }

    [HttpDelete]
    [Route("Todos/{id}")]
    public async Task<IActionResult> DeleteAsync(ApiDbContext context, int id)
    {
        var deleteTodo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        if (deleteTodo == null)
            return NotFound();

        try
        {
            context.Todos.Remove(deleteTodo);
            await context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();

        }

        

    }


}