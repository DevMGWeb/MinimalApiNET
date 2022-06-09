using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareaContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareaContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareaContext dbContext) => 
{
    await dbContext.Database.EnsureCreatedAsync(); 
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareaContext dbContext) =>  
{
    return Results.Ok(dbContext.Tareas.Include(x => x.Categoria)
        .Where(x => x.PrioridadTarea == projectef.Models.Prioridad.Baja));
});

app.MapPost("/api/tareas", async ([FromServices] TareaContext dbContext, [FromBody] Tarea tarea) =>  
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    // await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareaContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>  
{
    var tareaActual = dbContext.Tareas.Find(id);
    
    if(tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareaContext dbContext, [FromRoute] Guid id) =>  
{
    var tareaActual = dbContext.Tareas.Find(id);
    
    if(tareaActual != null)
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        
        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
