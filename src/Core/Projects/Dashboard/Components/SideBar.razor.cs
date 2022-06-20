using Microsoft.AspNetCore.Components;

namespace Core.Projects.Dashboard.Components
{
    public partial class SideBar : ComponentBase
    {
        public void ToggleSidebar()
        {
            SideBarService.ToggleIsExpanded();
        }
    }
}
