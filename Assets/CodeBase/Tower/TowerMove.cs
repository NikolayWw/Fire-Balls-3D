using CodeBase.Logic;
using CodeBase.Services.GameObserver;
using CodeBase.StaticData.Tower;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerMove : MonoBehaviour, IBulletTouch
    {
        [SerializeField] private Transform _mainTransform;

        private IGameObserverService _gameObserver;
        private float _stepHeight;
        private float _heightCount;

        public void Construct(TowerConfig config, IGameObserverService gameObserver)
        {
            _stepHeight = config.StepHeight;
            _heightCount = config.Height;
            _gameObserver = gameObserver;
        }

        public void BulletTouch()
        {
            Move();
        }

        private void Move()
        {
            _mainTransform.position += Vector3.down * _stepHeight;
            _heightCount -= _stepHeight;
            if (_heightCount <= 0)
            {
                _gameObserver.SendTowerDestroyed();
                CloseThis();
            }
        }

        private void CloseThis() =>
            Destroy(_mainTransform.gameObject);
    }
}