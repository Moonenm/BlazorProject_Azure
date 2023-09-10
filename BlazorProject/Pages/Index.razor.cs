using Microsoft.AspNetCore.Components;

namespace BlazorProject.Pages
{
    public partial class Index
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private void FilmSearch()
        {
            NavigationManager.NavigateTo("filmsearch");
        }
        private void Fotozoeken()
        {
            NavigationManager.NavigateTo("foto");
        }
        private void Funfactsstarten()
        {
            NavigationManager.NavigateTo("geboortedatum");
        }
        private void Dobbelen()
        {
            NavigationManager.NavigateTo("dobbelsteen");
        }

    }
}
