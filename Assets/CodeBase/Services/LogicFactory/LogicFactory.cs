using CodeBase.Logic.Pool;
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

        public BulletPoolHandlerHandler CreateBulletObjectPool()
        {
            return new BulletPoolHandlerHandler(_gameFactory);
        }
    }
}