using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WWCD.Models.News;
using Xamarin.Forms;

namespace WWCD.ViewModels
{
    public class NewsPageViewModel : ViewModelBace
    {
        public ObservableCollection<NewsItem> News { get; set; }
        public ICommand LoadCommand { get; set; }

        public NewsPageViewModel()
        {
            News = new ObservableCollection<NewsItem>();
            LoadCommand = new Command(OnLoadMore);

            MessagingCenter.Subscribe<MainPage>(this, "MainPageIsAppearing", async (sender) =>
            {
                if (News.Count == 0)
                {
                    await LoadNextAsync().ConfigureAwait(false);
                }
            });
        }

        async void OnLoadMore()
        {
            await LoadNextAsync().ConfigureAwait(false);
        }

        int pageNumber = 1;
        async Task LoadNextAsync()
        {
            var news = await Services.News.NewsService.GetNewsAsync(pageNumber++).ConfigureAwait(false);

            Device.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in news)
                {
                    News.Add(item);
                }
            });
        }
    }
}
