using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Window;
using CodeBase.UI.Windows;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";

        public Dictionary<WindowId, BaseWindow> WindowsContainer { get; } = new Dictionary<WindowId, BaseWindow>();
        public Action<WindowId> OnWindowClose { get; set; }

        private Transform _uiRoot;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }
        public void Cleanup()
        {
            WindowsContainer.Clear();
            OnWindowClose = null;
        }
        public void CreateUIRoot() =>
            _uiRoot = _assetProvider.Instantiate(UIRootPath).transform;

        private TWindow InstantiateRegister<TWindow>(WindowId id) where TWindow : BaseWindow
        {
            WindowConfig config = _staticDataService.ForWindow(id);
            var window = Object.Instantiate(config.Template, _uiRoot);

            window.SetId(id);
            window.OnClosed += SendOnClosed;
            WindowsContainer[id] = window;
            return (TWindow)window;
        }

        private void SendOnClosed(WindowId id) =>
           OnWindowClose?.Invoke(id);
    }
}