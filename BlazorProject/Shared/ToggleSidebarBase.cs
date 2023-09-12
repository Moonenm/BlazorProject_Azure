using Microsoft.AspNetCore.Components;

namespace BlazorProject.Shared
{
    public class ToggleSidebarBase : ComponentBase
    {
        protected string? SidebarCSSClass => hideSidebar ? "is-open" : null;
        protected bool hideSidebar = false;

        protected void ToggleSidebar()
        {
            hideSidebar = !hideSidebar;
        }

    }
}
