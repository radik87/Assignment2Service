using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ReplaceService _replaceService;
        public ServiceController(ReplaceService replaceService)
        {
            _replaceService = replaceService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            string response = await _replaceService.GetResponseFromUrl("https://www.reddit.com/r/popular/");

            string[] responseToArr = _replaceService.SplitArray(response);

            Tuple<int, int> bordersBody = _replaceService.GetBodyIndexes(responseToArr);

            string result = _replaceService.Replace(responseToArr, bordersBody);

            return result;
        }

    }
}
