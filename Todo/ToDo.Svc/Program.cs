using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ToDo.Svc
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = new WebHostBuilder()
          .UseKestrel()
          .UseContentRoot(Directory.GetCurrentDirectory())
          .UseStartup<Startup>()
          .UseApplicationInsights()
          .Build();

      host.Run();
    }
  }
}
