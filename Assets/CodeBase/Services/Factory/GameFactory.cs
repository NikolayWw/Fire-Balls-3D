using CodeBase.Bullet;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.GameObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Bullet;
using CodeBase.StaticData.Tower;
using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _dataService;
        private readonly IGameObserverService _gameObserver;

        public GameFactory(IAssetProvider assetProvider, IStaticDataService dataService,IGameObserverService gameObserver)
        {
            _assetProvider = assetProvider;
            _dataService = dataService;
            _gameObserver = gameObserver;
        }

        public GameObject CreateTower(TowerId id, Vector3 at)
        {
            TowerConfig config = _dataService.ForTower(id);
            GameObject instance = Object.Instantiate(config.TowerPrefab, at, Quaternion.identity);
            instance.GetComponent<TowerMove>()?.Construct(config, _gameObserver);
            return instance;
        }

        public GameObject CreateBullet(BulletId id)
        {
            BulletConfig config = _dataService.ForBullet(id);
            GameObject instance = Object.Instantiate(config.Prefab);
            instance.GetComponent<BulletPoolObject>()?.Construct(_dataService.BulletStaticData.LifeTime);
            return instance;
        }
    }
}