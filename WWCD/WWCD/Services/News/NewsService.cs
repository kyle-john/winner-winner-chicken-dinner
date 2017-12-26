using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WWCD.Models.News;

namespace WWCD.Services.News
{
    public static class NewsService
    {
        private static async Task<JObject> GetAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(url);
                var json = await result.Content.ReadAsStringAsync();

                return JObject.Parse(json);
            }
        }

        public static async Task<NewsItem[]> GetNewsAsync(int page)
        {
            var json = await GetAsync($"https://www.playbattlegrounds.com/news/list?page={page}");
            var token = json["context"]["list"];

            return token.ToObject<NewsItem[]>();
        }

        public static async Task<NewsItem[]> GetNewsAsync(int page, NewsType type)
        {
            var json = await GetAsync($"https://www.playbattlegrounds.com/news/list?page={page}&type_cd={(int)type}");
            var token = json["context"]["list"];

            return token.ToObject<NewsItem[]>();
        }
    }
}
