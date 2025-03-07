using Lab.Mvvm.Models;
using Lab.Mvvm.Services;

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab.Mvvm.ViewModels;

public class BooksPageViewModel : INotifyPropertyChanged
{
    private readonly BookService _booksService;

    public BooksPageViewModel()
    {
        _booksService = new BookService();
        Genres = _booksService.GetGenres();
        LoadBooks();
    }

    private List<Book> _books;
    public List<Book> Books
    { 
        get => _books;
        set => SetProperty(ref _books, value);
    }

    private List<string> _genres;
    public List<string> Genres
    {
        get => _genres;
        set => SetProperty(ref _genres, value);
    }

    private string _selectedGenre;
    public string SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            if (SetProperty(ref _selectedGenre, value))
                LoadBooks();
        }
    }

    private void LoadBooks()
    {
        Books = _booksService.GetBooks(SelectedGenre);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
    {
        if (object.Equals(property, value))
            return false;
        property = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        return true;
    }
}
