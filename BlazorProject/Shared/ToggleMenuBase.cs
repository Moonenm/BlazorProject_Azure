using Microsoft.AspNetCore.Components;

namespace BlazorProject.Shared
{
    public class ToggleMenuBase : ComponentBase
    {

        protected string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        protected bool collapseNavMenu = true;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

    }
}
