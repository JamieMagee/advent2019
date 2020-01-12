using AdventOfCode.Blazor.Services;
using AdventOfCode.Core;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Blazor
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<ISolutionHandler, SolutionHandler>();
      services.AddSingleton<IInputHandler, InputHandler>();
    }

    public void Configure(IComponentsApplicationBuilder app)
    {
      app.AddComponent<App>("app");
    }
  }
}
