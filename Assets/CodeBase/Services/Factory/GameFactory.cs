using CodeBase.Bullet;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Let;
using CodeBase.Services.GameObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Bullet;
using CodeBase.StaticData.Let;
using CodeBase.StaticData.Levels;
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
        public GameObject CreateTower(TowerId id, Vector3 at)
        {
            if (TowerId.None == id)
                return null;

            TowerConfig config = _dataService.ForTower(id);
            GameObject instance = Object.Instantiate(config.TowerPrefab, at, Quaternion.identity);
            instance.GetComponent<TowerMove>()?.Construct(config, _gameObserver);
            return instance;
        }

        public GameObject CreateLet(LetId id, Vector3 at)
        {
            if (LetId.None == id)
                return null;

            LetConfig config = _dataService.ForLet(id);
            GameObject instance = Object.Instantiate(config.Prefab, at, Quaternion.identity);
            instance.GetComponent<LetMove>()?.Construct(_gameObserver, _dataService.ForLevel(LevelKey));
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

        private string LevelKey =>
            SceneManager.GetActiveScene().name;
    }
}