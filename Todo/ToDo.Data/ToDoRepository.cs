using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Abstraction.Interfaces;
using m = ToDo.Abstraction.Models;
namespace ToDo.Data
{
  public class ToDoRepository : IRepository
  {
    ToDoContext todoContext;
    public ToDoRepository(ToDoContext todoContext)
    {
      this.todoContext = todoContext;
    }
    public async Task<bool> DeleteToDoAsync(int id)
    {
      var todo = new m.ToDo() { Id = id };
      todoContext.ToDos.Attach(todo);
      todoContext.ToDos.Remove(todo);
      return 0 < await todoContext.SaveChangesAsync();
    }

    public async Task<m.ToDo> GetById(int id)
    {
      return await todoContext.ToDos.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<m.ToDo>> GetPendingToDosAsync()
    {
      return await todoContext.ToDos
        .Where(w => null == w.DeletedOnUtc)
        .ToListAsync();
    }

    public async Task<bool> UpsertToDoAsync(m.ToDo t)
    {
      var rec = await todoContext.ToDos.FirstOrDefaultAsync(f => f.Id == t.Id);
      if (null == rec)
      {
        t.CreatedOnUtc = DateTime.UtcNow;
        todoContext.ToDos.Add(t);
      }
      else
      {
        rec.Title = t.Title;
        rec.Description = t.Description;
        rec.UpdatedOnUtc = DateTime.UtcNow;
      }

      return 0 < await todoContext.SaveChangesAsync();

    }
  }
}