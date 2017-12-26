using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace WWCD.Models.News
{
    public class NewsItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("typeCd")]
        public NewsType TypeCode { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public string Url => $"https://www.playbattlegrounds.com/news/{Id}.pu";

        public ImageSource Thumbnail => new Uri(ThumbnailUrl);

        [JsonProperty("simpleVisibleDate")]
        public DateTime Date { get; set; }
    }
}
