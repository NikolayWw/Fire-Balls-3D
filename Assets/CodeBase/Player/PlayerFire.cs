using CodeBase.Bullet;
using CodeBase.Infrastructure.Logic.Pool;
using CodeBase.Services;
using CodeBase.Services.Factory;
using CodeBase.Services.LogicFactory;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Bullet;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerFire : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        private IGameFactory _gameFactory;
        private IStaticDataService _staticData;
        private BulletObjectPool _bulletPool;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            _staticData = AllServices.Container.Single<IStaticDataService>();
            _bulletPool = AllServices.Container.Single<ILogicFactory>().CreateBulletObjectPool();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Fire();
        }

        private void Fire()
        {
          //  BulletObjectPoolReporter poolReporter = _bulletPool.Get(BulletId.Bullet1);
           // poolReporter.
          //  var bullet = _gameFactory.CreateBullet(BulletId.Bullet1);
          //  bullet.SetPositionAndDirection(_shootPoint.position, _shootPoint.forward * _staticData.BulletStaticData.ShootForce);
        }
    }
}