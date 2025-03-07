using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Lab.Mvvm.Models;
using Lab.Mvvm.Services;

using System.Collections.Generic;
using System.Windows.Input;

namespace Lab.Mvvm.ViewModels;

public partial class BooksPageViewModel : ObservableObject
{
    private readonly BookService _booksService;

    public BooksPageViewModel()
    {
        _booksService = new BookService();
        Genres = _booksService.GetGenres();
        LoadBooks();

        ClearFilterCommand = new RelayCommand(
            execute: () => SelectedGenre = null,
            canExecute: () => SelectedGenre != null);
    }

    public IRelayCommand ClearFilterCommand { get; }

    [ObservableProperty]
    private List<Book> _books;

    [ObservableProperty]
    private List<string> _genres;

    [ObservableProperty]
    private string _selectedGenre;

    partial void OnSelectedGenreChanged(string value)
    {
        LoadBooks();
        ClearFilterCommand.NotifyCanExecuteChanged();
    }

    private void LoadBooks() => Books = _booksService.GetBooks(SelectedGenre);
}
