using CodeBase.Services.GameObserver;
using CodeBase.StaticData.Levels;
using UnityEngine;

namespace CodeBase.Obstacle
{
    public class ObstacleMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private float _speed;
        private IGameObserverService _observerService;

        public void Construct(IGameObserverService observerService, LevelConfig levelConfig)
        {
            _observerService = observerService;
            _speed = levelConfig.ObstacleMoveSpeed;

            _observerService.OnTowerDestroyed += StopMove;
        }

        private void OnDestroy()
        {
            _observerService.OnTowerDestroyed -= StopMove;
        }

        private void FixedUpdate()
        {
            UpdateRotate();
        }

        private void UpdateRotate()
        {
            Vector3 rotate = _rigidbody.rotation.eulerAngles;
            rotate.y += _speed * Time.fixedDeltaTime;
            _rigidbody.MoveRotation(Quaternion.Euler(rotate));
        }

        private void StopMove() => 
            enabled = false;
    }
}