using CodeBase.Infrastructure.Logic.Pool;
using CodeBase.Services.Factory;

namespace CodeBase.Services.LogicFactory
{
    public class LogicFactory : ILogicFactory
    {
        private readonly IGameFactory _gameFactory;

        public LogicFactory(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public BulletObjectPool CreateBulletObjectPool()
        {
            return new BulletObjectPool(_gameFactory);
        }
    }
}