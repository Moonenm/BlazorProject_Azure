using Microsoft.AspNetCore.Components;

namespace BlazorProject.Pages
{
    public partial class  Foto
    {
        private readonly string[] arrImages = { "breakfast.jpg", "flower.jpg", "flower_red.jpg", "fontain.jpg", "lunch.jpg", "sunset.jpg" };
        private readonly int lBound = 0;
        private int hBound;
        private string log = "";
        protected string? currentImage;
        private int currentIndex;

        protected override void OnInitialized()
        {
            hBound = arrImages.Length - 1;
            currentIndex = RandomIntFromInterval(lBound, hBound);
            currentImage = "images/" + arrImages[RandomIntFromInterval(lBound, hBound)];
        }

        private void ChangeRandomImage()
        {
            int randomNumber;
            log = "Geklikt op nieuwe random (Vorige waarde = " + currentIndex + ") <br>";

            do
            {
                randomNumber = RandomIntFromInterval(lBound, hBound);
                log += randomNumber + "<br>";
            } while (randomNumber == currentIndex);

            currentIndex = randomNumber;
            currentImage = "images/" + arrImages[currentIndex];

            currentImage = "images/" + arrImages[randomNumber];
        }

        private static int RandomIntFromInterval(int min, int max)
        {
            Random random = new();
            return random.Next(min, max + 1);
        }
    }
}
