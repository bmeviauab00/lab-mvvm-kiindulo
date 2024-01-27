using Microsoft.UI.Xaml.Controls;

namespace MvvmLab.Helpers;

public static class FrameExtensions
{
    public static object? GetPageViewModel(this Frame frame) => (frame?.Content as Page)?.DataContext;

    public static void SetPageViewModel(this Frame frame, object viewModel)
    {
        var page = frame?.Content as Page;
        if (page is not null)
        {
            page.DataContext = viewModel;
        }
    }
}
