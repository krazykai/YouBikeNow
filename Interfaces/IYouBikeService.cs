using Newtonsoft.Json.Linq;
using YouBikeNow.Models;

namespace YouBikeNow.Interfaces
{
    public interface IYouBikeService
    {
        Task<List<TaipeiYouBikeRealTimeDataModel>> GetYouBikeRealTimeData(YouBikeRealTimeDataQueryData youBikeRealTimeDataQueryData);
    }
}
