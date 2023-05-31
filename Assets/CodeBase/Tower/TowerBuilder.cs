using CodeBase.Services.Factory;
using CodeBase.Services.GameObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Tower;

namespace CodeBase.Tower
{
    public class TowerBuilder
    {
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _dataService;
        private readonly IGameObserverService _observerService;
        private readonly LevelConfig _levelConfig;

        public TowerBuilder(IGameFactory gameFactory, IStaticDataService dataService, IGameObserverService observerService, LevelConfig levelConfig)
        {
            _gameFactory = gameFactory;
            _dataService = dataService;
            _observerService = observerService;
            _levelConfig = levelConfig;
        }

        public void Build()
        {
            foreach (TowerLevelStaticData staticData in _levelConfig.TowerLevelStaticData)
                _gameFactory.CreateTower(staticData.TowerId, staticData.Position);
        }
    }
}