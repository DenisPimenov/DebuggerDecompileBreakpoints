using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DebuggerDecompileBreakpoints
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddMvc())
                .Configure(configureApp: builder => builder.UseMvc());
    }


    [Route("")]
    public class SimpleController : ControllerBase
    {
        [HttpGet("/1")]
        public IActionResult Get1()
        {
            return RedirectToAction("Get2", "Simple");
        }

        [HttpGet("/2")]
        public int Get2()
        {
            return 2;
        }
    }
}