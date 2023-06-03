using CodeBase.StaticData.Bullet;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Obstacle;
using CodeBase.StaticData.Player;
using CodeBase.StaticData.Tower;

namespace CodeBase.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();

        LevelConfig ForLevel(string levelKey);

        TowerConfig ForTower(TowerId id);

        BulletConfig ForBullet(BulletId id);

        BulletStaticData BulletStaticData { get; }
        PlayerStaticData PlayerStaticData { get; }

        ObstacleConfig ForObstacle(ObstacleId id);
    }
}