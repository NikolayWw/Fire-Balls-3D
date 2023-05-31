using CodeBase.Services.GameObserver;
using CodeBase.StaticData.Tower;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerMove : MonoBehaviour
    {
        [SerializeField] private Transform _mainTransform;
        [SerializeField] private TowerApplyDamage _applyDamage;

        private float _stepHeight;
        private float _heightCount;
        private IGameObserverService _gameObserver;

        public void Construct(TowerConfig config, IGameObserverService gameObserver)
        {
            _stepHeight = config.StepHeight;
            _heightCount = config.Height;
            _gameObserver = gameObserver;
            _applyDamage.OnApplyDamage += Move;
        }

        private void Move()
        {
            _mainTransform.position += Vector3.down * _stepHeight;
            _heightCount -= _stepHeight;
            if (_heightCount <= 0)
            {
                _applyDamage.OnApplyDamage -= Move;
                _gameObserver.SendTowerDestroyed();
            }
        }
    }
}