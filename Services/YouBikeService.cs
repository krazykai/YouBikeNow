using Newtonsoft.Json.Linq;
using YouBikeNow.Helpers;
using YouBikeNow.Interfaces;
using YouBikeNow.Models;

namespace YouBikeNow.Services
{
    public class YouBikeService : IYouBikeService
    {
        private readonly YouBikeOpenAPIHelper _youBikeOpenAPIHelper;

        public YouBikeService(YouBikeOpenAPIHelper youBikeOpenAPIHelper)
        {
            _youBikeOpenAPIHelper = youBikeOpenAPIHelper;
        }

        public async Task<List<TaipeiYouBikeRealTimeDataModel>> GetYouBikeRealTimeData(YouBikeRealTimeDataQueryData youBikeRealTimeDataQueryData)
        {
            JArray youBikeRealTimeDataJArray = await _youBikeOpenAPIHelper.GetYouBikeRealTimeData(youBikeRealTimeDataQueryData.city.ToLower());

            // filter
            var youBikeRealTimeData = youBikeRealTimeDataJArray.Where(x => x["sarea"].ToString().Contains(youBikeRealTimeDataQueryData.sarea.ToLower()));

            List<TaipeiYouBikeRealTimeDataModel> taipeiYouBikeRealTimeDataList = new List<TaipeiYouBikeRealTimeDataModel>();
            foreach (var stationdata in youBikeRealTimeData)
            {
                TaipeiYouBikeRealTimeDataModel taipeiYouBikeRealTimeDataModel = new TaipeiYouBikeRealTimeDataModel()
                {
                    sno = stationdata["sno"].ToString(),
                    sna = stationdata["sna"].ToString(),
                    total = int.Parse(stationdata["total"].ToString()),
                    available_rent_bikes = int.Parse(stationdata["available_rent_bikes"].ToString()),
                    sarea = stationdata["sarea"].ToString(),
                    mday = stationdata["mday"].ToString(),
                    latitude = float.Parse(stationdata["latitude"].ToString()),
                    longitude = float.Parse(stationdata["longitude"].ToString()),
                    ar = stationdata["ar"].ToString(),
                    sareaen = stationdata["sareaen"].ToString(),
                    snaen = stationdata["snaen"].ToString(),
                    aren = stationdata["aren"].ToString(),
                    available_return_bikes = int.Parse(stationdata["available_return_bikes"].ToString()),
                    act = stationdata["act"].ToString(),
                    srcUpdateTime = DateTime.Parse(stationdata["srcUpdateTime"].ToString()),
                    updateTime = DateTime.Parse(stationdata["updateTime"].ToString()),
                    infoTime = DateTime.Parse(stationdata["infoTime"].ToString()),
                    infoDate = DateTime.Parse(stationdata["infoDate"].ToString()),
                };

                taipeiYouBikeRealTimeDataList.Add(taipeiYouBikeRealTimeDataModel);
            }

            return taipeiYouBikeRealTimeDataList;
        }
    }
}
