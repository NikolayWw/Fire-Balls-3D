using CodeBase.Logic.Pool;
using CodeBase.Services.Factory;
using CodeBase.Services.GameObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;

namespace CodeBase.Services.LogicFactory
{
    public class LogicFactory : ILogicFactory
    {
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _dataService;
        private readonly IGameObserverService _gameObserver;

        public LevelBuilder.LevelBuilder LevelBuilder { get; private set; }

        public LogicFactory(IGameFactory gameFactory, IStaticDataService dataService, IGameObserverService gameObserver)
        {
            _gameFactory = gameFactory;
            _dataService = dataService;
            _gameObserver = gameObserver;
        }

        public void Cleanup()
        {
            LevelBuilder = null;
        }

        public void InitializeLevelBuilder(LevelConfig levelConfig)
        {
            LevelBuilder = new LevelBuilder.LevelBuilder(levelConfig, _gameFactory, _dataService, _gameObserver);
        }

        public BulletPoolHandlerHandler CreateBulletObjectPool() =>
            new(_gameFactory);
    }
}