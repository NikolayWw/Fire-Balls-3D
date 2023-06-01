using CodeBase.Obstacle;
using CodeBase.Services.Factory;
using CodeBase.Services.GameObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;
using CodeBase.Tower;

namespace CodeBase.LevelBuilder
{
    public class LevelBuilder
    {
        private readonly LevelConfig _levelConfig;
        private readonly TowerBuilder _towerBuilder;
        private readonly ObstacleBuilder _obstacleBuilder;

        public LevelBuilder(LevelConfig levelConfig, IGameFactory gameFactory, IStaticDataService dataService, IGameObserverService gameObserver)
        {
            _levelConfig = levelConfig;
            _towerBuilder = new TowerBuilder(gameFactory, dataService, gameObserver, levelConfig);
            _obstacleBuilder = new ObstacleBuilder(gameFactory, levelConfig);
        }

        public void Build()
        {
            _towerBuilder.Build();
            _obstacleBuilder.Build();
        }
    }
}