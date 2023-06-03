using CodeBase.StaticData.Bullet;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Obstacle;
using CodeBase.StaticData.Player;
using CodeBase.StaticData.Tower;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string LevelsStaticDataPath = "StaticData/LevelsStaticData";
        private const string TowerStaticDataPath = "StaticData/TowerStaticData";
        private const string BulletStaticDataPath = "StaticData/BulletStaticData";
        private const string ObstacleStaticDataPath = "StaticData/ObstacleStaticData";
        private const string PlayerStaticDataPath = "StaticData/PlayerStaticData";

        public BulletStaticData BulletStaticData { get; private set; }
        public PlayerStaticData PlayerStaticData { get; private set; }

        private Dictionary<string, LevelConfig> _levelConfigs;
        private Dictionary<TowerId, TowerConfig> _towerConfigs;
        private Dictionary<BulletId, BulletConfig> _bulletConfigs;
        private Dictionary<ObstacleId, ObstacleConfig> _obstacleConfigs;

        public void Load()
        {
            _levelConfigs = Resources.Load<LevelsStaticData>(LevelsStaticDataPath).LevelConfigs.ToDictionary(x => x.LevelKey, x => x);
            _towerConfigs = Resources.Load<TowerStaticData>(TowerStaticDataPath).TowerConfigs.ToDictionary(x => x.TowerId, x => x);
            LoadBulletData();
            _obstacleConfigs = Resources.Load<ObstacleStaticData>(ObstacleStaticDataPath).ObstacleConfigs.ToDictionary(x => x.Id, x => x);
            PlayerStaticData = Resources.Load<PlayerStaticData>(PlayerStaticDataPath);
        }

        public LevelConfig ForLevel(string levelKey) =>
            _levelConfigs.TryGetValue(levelKey, out var data) ? data : null;

        public TowerConfig ForTower(TowerId id) =>
            _towerConfigs.TryGetValue(id, out var data) ? data : null;

        public BulletConfig ForBullet(BulletId id) =>
            _bulletConfigs.TryGetValue(id, out var data) ? data : null;

        public ObstacleConfig ForObstacle(ObstacleId id) =>
            _obstacleConfigs.TryGetValue(id, out var data) ? data : null;

        private void LoadBulletData()
        {
            BulletStaticData = Resources.Load<BulletStaticData>(BulletStaticDataPath);
            _bulletConfigs = BulletStaticData.BulletConfigs.ToDictionary(x => x.BulletId, x => x);
        }
    }
}