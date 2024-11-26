using System;
using LastFmLib;
using Meridian.Services;
using Meridian.ViewModel.Main;
using VkLib;

namespace Meridian.ViewModel
{
    public class ViewModelLocator
    {
        private static Lazy<MainViewModel> _main = new Lazy<MainViewModel>(() => new MainViewModel());
        private static Lazy<NowPlayingViewModel> _nowPlaying = new Lazy<NowPlayingViewModel>(() => new NowPlayingViewModel());
        private static readonly Vk _vkontakte = new Vk(appId: "2685278", clientSecret: "lxhD8OD7dMsqtXIm5IUY", apiVersion: "5.81", userAgent: "KateMobileAndroid");
        private static readonly LastFm _lastFm = new LastFm("a012acc1e5f8a61bc7e58238ce3021d8", "86776d4f43a72633fb37fb28713a7798");
        private static readonly UpdateService _updateService = new UpdateService();

        public static MainViewModel Main
        {
            get { return _main.Value; }
        }

        public static NowPlayingViewModel NowPlaying
        {
            get { return _nowPlaying.Value; }
        }

        public static Vk Vkontakte
        {
            get { return _vkontakte; }
        }

        public static LastFm LastFm
        {
            get { return _lastFm; }
        }

        public static UpdateService UpdateService
        {
            get { return _updateService; }
        }

        public ViewModelLocator()
        {

        }
    }
}
