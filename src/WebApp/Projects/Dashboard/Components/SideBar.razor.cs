using Microsoft.AspNetCore.Components;

namespace WebApp.Projects.Dashboard.Components
{
    public partial class SideBar : ComponentBase
    {
        public void ToggleSidebar()
        {
            SideBarService.ToggleIsExpanded();
        }
    }
}
