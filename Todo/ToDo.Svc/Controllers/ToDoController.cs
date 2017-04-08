using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Abstraction.Interfaces;
using m = ToDo.Abstraction.Models;

namespace ToDo.Svc.Controllers
{
  [Route("api/v1")]
  public class ToDoController : Controller
  {
    IRepository todoRepository;
    public ToDoController(IRepository todoRepository)
    {
      this.todoRepository = todoRepository;
    }
    // GET api/values
    [HttpGet]
    public async Task<IEnumerable<m.ToDo>> Get()
    {
      return await this.todoRepository.GetPendingToDosAsync();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<m.ToDo> Get(int id)
    {
      return await this.todoRepository.GetById(id);
    }

    // POST api/values
    [HttpPost]
    public async Task<bool> Post([FromBody]m.ToDo value)
    {
      return await this.todoRepository.UpsertToDoAsync(value);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {
      return await this.todoRepository.DeleteToDoAsync(id);
    }
  }
}
