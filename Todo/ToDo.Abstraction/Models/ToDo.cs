using System;

namespace ToDo.Abstraction.Models
{
  public partial class ToDo
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? UpdatedOnUtc { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
  }
}
