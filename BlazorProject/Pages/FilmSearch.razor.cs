using Microsoft.AspNetCore.Components;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;


namespace BlazorProject.Pages
{
    public partial class FilmSearch
    {
        protected string? searchTerm;
        protected MovieSearchResult? movies;
        protected string? message;
        protected string? messageClass;
        
        protected class MovieSearchResult
        {
            public List<Movie> Search { get; set; } = new List<Movie>();
            public string Response { get; set; } = default!;
            public string Error { get; set; } = default!;
            public int TotalResults { get; set; } = default!;

        }

        public class Movie
        {
            public string Title { get; set; } = default!;
            public string Year { get; set; } = default!;
            public string imdbID { get; set; } = default!;
            public string Type { get; set; } = default!;
            public string Poster { get; set; } = default!;
        }

       
        protected async Task SearchMovies()
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                ShowMessage("alert-danger", "De zoekterm mag niet leeg zijn.");
                return;
            }

            if (searchTerm.Length < 2 || searchTerm.Length > 15)
            {
                ShowMessage("alert-danger", "De zoekterm moet tussen 2 en 15 tekens lang zijn.");
                return;
            }

            // Vervang spaties door %20 in de zoekterm
            var encodedSearchTerm = searchTerm.Replace(" ", "%20");

            // Gebruik HttpClient voor het aanroepen van de API
            using var httpClient = new HttpClient();
            var apiKey = "9aa2196e"; // Jouw API-key
            var apiUrl = $"https://www.omdbapi.com/?s={encodedSearchTerm}&type=movie&apikey={apiKey}";

            try
            {
                var response = await httpClient.GetStringAsync(apiUrl);
                movies = JsonSerializer.Deserialize<MovieSearchResult>(response);

                if (movies != null)
                {
                    if (movies.Response == "True")
                    {
                        ShowMessage("alert-success", $"Aantal gevonden: {movies.TotalResults}");

                        // Je kunt nu de films verkrijgen via movies.Search
                        foreach (var movie in movies.Search)
                        {
                            Console.WriteLine($"Title: {movie.Title}, Year: {movie.Year}, imdbID: {movie.imdbID}");
                        }
                    }
                    else
                    {
                        ShowMessage("alert-danger", movies.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("alert-danger", $"Fout bij het ophalen van gegevens: {ex.Message}");
            }
        }

        private void ShowMessage(string messageType, string messageText)
        {
            messageClass = messageType;
            message = messageText;
        }
    }
}
