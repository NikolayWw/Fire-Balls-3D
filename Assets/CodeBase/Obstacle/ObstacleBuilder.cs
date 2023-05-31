using CodeBase.Services.Factory;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Obstacle;

namespace CodeBase.Obstacle
{
    public class ObstacleBuilder
    {
        private readonly IGameFactory _gameFactory;
        private readonly LevelConfig _levelConfig;

        public ObstacleBuilder(IGameFactory gameFactory, LevelConfig levelConfig)
        {
            _gameFactory = gameFactory;
            _levelConfig = levelConfig;
        }

        public void Build()
        {
            foreach (ObstacleLevelStaticData staticData in _levelConfig.ObstacleLevelStaticData)
                _gameFactory.CreateObstacle(staticData.ObstacleId, staticData.Position);
        }
    }
}