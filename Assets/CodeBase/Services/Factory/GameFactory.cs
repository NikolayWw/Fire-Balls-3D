using CodeBase.Bullet;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Obstacle;
using CodeBase.Player;
using CodeBase.Services.GameObserver;
using CodeBase.Services.Input;
using CodeBase.Services.LogicFactory;
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
        private readonly AllServices _allServices;

        public GameFactory(AllServices allServices)
        {
            _allServices = allServices;
        }

        public GameObject CreatePlayer()
        {
            GameObject instance = Service<IAssetProvider>().Instantiate(AssetsPath.Player, Service<IStaticDataService>().ForLevel(LevelKey).PlayerInitialPosition);
            instance.GetComponent<PlayerFire>()?.Construct(Service<IInputService>(), Service<IStaticDataService>(), Service<ILogicFactory>(), Service<IGameObserverService>());
            instance.GetComponent<PlayerMove>()?.Construct(Service<IGameObserverService>(), Service<IStaticDataService>(), Service<IStaticDataService>().ForLevel(LevelKey));
            return instance;
        }

        public GameObject CreateTower(TowerId id, Vector3 at)
        {
            if (TowerId.None == id)
                return null;

            TowerConfig config = Service<IStaticDataService>().ForTower(id);
            GameObject instance = Object.Instantiate(config.TowerPrefab, at, Quaternion.identity);
            instance.GetComponent<TowerMove>()?.Construct(config, Service<IGameObserverService>());
            instance.GetComponent<TowerApplyDamage>()?.Construct(Service<IGameObserverService>());
            return instance;
        }

        public GameObject CreateObstacle(ObstacleId id, Vector3 at)
        {
            if (ObstacleId.None == id)
                return null;

            ObstacleConfig config = Service<IStaticDataService>().ForObstacle(id);
            GameObject instance = Object.Instantiate(config.Prefab, at, Quaternion.identity);
            instance.GetComponent<ObstacleMove>()?.Construct(Service<IGameObserverService>(), Service<IStaticDataService>().ForLevel(LevelKey));
            instance.GetComponent<ObstacleApplyDamage>()?.Construct(Service<IGameObserverService>());

            return instance;
        }

        public GameObject CreateBullet(BulletId id)
        {
            if (BulletId.None == id)
                return null;

            BulletConfig config = Service<IStaticDataService>().ForBullet(id);
            GameObject instance = Object.Instantiate(config.Prefab);
            instance.GetComponent<BulletPoolObject>()?.Construct(Service<IStaticDataService>().BulletStaticData.LifeTime);
            return instance;
        }

        private static string LevelKey =>
            SceneManager.GetActiveScene().name;

        private TService Service<TService>() where TService : IService =>
            _allServices.Single<TService>();
    }
}