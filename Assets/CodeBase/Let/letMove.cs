using CodeBase.Logic;
using CodeBase.Services.GameObserver;
using CodeBase.StaticData.Levels;
using UnityEngine;

namespace CodeBase.Let
{
    public class LetMove : MonoBehaviour, IApplyDamage
    {
        [SerializeField] private Rigidbody _rigidbody;

        private float _speed;
        private IGameObserverService _observerService;
        private bool _hasBeenSent;

        public void Construct(IGameObserverService observerService, LevelConfig levelConfig)
        {
            _observerService = observerService;
            _speed = levelConfig.LetMoveSpeed;
        }

        private void FixedUpdate()
        {
            UpdateRotate();
        }

        public void ApplyDamage()
        {
            if (_hasBeenSent)
                return;

            _observerService.SendEndGame();
            _hasBeenSent = true;
        }

        private void UpdateRotate()
        {
            Vector3 rotate = _rigidbody.rotation.eulerAngles;
            rotate.y += _speed * Time.fixedDeltaTime;
            _rigidbody.MoveRotation(Quaternion.Euler(rotate));
        }
    }
}