using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Window;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string WindowStaticDataPath = "StaticData/WindowStaticData";

        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void Load()
        {
            _windowConfigs = Resources.Load<WindowStaticData>(WindowStaticDataPath).Configs.ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfig ForWindow(WindowId id) =>
            _windowConfigs.TryGetValue(id, out var data) ? data : null;
    }
}