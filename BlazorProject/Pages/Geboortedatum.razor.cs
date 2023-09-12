using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;


namespace BlazorProject.Pages
{
    public partial class Geboortedatum
    {
        protected string? minDate;
        protected DateTime? geboortedatum;

        [Inject]
        private ILocalStorageService LocalStorage { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        // Deze methode wordt uitgevoerd wanneer de pagina wordt geladen
        protected override async Task OnInitializedAsync()
        {
            // Bepaal de minimale datum als 1970-01-01
            minDate = "1970-01-01";
            geboortedatum = await LocalStorage.GetItemAsync<DateTime>("gbdate");
        }

        // Methode om de geboortedatum op te slaan en door te gaan naar een andere pagina
        protected async Task StoreAndGo()
        {

            // Sla de geboortedatum op in de lokale opslag
            await LocalStorage.SetItemAsync("gbdate", geboortedatum);

            // Navigeer naar een andere pagina (vervang "opdracht_funfacts_OPL.html" door de gewenste URL)
            NavigationManager.NavigateTo("/funfacts");

        }
    }
}
