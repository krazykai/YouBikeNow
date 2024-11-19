using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using YouBikeNow.Interfaces;
using YouBikeNow.Models;

namespace YouBikeNow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YouBikeController : ControllerBase
    {
        private readonly IYouBikeService _youBikeService;

        public YouBikeController(IYouBikeService youBikeService)
        {
            _youBikeService = youBikeService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<TaipeiYouBikeRealTimeDataModel>>> GetYouBikeRealTimeData([FromQuery] YouBikeRealTimeDataQueryData youBikeRealTimeDataQueryData)
        {
            List<TaipeiYouBikeRealTimeDataModel> taipeiYouBikeRealTimeDataList = await _youBikeService.GetYouBikeRealTimeData(youBikeRealTimeDataQueryData);

            return taipeiYouBikeRealTimeDataList;
        }
    }
}
