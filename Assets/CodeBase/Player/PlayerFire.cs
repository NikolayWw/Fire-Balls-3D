using CodeBase.Bullet;
using CodeBase.Logic.Pool;
using CodeBase.Services.GameObserver;
using CodeBase.Services.Input;
using CodeBase.Services.LogicFactory;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Bullet;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerFire : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;

        private IStaticDataService _staticData;
        private BulletPoolHandler _bulletPoolHandler;
        private IInputService _inputService;
        private IGameObserverService _gameObserver;

        public void Construct(IInputService inputService, IStaticDataService dataService, ILogicFactory logicFactory, IGameObserverService gameObserver)
        {
            _inputService = inputService;
            _staticData = dataService;
            _bulletPoolHandler = logicFactory.CreateBulletObjectPool();
            _gameObserver = gameObserver;

            _gameObserver.OnTowerDestroyed += Freeze;
            _gameObserver.OnEndTowerBuild += Unfreeze;

            _bulletPoolHandler.InitStartObjects(BulletId.Bullet1, _staticData.BulletStaticData.PoolCount);
        }

        private void OnDestroy()
        {
            _gameObserver.OnTowerDestroyed -= Freeze;
            _gameObserver.OnEndTowerBuild -= Unfreeze;
        }

        private void Update()
        {
            if (_inputService.IsFire)
                Fire();
        }

        private void Fire()
        {
            BulletMove bullet = _bulletPoolHandler.Get(BulletId.Bullet1);
            bullet.SetPositionAndDirection(_shootPoint.position, _shootPoint.forward * _staticData.PlayerStaticData.ShootForce);
        }

        private void Freeze()
        {
            enabled = false;
        }

        private void Unfreeze()
        {
            enabled = true;
        }
    }
}