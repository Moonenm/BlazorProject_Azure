using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace BlazorProject.Pages
{
    public partial class Funfacts
    {
        protected override async Task OnInitializedAsync()
        {
            await ShowFunFacts();
        }

        [Inject]
        private ILocalStorageService? LocalStorage { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected string? result;

        // Methode om FunFacts weer te geven
        private async Task ShowFunFacts()
        {
            // De huidige datum
            var nu = DateTime.Now;
            var el = "Vandaag is het " + GetFormattedDate(nu) + "<br>";

            // Het aantal geleefde dagen berekenen
            var geboortedatum = await LocalStorage.GetItemAsync<DateTime>("gbdate");

            el += "Je bent geboren op " + GetFormattedDate(geboortedatum) + "<br>";

            var diffInDays = (nu - geboortedatum).TotalDays;
            el += "Je loopt al " + Math.Round(diffInDays) + " dagen op deze wereldbol rond. <br>";

            // Je vermoedelijke sterfdatum uitrekenen
            var gemJaren = 80.3; // Man, vrouw 84.4
            var totDagen = 365 * gemJaren;
            var nogTeLevenDagen = Math.Round(totDagen - diffInDays) * 24 * 3600 * 1000;
            var teLeven = nu.AddMilliseconds(nogTeLevenDagen);
            el += "Je zal vermoedelijk sterven op " + GetFormattedDate(teLeven) + "<br>";
            result = el;
        }
        // Nu kun je 'el' weergeven in je Blazor-component, bijvoorbeeld met een property.

        private static string GetFormattedDate(DateTime date)
        {
            var formattedDate = date.ToString("dddd d MMMM yyyy", new CultureInfo("nl-BE"));
            return formattedDate;
        }
        private void GoBack()
        {
            NavigationManager.NavigateTo("geboortedatum");
        }
    }
}
