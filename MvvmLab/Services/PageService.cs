using CommunityToolkit.Mvvm.ComponentModel;

using Microsoft.UI.Xaml.Controls;

using MvvmLab.Contracts.Services;
using MvvmLab.ViewModels;
using MvvmLab.Views;

namespace MvvmLab.Services;

public static class Pages
{
    public static string Main { get; } = "Main";
}

public class PageService : IPageService
{
    private readonly Dictionary<string, (Type ViewModelType, Type ViewType)> _pages = new();

    public PageService()
    {
        Configure<MainViewModel, MainPage>(Pages.Main);
    }

    public Type GetPageType(string key)
    {
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out var pageType))
            {
                throw new ArgumentException($"Page not found: {key}. Did you forget to call PageService.Configure?");
            }

            return pageType.ViewType;
        }
    }

    public Type GetViewModelType(string key)
    {
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out var pageType))
            {
                throw new ArgumentException($"ViewModel not found: {key}. Did you forget to call PageService.Configure?");
            }

            return pageType.ViewModelType;
        }
    }

    private void Configure<VM, V>(string key)
        where VM : ObservableObject
        where V : Page
    {
        lock (_pages)
        {
            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var types = (ViewModelType: typeof(VM), ViewType: typeof(V));
            if (_pages.ContainsValue(types))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == types).Key}");
            }

            _pages.Add(key, (ViewModelType: typeof(VM), ViewType: typeof(V)));
        }
    }
}
