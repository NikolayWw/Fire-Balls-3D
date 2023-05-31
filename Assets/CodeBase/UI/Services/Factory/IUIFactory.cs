using CodeBase.Services;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Windows;
using System;
using System.Collections.Generic;

namespace CodeBase.UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();

        Dictionary<WindowId, BaseWindow> WindowsContainer { get; }
        Action<WindowId> OnWindowClose { get; set; }
        void Cleanup();
    }
}