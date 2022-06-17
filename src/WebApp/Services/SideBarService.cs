﻿namespace WebApp.Services
{
    public class SideBarService
    {
        private bool _isExpanded;

        public event Action? OnChange;

        public string IsExpandedClass => _isExpanded ? "active" : string.Empty;

        public void ToggleIsExpanded()
        {
            _isExpanded = !_isExpanded;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
