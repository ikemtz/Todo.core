using System.Collections.Generic;
using System.Threading.Tasks;
using m = ToDo.Abstraction.Models;

namespace ToDo.Abstraction.Interfaces
{
  public interface IRepository
  {
    Task<IEnumerable<m.ToDo>> GetPendingToDosAsync();
    Task<bool> UpsertToDoAsync(m.ToDo t);
    Task<bool> DeleteToDoAsync(int id);
    Task<m.ToDo> GetById(int id);
  }
}
