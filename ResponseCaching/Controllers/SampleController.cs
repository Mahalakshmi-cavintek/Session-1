using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResponseCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ResponseCache(Duration = 5)]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        //[ResponseCache(Duration = 5,NoStore =false)]
        //[ResponseCache(CacheProfileName ="Demo")]
        public int Get() 
        {
            return DateTime.Now.Second;
        }

        [HttpGet("gettime")]
        [ResponseCache(Duration=500,VaryByQueryKeys = new string[] {"id"})]
        public string GetTime(int id)
        {
            return $"Response was generated for Id:{id} on {DateTime.Now}";
        }
    }
}
