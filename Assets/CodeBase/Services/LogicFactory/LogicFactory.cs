using CodeBase.Logic.Pool;
using CodeBase.Services.Factory;
using CodeBase.Services.GameObserver;
using CodeBase.StaticData.Levels;

namespace CodeBase.Services.LogicFactory
{
    public class LogicFactory : ILogicFactory
    {
        private readonly IGameFactory _gameFactory;
        private readonly IGameObserverService _gameObserver;

        public LevelBuilder.LevelBuilder LevelBuilder { get; private set; }

        public LogicFactory(IGameFactory gameFactory, IGameObserverService gameObserver)
        {
            _gameFactory = gameFactory;
            _gameObserver = gameObserver;
        }

        public void Cleanup()
        {
            LevelBuilder?.Cleanup();
            LevelBuilder = null;
        }

        public void InitializeLevelBuilder(LevelConfig levelConfig) =>
            LevelBuilder = new LevelBuilder.LevelBuilder(levelConfig, _gameFactory, _gameObserver);

        public BulletPoolHandler CreateBulletObjectPool() =>
            new(_gameFactory);
    }
}