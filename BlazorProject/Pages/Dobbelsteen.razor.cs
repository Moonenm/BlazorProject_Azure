using Microsoft.AspNetCore.Components;

namespace BlazorProject.Pages
{
    public partial class Dobbelsteen
    {
        protected string resultMessage = ""; // Houdt de resultaatmelding bij
        private bool[] cardStatus = new bool[12]; // Houdt de status van elke kaart bij (true = success, false = secondary)
        private int antwoord = 1; // Houdt het aantal geraden spelers bij

        // Methode om de achtergrondkleuren van de kaarten te resetten
        private void Reset()
        {
            for (int i = 0; i < 12; i++)
            {
                cardStatus[i] = false; // Reset de status van elke kaart
            }

            resultMessage = ""; // Reset de resultaatmelding

        }

        // Methode om het spel te spelen
        private void Play()
        {
            Reset(); // Reset de kaarten, resultaatmelding en aantal geraden spelers

            var count = 0;

            var random = new Random();

            for (int i = 0; i < 12; i++)
            {
                var d = random.Next(1, 7); // Genereer een waarde tussen 1 en 6

                if (d == 6)
                {
                    cardStatus[i] = true; // Wijzig de status van de kaart naar success
                    count++;
                }
            }

            resultMessage = count + " speler(s) gooide een 6.";

            // Toon aan de gebruiker of hij juist heeft geraden
            if (antwoord == count)
            {
                resultMessage += " Gewonnen. Juist geraden!";
            }
            else
            {
                resultMessage += " Oeps. " + count + " speler gooiden een zes. Probeer nog eens...";
            }
            antwoord = 1; // Reset het aantal geraden spelers
        }

        // Bereken de stijl voor elke kaart op basis van de status
        private string CardStyle(int index)
        {
            return cardStatus[index] ? "background-color: green;" : "background-color: gray;";
        }
    }
}
