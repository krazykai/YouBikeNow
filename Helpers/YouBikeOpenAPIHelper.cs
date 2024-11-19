using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace YouBikeNow.Helpers
{
    public class YouBikeOpenAPIHelper
    {
        private readonly HttpClient _httpClient;

        public YouBikeOpenAPIHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JArray> GetYouBikeRealTimeData(string location)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();

            // Taipei
            if (location.ToLower() == "taipei")
            {
                httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://tcgbusfs.blob.core.windows.net/dotapp/youbike/v2/youbike_immediate.json"),
                };
            }

            // New Taipei
            if (location.ToLower() == "newtaipei")
            {
                httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://data.ntpc.gov.tw/api/datasets/010e5b15-3823-4b20-b401-b1cf000550c5/csv/file"),
                };
            }

            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
            string youBikeRealTimeDataString = await httpResponseMessage.Content.ReadAsStringAsync();
            JArray youBikeRealTimeDataJArray = JArray.Parse(youBikeRealTimeDataString);

            return youBikeRealTimeDataJArray;
        }
    }
}
