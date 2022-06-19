namespace Core.Services
{
    public class SideBarService
    {
        private bool _isExpanded = true;

        public event Action? OnChange;

        public string? IsExpandedClass => _isExpanded ? "active" : null;

        public void ToggleIsExpanded()
        {
            _isExpanded = !_isExpanded;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
