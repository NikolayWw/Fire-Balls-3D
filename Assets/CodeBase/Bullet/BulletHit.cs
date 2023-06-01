using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletHit : MonoBehaviour
    {
        [SerializeField] private BulletPoolObject _poolObject;
        private bool _isCausedDamage;

        private void Start()
        {
            _poolObject.OnEnable += () => _isCausedDamage = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_isCausedDamage)
                return;

            if (other.gameObject.TryGetComponent(out IBulletTouch applyDamage))
            {
                applyDamage.BulletTouch();
                _isCausedDamage = true;
            }
        }
    }
}