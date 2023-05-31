using CodeBase.Logic.Pool;
using CodeBase.Obstacle;
using CodeBase.Services.Factory;
using CodeBase.Services.GameObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;
using CodeBase.Tower;

namespace CodeBase.Services.LogicFactory
{
    public class LogicFactory : ILogicFactory
    {
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _dataService;
        private readonly IGameObserverService _gameObserver;

        public TowerBuilder TowerBuilder { get; private set; }
        public ObstacleBuilder ObstacleBuilder { get; private set; }

        public LogicFactory(IGameFactory gameFactory, IStaticDataService dataService, IGameObserverService gameObserver)
        {
            _gameFactory = gameFactory;
            _dataService = dataService;
            _gameObserver = gameObserver;
        }

        public void Cleanup()
        {
            TowerBuilder = null;
        }

        public void InitializeTowerBuilder(LevelConfig levelConfig)
        {
            TowerBuilder = new TowerBuilder(_gameFactory, _dataService, _gameObserver, levelConfig);
        }

        public void InitializeObstacleBuilder(LevelConfig levelConfig)
        {
            ObstacleBuilder = new ObstacleBuilder(_gameFactory, levelConfig);
        }

        public BulletPoolHandlerHandler CreateBulletObjectPool()
        {
            return new BulletPoolHandlerHandler(_gameFactory);
        }
    }
}