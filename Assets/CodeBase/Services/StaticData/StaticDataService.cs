using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Window;
using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Tower;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string WindowStaticDataPath = "StaticData/WindowStaticData";
        private const string LevelsStaticDataPath = "StaticData/LevelsStaticData";
        private const string TowerStaticDataPath = "StaticData/TowerStaticData";

        private Dictionary<WindowId, WindowConfig> _windowConfigs;
        private Dictionary<string, LevelConfig> _levelConfigs;
        private Dictionary<TowerId, TowerConfig> _towerConfigs;


        public void Load()
        {
            _windowConfigs = Resources.Load<WindowStaticData>(WindowStaticDataPath).Configs.ToDictionary(x => x.WindowId, x => x);
            _levelConfigs = Resources.Load<LevelsStaticData>(LevelsStaticDataPath).LevelConfigs.ToDictionary(x => x.LevelKey, x => x);
            _towerConfigs = Resources.Load<TowerStaticData>(TowerStaticDataPath).TowerConfigs.ToDictionary(x => x.TowerId, x => x);
        }

        public WindowConfig ForWindow(WindowId id) =>
            _windowConfigs.TryGetValue(id, out var data) ? data : null;

        public LevelConfig ForLevel(string levelKey) =>
            _levelConfigs.TryGetValue(levelKey, out var data) ? data : null;

        public TowerConfig ForTower(TowerId id) =>
            _towerConfigs.TryGetValue(id, out var data) ? data : null;
    }
}