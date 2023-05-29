using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletHit : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(1);
            if (other.gameObject.TryGetComponent(out IApplyDamage applyDamage))
                applyDamage.ApplyDamage();
        }
    }
}