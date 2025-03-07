﻿using Lab.Mvvm.Models;

using Microsoft.Data.Sqlite;

using System.Collections.Generic;

namespace Lab.Mvvm.Services;

public class BookService
{
    private readonly string _connectionString = "Data Source=books.db";

    public void SeedDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS books (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Genre TEXT NOT NULL,
                ImageUrl TEXT NOT NULL
            )";
        using var createTableCommand = new SqliteCommand(createTableQuery, connection);
        createTableCommand.ExecuteNonQuery();

        string checkQuery = "SELECT COUNT(*) FROM books";
        using var checkCommand = new SqliteCommand(checkQuery, connection);
        long count = (long)checkCommand.ExecuteScalar();

        if (count != 0)
        {
            return;
        }

        var sampleBooks = new[]
        {
            ("To Kill a Mockingbird", "Fiction", "https://picsum.photos/id/24/300/200.jpg"),
            ("1984", "Dystopian", "https://picsum.photos/id/24/300/200.jpg"),
            ("The Great Gatsby", "Classic", "https://picsum.photos/id/24/300/200.jpg"),
            ("Pride and Prejudice", "Romance", "https://picsum.photos/id/24/300/200.jpg"),
            ("The Hobbit", "Fantasy", "https://picsum.photos/id/24/300/200.jpg"),
            ("The Catcher in the Rye", "Fiction", "https://picsum.photos/id/24/300/200.jpg"),
            ("Lord of the Flies", "Fiction", "https://picsum.photos/id/24/300/200.jpg"),
            ("Animal Farm", "Political", "https://picsum.photos/id/24/300/200.jpg"),
            ("The Alchemist", "Adventure", "https://picsum.photos/id/24/300/200.jpg"),
            ("Brave New World", "Dystopian", "https://picsum.photos/id/24/300/200.jpg"),
            ("Moby Dick", "Adventure", "https://picsum.photos/id/24/300/200.jpg"),
            ("War and Peace", "Historical", "https://picsum.photos/id/24/300/200.jpg"),
            ("Crime and Punishment", "Psychological", "https://picsum.photos/id/24/300/200.jpg"),
            ("The Odyssey", "Epic", "https://picsum.photos/id/24/300/200.jpg"),
            ("Don Quixote", "Adventure", "https://picsum.photos/id/24/300/200.jpg"),
            ("Jane Eyre", "Gothic", "https://picsum.photos/id/24/300/200.jpg"),
            ("Wuthering Heights", "Gothic", "https://picsum.photos/id/24/300/200.jpg"),
            ("The Count of Monte Cristo", "Adventure", "https://picsum.photos/id/24/300/200.jpg"),
            ("Les Misérables", "Historical", "https://picsum.photos/id/24/300/200.jpg"),
            ("One Hundred Years of Solitude", "Magical Realism", "https://picsum.photos/id/24/300/200.jpg")
        };

        string insertQuery = "INSERT INTO books (Title, Genre, ImageUrl) VALUES (@Title, @Genre, @ImageUrl)";
        foreach (var (title, genre, imageUrl) in sampleBooks)
        {
            using var insertCommand = new SqliteCommand(insertQuery, connection);
            insertCommand.Parameters.AddWithValue("@Title", title);
            insertCommand.Parameters.AddWithValue("@Genre", genre);
            insertCommand.Parameters.AddWithValue("@ImageUrl", imageUrl);
            insertCommand.ExecuteNonQuery();
        }
    }

    public List<string> GetGenres()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string query = "SELECT DISTINCT Genre FROM books";
        using var command = new SqliteCommand(query, connection);
        using var reader = command.ExecuteReader();

        List<string> genres = [];
        while (reader.Read())
        {
            genres.Add(reader["Genre"].ToString());
        }

        return genres;
    }

    public List<Book> GetBooks(string genre = null)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        string query = "SELECT Title, Genre, ImageUrl FROM books";
        if (genre != null)
        {
            query += " WHERE Genre = @genre";
        }
        using var command = new SqliteCommand(query, connection);
        if (genre != null)
        {
            command.Parameters.AddWithValue("@genre", genre);
        }

        List<Book> books = [];
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var book = new Book
            {
                Title = reader["Title"].ToString(),
                Genre = reader["Genre"].ToString(),
                ImageUrl = reader["ImageUrl"].ToString(),
            };

            books.Add(book);
        }

        return books;
    }
}
