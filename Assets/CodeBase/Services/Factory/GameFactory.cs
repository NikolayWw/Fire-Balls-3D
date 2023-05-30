using CodeBase.Bullet;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Bullet;
using CodeBase.StaticData.Tower;
using UnityEngine;

namespace CodeBase.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _dataService;

        public GameFactory(IAssetProvider assetProvider, IStaticDataService dataService)
        {
            _assetProvider = assetProvider;
            _dataService = dataService;
        }

        public GameObject CreateTower(TowerId id, Vector3 at)
        {
            TowerConfig config = _dataService.ForTower(id);
            return Object.Instantiate(config.TowerPrefab, at, Quaternion.identity);
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