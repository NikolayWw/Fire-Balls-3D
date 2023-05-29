﻿using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Tower;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Window;

namespace CodeBase.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();

        WindowConfig ForWindow(WindowId id);
        LevelConfig ForLevel(string levelKey);
        TowerConfig ForTower(TowerId id);
    }
}