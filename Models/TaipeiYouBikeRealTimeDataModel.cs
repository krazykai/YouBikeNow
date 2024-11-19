namespace YouBikeNow.Models
{
    public class TaipeiYouBikeRealTimeDataModel
    {
        public string sno {  get; set; } // 站點代號
        public string sna { get; set; }  // 中文場站名稱
        public int total { get; set; }  // 場站總停車格
        public int available_rent_bikes { get; set; }  // 可借車輛數量
        public string sarea { get; set; }  // 中文場站區域名稱
        public string mday { get; set; }
        public float latitude { get; set; }  // 緯度
        public float longitude { get; set; }  // 經度
        public string ar { get; set; }  // 中文地址
        public string sareaen { get; set; }  // 英文場站區域名稱
        public string snaen { get; set; }  // 英文場站名稱
        public string aren { get; set; }  // 英文地址
        public int available_return_bikes { get; set; }  // 可還車位數量
        public string act { get; set; }  // 全站禁用狀態(0:禁用、1:啟用)
        public DateTime srcUpdateTime { get; set; }
        public DateTime updateTime { get; set; }
        public DateTime infoTime { get; set; }
        public DateTime infoDate { get; set; }
    }
}
