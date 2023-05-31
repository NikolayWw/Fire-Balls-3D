using CodeBase.Bullet;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Obstacle;
using CodeBase.Services.GameObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Bullet;
using CodeBase.StaticData.Obstacle;
using CodeBase.StaticData.Tower;
using CodeBase.Tower;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _dataService;
        private readonly IGameObserverService _gameObserver;

        public GameFactory(IAssetProvider assetProvider, IStaticDataService dataService, IGameObserverService gameObserver)
        {
            _assetProvider = assetProvider;
            _dataService = dataService;
            _gameObserver = gameObserver;
        }

        public GameObject CreatePlayer() =>
            _assetProvider.Instantiate(AssetsPath.Player, _dataService.ForLevel(LevelKey).PlayerInitialPosition);

        public GameObject CreateTower(TowerId id, Vector3 at)
        {
            if (TowerId.None == id)
                return null;

            TowerConfig config = _dataService.ForTower(id);
            GameObject instance = Object.Instantiate(config.TowerPrefab, at, Quaternion.identity);
            instance.GetComponent<TowerMove>()?.Construct(config, _gameObserver);
            instance.GetComponent<TowerApplyDamage>()?.Construct(_gameObserver);
            return instance;
        }

        public GameObject CreateObstacle(ObstacleId id, Vector3 at)
        {
            if (ObstacleId.None == id)
                return null;

            ObstacleConfig config = _dataService.ForObstacle(id);
            GameObject instance = Object.Instantiate(config.Prefab, at, Quaternion.identity);
            instance.GetComponent<ObstacleMove>()?.Construct(_gameObserver, _dataService.ForLevel(LevelKey));
            instance.GetComponent<ObstacleApplyDamage>()?.Construct(_gameObserver);

            return instance;
        }

        public GameObject CreateBullet(BulletId id)
        {
            if (BulletId.None == id)
                return null;

            BulletConfig config = _dataService.ForBullet(id);
            GameObject instance = Object.Instantiate(config.Prefab);
            instance.GetComponent<BulletPoolObject>()?.Construct(_dataService.BulletStaticData.LifeTime);
            return instance;
        }

        private static string LevelKey =>
            SceneManager.GetActiveScene().name;
    }
}