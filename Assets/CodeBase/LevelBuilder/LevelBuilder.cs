using CodeBase.Services.Factory;
using CodeBase.Services.GameObserver;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Tower;
using UnityEngine;

namespace CodeBase.LevelBuilder
{
    public class LevelBuilder
    {
        private readonly LevelConfig _levelConfig;
        private readonly IGameFactory _gameFactory;
        private readonly IGameObserverService _gameObserver;

        private int _currentIndex;

        public LevelBuilder(LevelConfig levelConfig, IGameFactory gameFactory, IGameObserverService gameObserver)
        {
            _levelConfig = levelConfig;
            _gameFactory = gameFactory;
            _gameObserver = gameObserver;

            _gameObserver.OnPlayerFinishedMove += Build;
            _gameObserver.OnTowerDestroyed += CheckLevelCompleted;
        }

        public void Cleanup()
        {
            _gameObserver.OnPlayerFinishedMove -= Build;
            _gameObserver.OnTowerDestroyed -= CheckLevelCompleted;
        }

        public void Build()
        {
            if (_currentIndex >= _levelConfig.TowerLevelStaticData.Length)
            {
                Debug.LogError("Nothing more to build");
                return;
            }

            TowerLevelStaticData data = _levelConfig.TowerLevelStaticData[_currentIndex];

            _gameFactory.CreateTower(data.TowerId, data.Position);
            _gameFactory.CreateObstacle(data.ObstacleId, data.Position);
            _gameObserver.SendEndTowerBuild();
            _currentIndex++;
        }

        private void CheckLevelCompleted()
        {
            if (_currentIndex >= _levelConfig.TowerLevelStaticData.Length)
            {
                Debug.Log("Level Completed");
                _gameObserver.SendLevelCompleted();
            }
        }
    }
}